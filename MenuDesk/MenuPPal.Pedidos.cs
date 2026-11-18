using Alemana.DTOs;
using System.Linq;
using System.Net;

namespace MenuDesk
{
    public partial class MenuPPal
    {
        private bool _pedidosIniciado;
        private bool _cargandoPedidos;
        string endpoint = "pedidos";

        private void PedidosPage_CheckedChanged(object sender, EventArgs e)
        {
            bool mostrar = !panelPedidos.Visible;
            panelPedidos.Visible = mostrar;
            panelPedidos.Enabled = mostrar;

            if (mostrar) IniciarPedidos();
            else DetenerPedidos();
        }

        private void pnlPedidos_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlPedidos.Visible) IniciarPedidos();
            else DetenerPedidos();
        }


        private async void IniciarPedidos()
        {
            if (_cargandoPedidos) return;      
            _cargandoPedidos = true;
            try
            {
                if (!_pedidosIniciado)
                {
                    pnlPedidos.VerPedidoClick += PnlPedidos_VerPedidoClick;
                    _pedidosIniciado = true;
                    pnlPedidos.AceptarPedidoClick += PnlPedidos_AceptarPedidoClick;
                }

                var pedidos = await ObtenerPedidosPendientesAsync();

                if (!pnlPedidos.Visible) return;   

                pnlPedidos.Limpiar();
                pnlPedidos.CargarPedidos(pedidos);
                tmrPedidos.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los pedidos:\n" + ex.ToString());
            }
            finally
            {
                _cargandoPedidos = false;
            }
        }

        private void DetenerPedidos()
        {
            tmrPedidos.Stop();
        }

        private async void tmrPedidos_Tick(object sender, EventArgs e)
        {
            tmrPedidos.Stop();   
            try
            {
                var nuevos = await ObtenerPedidosDesdeAsync(pnlPedidos.UltimoIdCargado);
                if (pnlPedidos.Visible) pnlPedidos.CargarPedidos(nuevos);
            }
            catch (Exception)
            {

            }
            finally
            {
                if (pnlPedidos.Visible) tmrPedidos.Start();
            }
        }

        private async void PnlPedidos_VerPedidoClick(int pedidoId)
        {
            try
            {
                var productos = await ObtenerProductosPedidoAsync(pedidoId);
                var frm = new FormPedidoDetalleMini(pedidoId, productos);
                frm.Show(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir el pedido: " + ex.Message);
            }
        }

        private async void PnlPedidos_AceptarPedidoClick(int idPedido)
        {
            try
            {
                var items = await _apiClient.ObtenerListaAsync<ItemPedidoDespachoDTO>($"{endpoint}/{idPedido}/items");
                if (items == null || items.Count == 0)
                {
                    MessageBox.Show("No se encontró el pedido o no tiene productos.",
                        "Pedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var empleados = await _apiClient.ObtenerListaAsync<EmpleadoDTO>("empleado") ?? new List<EmpleadoDTO>();
                int? idEmpleadoActual = _apiClient.Rol == "Empleado" ? _apiClient.IdUsuario : null;

                using var frm = new FormGestionPedido(idPedido, items, empleados, idEmpleadoActual);
                if (frm.ShowDialog(this) != DialogResult.OK) return;

                ResultadoPedidoDTO? resultado = null;

                if (frm.Aceptaciones.Count > 0)
                {
                    var r = await _apiClient.PostConDatosAsync<ResultadoPedidoDTO, AceptarPedidoProductosDTO>(
                        $"{endpoint}/{idPedido}/aceptar", new AceptarPedidoProductosDTO { Items = frm.Aceptaciones });
                    if (!r.Ok)
                    {
                        MessageBox.Show(r.Mensaje ?? "No se pudo guardar la aceptación.",
                            "Pedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    resultado = r.Datos;
                }

                if (frm.Despachos.Count > 0)
                {
                    var r = await _apiClient.PostConDatosAsync<ResultadoPedidoDTO, DespacharPedidoDTO>(
                        $"{endpoint}/{idPedido}/despachos",
                        new DespacharPedidoDTO { IdEmpleado = frm.IdEmpleado, Items = frm.Despachos });
                    if (!r.Ok)
                    {
                        MessageBox.Show(r.Mensaje ?? "No se pudo registrar el despacho.",
                            "Pedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    resultado = r.Datos;
                }

                MostrarResultado(idPedido, resultado);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al gestionar el pedido: " + ex.Message,
                    "Pedido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>Completado sale de la lista; si lo aceptado supera el stock, se ofrece generar la producción faltante.</summary>
        private void MostrarResultado(int idPedido, ResultadoPedidoDTO? datos)
        {
            if (datos == null) return;

            if (datos.EstadoPedido == "Completado")
            {
                pnlPedidos.QuitarPedido(idPedido);
                return;
            }

            var faltantes = datos.Items
                .Where(i => i.PendienteDespachar > i.StockDisponible)
                .Select(i => new ProductoPendienteProduccionDTO
                {
                    IdProducto = i.IdProducto,
                    NombreProducto = i.NombreProducto,
                    CantidadAProducir = i.PendienteDespachar - Math.Max(i.StockDisponible, 0)
                })
                .ToList();

            if (faltantes.Count == 0) return;

            using var frm = new FormPendientesProduccion(idPedido, faltantes, _apiClient);
            frm.ShowDialog(this);
        }

        private async Task<List<PedidoResumenDTO>> ObtenerPedidosPendientesAsync()
        {

            try 
            {
                var lista = await _apiClient.ObtenerListaAsync<PedidoResumenDTO>($"{endpoint}/pendientes");

                if (lista == null) 
                {
                    return null;
                }

                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encuentran pedidos cargados al momento" + ex.Message);
                return null;
            }
            }

        private Task<List<PedidoResumenDTO>> ObtenerPedidosDesdeAsync(int ultimoId)
        {
            return Task.FromResult(new List<PedidoResumenDTO>());
        }

        private async Task<List<PedidoItemDTO>> ObtenerProductosPedidoAsync(int pedidoId)
        {
            return await _apiClient.ObtenerListaAsync<PedidoItemDTO>($"{endpoint}/{pedidoId}/productos");
        }
    }
}
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
                var items = await _apiClient.ObtenerListaAsync<ItemPedidoAceptacionDTO>($"{endpoint}/{idPedido}/aceptacion");
                if (items == null || items.Count == 0)
                {
                    MessageBox.Show("No se encontró el pedido o no tiene productos.",
                        "Aceptar pedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using var frm = new FormAceptarPedido(idPedido, items);
                if (frm.ShowDialog(this) != DialogResult.OK) return;

                var dto = new AceptarPedidoProductosDTO { Items = frm.Aceptaciones };
                var (ok, status, datos, mensaje) = await _apiClient
                    .PostConDatosAsync<ResultadoAceptacionPedidoDTO, AceptarPedidoProductosDTO>($"{endpoint}/{idPedido}/aceptar", dto);

                if (!ok)
                {
                    if (status == HttpStatusCode.Conflict)
                    {
                        // Ya estaba aceptado: si quedó producción pendiente, ofrecer despacharla
                        await OfrecerDespacharPendientesAsync(idPedido, mensaje);
                        return;
                    }

                    MessageBox.Show(mensaje ?? "No se pudo aceptar el pedido.",
                        "Aceptar pedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MostrarResultado(idPedido, datos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al aceptar el pedido: " + ex.Message,
                    "Aceptar pedido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>Si no quedó nada pendiente, el pedido sale de la lista; si no, se muestran los pendientes de producción.</summary>
        private void MostrarResultado(int idPedido, ResultadoAceptacionPedidoDTO? datos)
        {
            if (datos is null || datos.PendientesProduccion.Count == 0)
            {
                pnlPedidos.QuitarPedido(idPedido);
                return;
            }

            using var frm = new FormPendientesProduccion(idPedido, datos.PendientesProduccion, _apiClient);
            frm.ShowDialog(this);
        }

        private async Task OfrecerDespacharPendientesAsync(int idPedido, string? mensaje)
        {
            var respuesta = MessageBox.Show(
                (mensaje ?? "El pedido ya fue aceptado.") + "\n\n¿Despachar los productos pendientes que ya estén en stock?",
                "Pedido #" + idPedido, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes) return;

            var (ok, _, datos, error) = await _apiClient
                .PostConDatosAsync<ResultadoAceptacionPedidoDTO, object?>($"{endpoint}/{idPedido}/despachar-pendientes", null);

            if (!ok)
            {
                MessageBox.Show(error ?? "No se pudieron despachar los pendientes.",
                    "Pedido #" + idPedido, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MostrarResultado(idPedido, datos);
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
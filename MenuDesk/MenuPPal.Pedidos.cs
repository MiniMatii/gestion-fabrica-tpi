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
            if (_cargandoPedidos) return;      // evita cargas superpuestas
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
            tmrPedidos.Stop();   // no solapar consultas
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
                var items = await _apiClient.ObtenerListaAsync<ItemAsignableDTO>($"{endpoint}/{idPedido}/asignables");
                if (items == null || items.Count == 0)
                {
                    MessageBox.Show("No se encontró el pedido o no tiene productos.",
                        "Aceptar pedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch { }
            //    using var frm = new FormAsignarOperarios(idPedido, items);
            //    if (frm.ShowDialog(this) != DialogResult.OK) return;

            //    var dto = new AceptarPedidoDTO { Asignaciones = frm.Asignaciones };
            //    var (ok, status, mensaje) = await _apiClient.PostAsync($"{endpoint}/{idPedido}/aceptar", dto);

            //    if (ok)
            //    {
            //        pnlPedidos.QuitarPedido(idPedido);   
            //        return;
            //    }

            //    MessageBox.Show(mensaje ?? "No se pudo aceptar el pedido.",
            //        "Aceptar pedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            //    if (status == HttpStatusCode.Conflict)
            //        pnlPedidos.QuitarPedido(idPedido);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error al aceptar el pedido: " + ex.Message,
            //        "Aceptar pedido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }



        private async Task<List<PedidoResumenDTO>> ObtenerPedidosPendientesAsync()
        {

            try 
            {
                var lista = await _apiClient.ObtenerListaAsync<PedidoResumenDTO>(endpoint);
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
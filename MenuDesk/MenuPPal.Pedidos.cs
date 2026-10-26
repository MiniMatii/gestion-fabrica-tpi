using System.Linq;
using Alemana.DTOs;

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
                }

                var pedidos = await ObtenerPedidosPendientesAsync();

                if (!pnlPedidos.Visible) return;   // el usuario ya salió de la pantalla

                pnlPedidos.Limpiar();
                pnlPedidos.CargarPedidos(pedidos);
                tmrPedidos.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los pedidos: " + ex.Message);
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
                // Falla momentánea de red: se reintenta en el próximo tick.
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
                var detalle = await ObtenerDetallePedidoAsync(pedidoId);
                using (var frm = new FormPedidoDetalleMini(detalle))
                    frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir el pedido: " + ex.Message);
            }
        }

        // ---- Conectar con tu ApiClient PRUEBAS----

        private async Task<List<PedidoResumenDTO>> ObtenerPedidosPendientesAsync()
        {
            //var lista = Enumerable.Range(1, 20)
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

        private async Task<PedidoDetalleDTO> ObtenerDetallePedidoAsync(int pedidoId)
        {
            return await _apiClient.ObtenerAsync<PedidoDetalleDTO>($"{endpoint}/{pedidoId}");
        }
    }
}
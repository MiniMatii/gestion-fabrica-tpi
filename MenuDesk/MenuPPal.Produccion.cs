using Alemana.DTOs;
using MenuDesk.Controles;

namespace MenuDesk
{
    public partial class MenuPPal
    {
        private ProduccionCardsPanel? _pnlProduccion;
        private bool _cargandoProduccion;
        private string _firmaProduccion = "";


        private void ProduccionPage_CheckedChanged(object sender, EventArgs e)
        {
            bool mostrar = !panelProduccion.Visible;

            panelProduccion.Visible = mostrar;
            panelProduccion.Enabled = mostrar;

            if (mostrar) _ = IniciarProduccion();
            else DetenerProduccion();
        }

        private async Task IniciarProduccion()
        {
            if (_cargandoProduccion) return;
            _cargandoProduccion = true;
            try
            {
                if (_pnlProduccion == null)
                {
                    _pnlProduccion = new ProduccionCardsPanel { Dock = DockStyle.Fill };
                    gestionProduccion.Controls.Add(_pnlProduccion);
                    _pnlProduccion.BringToFront();
                    tmrProduccion.Tick += TmrProduccion_Tick;   // una sola vez
                }

                await RecargarProduccionAsync(mostrarError: true);
                tmrProduccion.Start();
            }
            finally
            {
                _cargandoProduccion = false;
            }
        }

        private void DetenerProduccion()
        {
            tmrProduccion.Stop();
        }

        private async void TmrProduccion_Tick(object? sender, EventArgs e)
        {
            if (_cargandoProduccion || !panelProduccion.Visible) return;
            _cargandoProduccion = true;
            try
            {
                await RecargarProduccionAsync(mostrarError: false);   
            }
            finally
            {
                _cargandoProduccion = false;
            }
        }

        private async Task RecargarProduccionAsync(bool mostrarError)
        {
            try
            {
                var lista = await _apiClient.ObtenerListaAsync<ProduccionPedidoDTO>("ordenproduccion");
                if (lista == null) return;


                var firma = string.Join("|", lista.SelectMany(p =>
                    p.Ordenes.Select(o => $"{p.IdPedido}:{o.IdProd}:{o.EstadoPedido}:{o.IdOperario}")));

                if (firma == _firmaProduccion) return;
                _firmaProduccion = firma;

                _pnlProduccion!.Cargar(lista);
            }
            catch (Exception ex)
            {
                if (mostrarError)
                    MessageBox.Show("No se pudo cargar Producción: " + ex.Message,
                        "Producción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
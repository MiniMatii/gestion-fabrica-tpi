using Alemana.DTOs;
using MenuDesk.Controles;

namespace MenuDesk
{
    public partial class MenuPPal
    {
        private ProduccionCardsPanel? _pnlProduccion;
        private bool _cargandoProduccion;
        private string _firmaProduccion = "";


        private async void ProduccionPage_CheckedChanged(object sender, EventArgs e)
        {
            bool mostrar = !panelProduccion.Visible;

            panelProduccion.Visible = mostrar;
            panelProduccion.Enabled = mostrar;

            if (mostrar) await IniciarProduccion();
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
                    var barra = new Panel { Dock = DockStyle.Top, Height = 48, BackColor = Color.Transparent };
                    var btnNueva = new Button
                    {
                        Text = "+ Nueva orden",
                        Size = new Size(150, 34),
                        Location = new Point(12, 7),
                        FlatStyle = FlatStyle.Flat,
                        BackColor = Color.FromArgb(0, 78, 65),
                        ForeColor = Color.White,
                        Font = new Font("Segoe UI", 10f, FontStyle.Bold)
                    };
                    btnNueva.Click += BtnNuevaOrden_Click;
                    barra.Controls.Add(btnNueva);

                    _pnlProduccion = new ProduccionCardsPanel { Dock = DockStyle.Fill };
                    _pnlProduccion.ConfirmarOrdenClick += PnlProduccion_ConfirmarOrdenClick;
                    _pnlProduccion.FinalizarOrdenClick += PnlProduccion_FinalizarOrdenClick;
                    gestionProduccion.Controls.Add(barra);
                    gestionProduccion.Controls.Add(_pnlProduccion);
                    _pnlProduccion.BringToFront();
                    tmrProduccion.Tick += TmrProduccion_Tick; 
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
                var lista = await _apiClient.ObtenerListaAsync<OrdenProduccionDTO>("ordenproduccion/produccion");
                if (lista == null) return;

                var firma = string.Join("|", lista.Select(o => $"{o.IdProd}:{o.EstadoOrden}:{o.IdOperario}"));

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
    
        private async void BtnNuevaOrden_Click(object? sender, EventArgs e)
        {
            using var frm = new FormNuevaOrden(_apiClient);
            if (frm.ShowDialog(this) != DialogResult.OK) return;
            await ForzarRecargaProduccionAsync();
        }

        private async void PnlProduccion_ConfirmarOrdenClick(int idProd)
        {
            try
            {
                var operarios = await _apiClient.ObtenerListaAsync<OperarioOpcionDTO>($"ordenproduccion/{idProd}/operarios");
                if (operarios == null || operarios.Count == 0)
                {
                    MessageBox.Show("No hay operarios capaces de producir este producto.", "Confirmar orden",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using var frm = new FormElegirOperario(idProd, operarios);
                if (frm.ShowDialog(this) != DialogResult.OK) return;

                var (ok, _, mensaje) = await _apiClient.PostConRespuestaAsync(
                    $"ordenproduccion/{idProd}/confirmar", new ConfirmarOrdenDTO { IdOperario = frm.IdOperario });

                if (!ok)
                    MessageBox.Show(mensaje ?? "No se pudo confirmar la orden.", "Confirmar orden",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                await ForzarRecargaProduccionAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al confirmar la orden: " + ex.Message, "Confirmar orden",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void PnlProduccion_FinalizarOrdenClick(int idProd)
        {
            var r = MessageBox.Show(
                $"¿Finalizar la orden #{idProd}? Se descontará la materia prima de los lotes y se sumará el stock del producto.",
                "Finalizar producción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes) return;

            try
            {
                var (ok, _, mensaje) = await _apiClient.PostConRespuestaAsync($"ordenproduccion/{idProd}/finalizar", new { });
                if (!ok)
                    MessageBox.Show(mensaje ?? "No se pudo finalizar la orden.", "Finalizar producción",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                await ForzarRecargaProduccionAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al finalizar la orden: " + ex.Message, "Finalizar producción",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task ForzarRecargaProduccionAsync()
        {
            _firmaProduccion = "";
            await RecargarProduccionAsync(mostrarError: true);
        }
    }
}

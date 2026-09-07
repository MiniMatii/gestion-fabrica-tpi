using System;
using System.Windows.Forms;
using MenuDesk.Services;
using Alemana.Dominio;
using Alemana.Dominio.Models;

namespace MenuDesk
{
    public partial class OperariosPage : Form
    {
        private readonly ApiClient _apiClient = new ApiClient();

        public OperariosPage()
        {
            this.Text = "Operarios Page";
            this.Size = new System.Drawing.Size(600, 400);

            CargarOperarios();
        }

        private async void CargarOperarios()
        {
            try
            {
                var lista = await _apiClient.ObtenerListaAsync<Operario>("/operarios");

                TextBox txtBox = new TextBox
                {
                    Multiline = true,
                    Dock = DockStyle.Fill,
                    ReadOnly = true
                };
                this.Controls.Add(txtBox);

                foreach (var op in lista ?? new())
                {
                    txtBox.AppendText($"ID: {op.IdOperario} - Nombre: {op.Nombre}\r\n");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
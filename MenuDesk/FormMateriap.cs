using System;
using System.Windows.Forms;
using MenuDesk.Services;
using Alemana.Dominio;
using Alemana.Dominio.Models;

namespace MenuDesk
{
    public partial class FormMateriap : Form
    {
        private readonly ApiClient _apiClient = new ApiClient();

        public FormMateriap()
        {
            this.Text = "Materia Prima";
            this.Size = new System.Drawing.Size(600, 400);
            CargarDatosMateriaPrima();
        }

        private async void CargarDatosMateriaPrima()
        {
            try
            {
                var listaEmpleados = await _apiClient.ObtenerListaAsync<Materiap>("materiap");
                if (listaEmpleados != null && listaEmpleados.Count > 0)
                {
                    TextBox txtResultados = new TextBox
                    {
                        Multiline = true,
                        ScrollBars = ScrollBars.Vertical,
                        Dock = DockStyle.Fill,
                        ReadOnly = true
                    };

                    this.Controls.Clear();
                    this.Controls.Add(txtResultados);
                    txtResultados.BringToFront();

                    foreach (var mp in listaEmpleados)
                    {
                        txtResultados.AppendText($"ID: {mp.IdMateriaP} - Nombre: {mp.Nombre} - Unidad: {mp.Unidad}\r\n");
                    }
                }
                else
                {
                    MessageBox.Show("La API no devolvió registros.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
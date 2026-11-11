using Alemana.API;
using Alemana.DTOs;
using KimTools.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;


namespace MenuDesk
{
    public partial class MiniMenuCiudad : KtWindow
    {
        private readonly ApiClient _apiClient = new ApiClient();

        public MiniMenuCiudad()
        {
            InitializeComponent();
        }

        private void ktButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void ktButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = this.WindowState == FormWindowState.Maximized
            ? FormWindowState.Normal
            : FormWindowState.Maximized;
        }

        private void ktButton3_Click(object sender, EventArgs e)
        {

            this.Visible = false; //con close y dispose se produce excepción de un componente que quiere usar thread abort

        }

        private void altaCiudadButton_Click(object sender, EventArgs e)
        {
            navBarCiudades.SelectedTab = altaCiudadPage;

        }

        private void EliminarCiudad_Click(object sender, EventArgs e)
        {
            navBarCiudades.SelectedTab = eliminarCiudadPage;
        }

        private async void buttonGuardarReceta_Click(object sender, EventArgs e)
        {
            try
            {
                string endpoint = "ciudades";
                CiudadesDTO nC = new CiudadesDTO();

                nC.CodPostal = Convert.ToInt32(textBoxCodP.Text);
                nC.NombreCiudad = textBoxNombreAC.Text;

                await _apiClient.PostAsync(endpoint, nC);
                MessageBox.Show("Ciudad guardada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con el servidor: \n{ex.Message}\n ", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        private async Task CargarCiudadesEnGrilla()
        {
            string endpoint = "ciudades";
            var listado = await _apiClient.ObtenerListaAsync<CiudadesDTO>(endpoint);

            if (listado != null)
            {
                tablaEC.DataSource = listado;
            }
        }



        private async void MiniMenuCiudad_Load(object sender, EventArgs e)
        {
            await CargarCiudadesEnGrilla();
        }





        private async void buttonActualizarEC_Click(object sender, EventArgs e)
        {
            await CargarCiudadesEnGrilla();
        }

        private async void buttonECiudad_Click(object sender, EventArgs e)
        {
            try
            {
                var fila = tablaEC.CurrentRow;
                if (fila == null)
                {
                    MessageBox.Show("Seleccioná una ciudad de la tabla.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int codPostal = Convert.ToInt32(fila.Cells["codPostal"].Value);

                var eliminado = await _apiClient.DeleteAsync($"ciudades/{codPostal}");
                if (eliminado)
                {
                    MessageBox.Show("Ciudad eliminada", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar la ciudad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la ciudad: {ex.Message}", "Error de eliminación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

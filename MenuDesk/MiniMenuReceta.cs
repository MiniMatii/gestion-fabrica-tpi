using Alemana.API;
using Alemana.DTOs;
using KimTools.WinForms;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace MenuDesk
{
    public partial class MiniMenuReceta : KtWindow
    {
        private readonly ApiClient _apiClient = new ApiClient();

        public MiniMenuReceta()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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

        //acá se cargan las grillas
        private async void MiniMenuReceta_Load(object sender, EventArgs e)
        {
            await CargarRecetasEnGrilla();

        }
        //listado
        private async Task CargarRecetasEnGrilla()
        {
            string endpoint = "Recetas";
            var listado = await _apiClient.ObtenerListaAsync<RecetaProductoDTO>(endpoint);

            if (listado != null)
            {
                tablaMR.DataSource = listado;
                tablaER.DataSource = listado;

            }
        }

        private void altaRecetaButton_Click(object sender, EventArgs e)
        {
            navBarRecetas.SelectedTab = altaRecetaPage;

        }

        private void ModificarReceta_Click(object sender, EventArgs e)
        {
            navBarRecetas.SelectedTab = modificarRecetaPage;
        }

        private void EliminarReceta_Click(object sender, EventArgs e)
        {
            navBarRecetas.SelectedTab = eliminarRecetaPage;
        }



        //Guardar nueva receta  FALTA MATERIA PRIMA 

        private async void buttonGuardarReceta_Click(object sender, EventArgs e)
        {
            try
            {
                string endpoint = "Recetas";
                RecetaProductoDTO r = new RecetaProductoDTO();
                r.Descripcion = textBoxDescAR.Text;
                await _apiClient.PostAsync(endpoint, r);
                MessageBox.Show("Receta guardada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con el servidor: \n{ex.Message}\n ", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //que traiga los datos actuales de la receta
        private void tablaMR_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var fila = tablaMR.Rows[e.RowIndex];
            textBoxDescMR.Text = fila.Cells["descMR"].Value?.ToString();

        }


        //guardar modificación de receta
        private async void guardarMR_Click(object sender, EventArgs e)
        {
            try
            {
                string endpoint = "Recetas";
                var rE = tablaMR.CurrentRow;

                if (rE != null)
                {
                    var rmodif = new RecetaProductoDTO();
                    rmodif.IdReceta = Convert.ToInt32(rE.Cells["idMR"].Value);
                    rmodif.Descripcion = textBoxDescMR.Text;

                    await _apiClient.PutAsync(endpoint, rmodif); //sino patch(? tendría que crear el endpoint
                    MessageBox.Show("Cambios de guardado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al ejecutar el guardado de las modificaciones de la receta: {ex.Message}", "Error de Guardado", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        //guardar eliminar receta
        private async void buttonGuardarER_Click(object sender, EventArgs e)
        {
            try
            {
                string endpoint = "Recetas";
                var rE = tablaER.CurrentRow;
                if (rE != null)
                {
                    var rElim = new RecetaProductoDTO();
                    rElim.IdReceta = Convert.ToInt32(rE.Cells["idER"].Value);

                    var eliminado = await _apiClient.DeleteAsync($"{endpoint}/{rElim.IdReceta}");
                    if (eliminado)
                        MessageBox.Show("Receta eliminada", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("No se pudo eliminar la receta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la receta: {ex.Message}", "Error de eliminación", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        //botón de actualizar las tablas luego de modificaciones/eliminaciones
        private async void buttonActualizarER_Click(object sender, EventArgs e)
        {
            await CargarRecetasEnGrilla();
        }
    }
}

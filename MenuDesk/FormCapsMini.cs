using Alemana.API;
using Alemana.DTOs;
using KimTools.WinForms;



namespace MenuDesk
{
    public partial class FormCapsMini : KtWindow
    {
        private readonly ApiClient _apiClient = new ApiClient();

        const string endpoint = "capacidad";

        public FormCapsMini()
        {
            InitializeComponent();
        }

        private async void pageEliminarCap_Click(object sender, EventArgs e)
        {
            pagesCaps.Page = bajaCaps;
            await CargarDatosCapacidadEnGrillaAsync();
        }


        private async void acceptCap_Click(object sender, EventArgs e)
        {


            try
            {
                var nCap = new CapacidadDTO();

                nCap.NomCapacidad = textMiniCap.Text;
                nCap.DescCapacidad = textMiniCapDesc.Text;


                await _apiClient.PostAsync(endpoint, nCap);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con el servidor:\n {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async Task CargarDatosCapacidadEnGrillaAsync()
        {
            try
            {

                var listaDatos = await _apiClient.ObtenerListaAsync<CapacidadDTO>(endpoint);

                if (listaDatos != null)
                {
                    ktTablaCaps.DataSource = listaDatos;
                    ktTablaCaps.Columns["IdCap"].HeaderText = "ID";
                    ktTablaCaps.Columns["NomCapacidad"].HeaderText = "Nombre";
                    ktTablaCaps.Columns["DescCapacidad"].HeaderText = "Descripcion";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void eliminarCapsButton_Click(object sender, EventArgs e)
        {
            try
            {
                int idEliminar = Convert.ToInt32(ktTablaCaps.CurrentRow.Cells["IdCap"].Value);
                bool eliminado = await _apiClient.DeleteAsync($"capacidad/{idEliminar}");

                if (eliminado)
                    MessageBox.Show("Capacidad eliminada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("No se pudo eliminar la capacidad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la capacidad: {ex.Message}", "Error de Eliminación", MessageBoxButtons.OK);
            }
        }
    }
}

using Alemana.DTOs;
using KimTools.WinForms;
using Alemana.API;
using System.Threading.Tasks;

namespace MenuDesk
{
    public partial class FormProvMini : KtWindow
    {
        const string endpoint = "proveedores";

        private readonly ApiClient _apiClient = new ApiClient();

        public FormProvMini()
        {
            InitializeComponent();
        }

        private async void acceptProv_Click(object sender, EventArgs e)
        {
            await cargarProveedorMini();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private async Task cargarProveedorMini()
        {
            try
            {


                var nProv = new ProveedorDTO();
                nProv.Cuit = textCuit.Text;
                nProv.RazonSocial = textRSocial.Text;
                nProv.Nombre = textNombreProv.Text;

                await _apiClient.PostAsync(endpoint, nProv);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el proveedor: {ex.Message}", "Error de Alta", MessageBoxButtons.OK);
            }

        }

        private async void buttonEliminarProv_Click(object sender, EventArgs e)
        {
            pagesProvedores.Page = pageEliminarProv;
            await CargarDatosEnGrillaAsync();
        }



        private async Task CargarDatosEnGrillaAsync()
        {
            try
            {

                var listaDatos = await _apiClient.ObtenerListaAsync<ProveedorDTO>(endpoint);

                if (listaDatos != null)
                {
                    ktTablaProveedoresLotes.DataSource = listaDatos;
                    ktTablaProveedoresLotes.Columns["IdProveedor"].HeaderText = "IdProveedor";
                    ktTablaProveedoresLotes.Columns["razonSocial"].HeaderText = "RazonSocial";
                    ktTablaProveedoresLotes.Columns["Cuit"].HeaderText = "CUIT";
                    ktTablaProveedoresLotes.Columns["Nombre"].HeaderText = "Nombre";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void eliminarProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                int idEliminar = Convert.ToInt32(ktTablaProveedoresLotes.CurrentRow.Cells["IdProveedor"].Value);
                bool eliminado = await _apiClient.DeleteAsync($"proveedores/{idEliminar}");

                if (eliminado)
                    MessageBox.Show("Proveedor eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("No se pudo eliminar el proveedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el proveedor: {ex.Message}", "Error de Eliminación", MessageBoxButtons.OK);
            }

        }

        private void volverMiniProv_Click(object sender, EventArgs e)
        {
            pagesProvedores.Page = altaMiniProv;
        }

    }
}

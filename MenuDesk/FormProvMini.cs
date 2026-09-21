using Alemana.DTOs;
using KimTools.WinForms;
using MenuDesk.Services;
using System.Threading.Tasks;

namespace MenuDesk
{
    public partial class FormProvMini : KtWindow
    {

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

                string endpoint = "proveedores";
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
    }
}

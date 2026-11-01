using Alemana.API;
using Alemana.DTOs;
using KimTools.WinForms;


namespace MenuDesk
{
    public partial class Login : KtWindow
    {
        private readonly ApiClient _api;

        public Login(ApiClient api)
        {
            InitializeComponent();
            _api = api;
        }

        private async void btnIngresar_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            string usuario = txtUsuario.Text.Trim();
            string clave = txtClave.Text;

            if (usuario.Length == 0 || clave.Length == 0)
            {
                MostrarError("Ingresá usuario y contraseña.");
                return;
            }

            btnIngresar.Enabled = false;
            try
            {
                var res = await _api.LoginAsync(new LoginDTO { Usuario = usuario, Clave = clave });

                if (res is null)
                {
                    MostrarError("Usuario o contraseña incorrectos.");
                    txtClave.Clear();
                    txtClave.Focus();
                    return;               
                }

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MostrarError("No se pudo conectar con el servidor.\n" + ex.Message);
            }
            finally
            {
                btnIngresar.Enabled = true;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void MostrarError(string mensaje)
        {
            lblError.Text = mensaje;
            lblError.Visible = true;
        }


    }
}

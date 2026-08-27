using Alemana.DTOs;
using KimTools;
using KimTools.WinForms;
using MenuDesk.Services;
using System;
using System.Windows.Forms;

namespace MenuDesk
{
    public partial class MenuPPal : KtWindow
    {

        private readonly ApiClient _apiClient = new ApiClient();

        public MenuPPal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //panelLotes.Visible = false;
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
            this.Close();
        }

        private void LotesPage_CheckedChanged(object sender, EventArgs e)
        {
            voidPanel.Visible = !(voidPanel.Visible);
            navLotes.Visible = !(navLotes.Visible);
            panelLotes.Visible = !(panelLotes.Visible);

        }

        private async void altaLote_Click(object sender, EventArgs e)
        {
            
            ktPages1.SelectedTab = tabPage1;
            await CargarDatosEnGrillaAsync();
        }

        private void ktLabel2_Click(object sender, EventArgs e)
        {

        }

        private async Task CargarDatosEnGrillaAsync()
        {
            try
            {
                string endpoint = "proveedores";

                var listaDatos = await _apiClient.ObtenerListaAsync<ProveedorDTO>(endpoint);

                if (listaDatos != null)
                {

                    ktTablaLotes.DataSource = listaDatos;

                    ktTablaLotes.Columns["IdProveedor"].Visible = false;
                    ktTablaLotes.Columns["razonSocial"].HeaderText = "RazonSocial";
                    ktTablaLotes.Columns["Cuit"].HeaderText = "CUIT";
                    ktTablaLotes.Columns["Nombre"].HeaderText = "Nombre";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

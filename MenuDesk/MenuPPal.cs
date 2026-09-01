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
            SelectUnidad.Items.AddRange(new string[] { "Kilogramos (kg)", "Gramos (g)", "Litros (L)", "Mililitros (ml)" });
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
            panelLotes.Visible = !(panelLotes.Visible);
            panelLotes.Enabled = !(panelLotes.Enabled);
            ConfigurarScrollbar();

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

                    ktTablaLotes.Columns["IdProveedor"].DisplayIndex = 3;
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

        private void ConfigurarScrollbar()
        {



            //int alturaContenido = altaLoteSubPage.Controls
            //    .OfType<Control>()
            //    .Sum(c => c.Height);
            //int alturaVisible = altaLoteSubPage.ClientSize.Height;

            //ktScrollbar1.Minimum = 0;
            //ktScrollbar1.Maximum = Math.Max(0, alturaContenido - alturaVisible);
            //ktScrollbar1.LargeChange = alturaVisible;
            //ktScrollbar1.SmallChange = 40;
            //ktScrollbar1.Value = 0;
        }

        private void ktScrollbar1_Scroll(object sender, KimTools.WinForms.KtScrollbar.ScrollEventArgs e)
        {
            altaLoteSubPage.AutoScrollPosition = new Point(0, e.Value);
        }
    }
}

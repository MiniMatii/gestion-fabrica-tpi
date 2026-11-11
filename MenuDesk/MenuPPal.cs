using Alemana.DTOs;
using KimTools;
using KimTools.WinForms;
using Alemana.API;
using System;
using System.Windows.Forms;

namespace MenuDesk
{
    public partial class MenuPPal : KtWindow
    {
        private ApiClient _apiClient = null!;

        public MenuPPal()
        {
            InitializeComponent();
            AplicarEstiloTabla(tablaMProd, tablaEP);
            hudLateral.Background = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            hudLateral.BackColor = Color.FromArgb(0, 78, 65);
            hudLateral.BackgroundImage = Properties.Resources.backgroundAleman_340x1179;
            hudLateral.BackgroundImageLayout = ImageLayout.None;
        }
        public MenuPPal(ApiClient api) : this()
        {
            _apiClient = api;
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
            Environment.Exit(0);

        }

    }
}

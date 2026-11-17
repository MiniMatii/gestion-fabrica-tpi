using Alemana.DTOs;
using KimTools.WinForms;
using Alemana.API;


namespace MenuDesk
{
    public partial class MenuPPal : KtWindow
    {
        private ApiClient _apiClient = null!;

        public MenuPPal()
        {
            InitializeComponent();
            ktTablaSucursales.CellFormatting += ktTablaSucursales_CellFormatting;
            AplicarEstiloTabla(tablaMProd, tablaEP, ktTablaOperarios, ktTablaModOp, ktTablaSucursales, empktTable4, sucktTable2, tableCapacidadRequeridaProducto, ktTablaLotesEliminar);
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

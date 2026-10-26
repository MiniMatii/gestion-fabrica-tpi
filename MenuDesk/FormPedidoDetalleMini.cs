using Alemana.DTOs;
using KimTools.WinForms;

namespace MenuDesk
{
    public partial class FormPedidoDetalleMini : KtWindow
    {
        public FormPedidoDetalleMini(PedidoDetalleDTO pedido)
        {
            InitializeComponent();
            Text = "Pedido #" + pedido.Id;
            lblFecha.Text = "Ingreso: " + pedido.FechaIngreso.ToString("dd/MM/yyyy HH:mm");
            dgvDetalle.DataSource = pedido.Items;
        }
    }
}

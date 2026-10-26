using System;
using System.Linq;
using System.Windows.Forms;
using Alemana.DTOs;

namespace MenuDesk.Controles
{
    public partial class PedidoCard : UserControl
    {
        public int PedidoId { get; private set; }
        public event Action<int> VerPedidoClick;

        public PedidoCard()
        {

            InitializeComponent();
            DoubleBuffered = true;
        }

        public void Cargar(PedidoResumenDTO pedido)
        {
            PedidoId = pedido.IdPedido;
            lblNumero.Text = "Pedido #" + pedido.IdPedido;
            lblFecha.Text = "Ingreso: " + pedido.FechaPedido.ToString("dd/MM/yyyy HH:mm");
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            MessageBox.Show("btnVer click");
            var handler = VerPedidoClick;
            if (handler != null) handler(PedidoId);
        }
    }
}
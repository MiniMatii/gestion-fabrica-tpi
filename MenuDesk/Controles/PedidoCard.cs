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
        public event Action<int>? AceptarClick;

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
            VerPedidoClick?.Invoke(PedidoId);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            AceptarClick?.Invoke(PedidoId);
        }
    }
}
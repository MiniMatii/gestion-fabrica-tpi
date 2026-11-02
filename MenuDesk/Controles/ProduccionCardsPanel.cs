using Alemana.DTOs;

namespace MenuDesk.Controles
{
    public class ProduccionCardsPanel : FlowLayoutPanel
    {
        public ProduccionCardsPanel()
        {
            DoubleBuffered = true;
            AutoScroll = true;
            WrapContents = true;
        }

        public void Cargar(List<ProduccionPedidoDTO> pedidos)
        {
            SuspendLayout();
            try
            {
                foreach (Control c in Controls) c.Dispose();
                Controls.Clear();

                foreach (var p in pedidos)
                    Controls.Add(new ProduccionCard(p));
            }
            finally
            {
                ResumeLayout(true);
            }
        }
    }
}
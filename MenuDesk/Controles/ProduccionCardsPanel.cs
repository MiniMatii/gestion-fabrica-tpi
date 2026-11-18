using Alemana.DTOs;

namespace MenuDesk.Controles
{
    public class ProduccionCardsPanel : FlowLayoutPanel
    {
        public event Action<int>? ConfirmarOrdenClick;
        public event Action<int>? FinalizarOrdenClick;

        public ProduccionCardsPanel()
        {
            DoubleBuffered = true;
            AutoScroll = true;
            WrapContents = true;
            FlowDirection = FlowDirection.LeftToRight;
        }

        public void Cargar(List<OrdenProduccionDTO> ordenes)
        {
            SuspendLayout();
            try
            {
                foreach (Control c in Controls) c.Dispose();
                Controls.Clear();

                foreach (var o in ordenes)
                {
                    var card = new ProduccionCard(o);
                    card.ConfirmarClick += id => ConfirmarOrdenClick?.Invoke(id);
                    card.FinalizarClick += id => FinalizarOrdenClick?.Invoke(id);
                    Controls.Add(card);
                }
            }
            finally
            {
                ResumeLayout(true);
            }
        }
    }
}

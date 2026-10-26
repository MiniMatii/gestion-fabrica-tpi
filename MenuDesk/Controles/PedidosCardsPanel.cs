using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Alemana.DTOs;

namespace MenuDesk.Controles
{
    public class PedidosCardsPanel : FlowLayoutPanel
    {
        private readonly Dictionary<int, PedidoCard> _tarjetas = new Dictionary<int, PedidoCard>();

        public event Action<int> VerPedidoClick;

        public PedidosCardsPanel()
        {
            AutoScroll = true;
            WrapContents = true;
            FlowDirection = FlowDirection.LeftToRight;
            DoubleBuffered = true;
        }

        public int UltimoIdCargado
        {
            get { return _tarjetas.Count == 0 ? 0 : _tarjetas.Keys.Max(); }
        }

        public void CargarPedidos(IEnumerable<PedidoResumenDTO> pedidos)
        {
            bool cargaInicial = _tarjetas.Count == 0;

            var nuevos = pedidos
                .Where(p => !_tarjetas.ContainsKey(p.IdPedido))
                .OrderByDescending(p => p.FechaPedido)
                .ToList();

            if (nuevos.Count == 0) return;

            var tarjetasNuevas = new List<PedidoCard>(nuevos.Count);
            foreach (var p in nuevos)
            {
                var card = new PedidoCard();
                card.Cargar(p);
                card.VerPedidoClick += id =>
                {
                    var handler = VerPedidoClick;
                    if (handler != null) handler(id);
                };
                _tarjetas.Add(p.IdPedido, card);
                tarjetasNuevas.Add(card);
            }

            SuspendLayout();
            try
            {
                Controls.AddRange(tarjetasNuevas.ToArray());

                if (!cargaInicial)
                {
                    for (int i = tarjetasNuevas.Count - 1; i >= 0; i--)
                        Controls.SetChildIndex(tarjetasNuevas[i], 0);
                }
            }
            finally
            {
                ResumeLayout(true);
            }
        }

        public void QuitarPedido(int pedidoId)
        {
            PedidoCard card;
            if (!_tarjetas.TryGetValue(pedidoId, out card)) return;

            _tarjetas.Remove(pedidoId);
            Controls.Remove(card);
            card.Dispose();
        }

        public void Limpiar()
        {
            SuspendLayout();
            try
            {
                foreach (var card in _tarjetas.Values)
                {
                    Controls.Remove(card);
                    card.Dispose();
                }
                _tarjetas.Clear();
            }
            finally
            {
                ResumeLayout(true);
            }
        }
    }
}
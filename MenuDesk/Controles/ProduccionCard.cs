using Alemana.DTOs;

namespace MenuDesk.Controles
{
    public class ProduccionCard : UserControl
    {
        private static readonly Color Fondo = Color.FromArgb(30, 41, 59);
        private static readonly Color Borde = Color.FromArgb(51, 65, 85);
        private static readonly Color Texto = Color.White;
        private static readonly Color TextoSuave = Color.FromArgb(148, 163, 184);
        private static readonly Color Asignado = Color.FromArgb(52, 211, 153);
        private static readonly Color SinAsignar = Color.FromArgb(251, 191, 36);


        public ProduccionCard(ProduccionPedidoDTO pedido)
        {
            DoubleBuffered = true;
            Width = 340;
            BackColor = Fondo;
            Margin = new Padding(8);

            int y = 12;

            Controls.Add(Etiqueta(
                pedido.IdPedido == 0 ? "Órdenes sin pedido" : $"Pedido #{pedido.IdPedido}",
                new Font("Segoe UI", 12f, FontStyle.Bold), Texto, 14, ref y, 26));

            Controls.Add(Etiqueta(
                $"Ingreso: {pedido.FechaPedido:dd/MM/yyyy}   Estimada: {pedido.FechaEstimada:dd/MM/yyyy}",
                new Font("Segoe UI", 8.5f), TextoSuave, 14, ref y, 24));

            foreach (var o in pedido.Ordenes)
            {
                Controls.Add(Etiqueta(
                    $"{o.NombreProducto}  ×{o.CantidadRequerida}",
                    new Font("Segoe UI", 10f, FontStyle.Bold), Texto, 14, ref y, 22));

                bool cubierto = o.EstadoPedido == "Cubierto";
                bool asignado = !string.IsNullOrEmpty(o.NombreOperario);

                string textoOperario = cubierto ? "Cubierto con stock"
                                     : asignado ? $"Operario: {o.NombreOperario}"
                                     : "Sin asignar";

                Color colorOperario = cubierto ? Color.FromArgb(96, 165, 250)     
                                    : asignado ? Color.FromArgb(52, 211, 153)     
                                    : Color.FromArgb(251, 191, 36);

                Controls.Add(Etiqueta(textoOperario, new Font("Segoe UI", 9f), colorOperario, 14, ref y, 20));
            }

            Height = y + 8;
        }

        private Label Etiqueta(string texto, Font fuente, Color color, int x, ref int y, int alto)
        {
            var lbl = new Label
            {
                Text = texto,
                Font = fuente,
                ForeColor = color,
                BackColor = Color.Transparent,
                AutoEllipsis = true,
                Location = new Point(x, y),
                Size = new Size(Width - x - 12, alto)
            };
            y += alto;
            return lbl;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using var pen = new Pen(Borde);
            e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
        }
    }
}
using Alemana.DTOs;

namespace MenuDesk.Controles
{
    public class ProduccionCard : UserControl
    {
        public ProduccionCard(ProduccionPedidoDTO pedido)
        {
            DoubleBuffered = true;
            Width = 340;
            BackColor = Color.White;
            Margin = new Padding(8);
            Padding = new Padding(12);

            int y = 10;

            var titulo = new Label
            {
                Text = $"Pedido #{pedido.IdPedido}",
                Font = new Font("Segoe UI", 12f, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(12, y)
            };
            Controls.Add(titulo);
            y += 30;

            var fechas = new Label
            {
                Text = $"Ingreso: {pedido.FechaPedido:dd/MM/yyyy}   Estimada: {pedido.FechaEstimada:dd/MM/yyyy}",
                ForeColor = Color.DimGray,
                AutoSize = true,
                Location = new Point(12, y)
            };
            Controls.Add(fechas);
            y += 30;

            foreach (var o in pedido.Ordenes)
            {
                var producto = new Label
                {
                    Text = $"{o.NombreProducto}  ×{o.CantidadRequerida}",
                    Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                    AutoSize = true,
                    Location = new Point(12, y)
                };
                Controls.Add(producto);
                y += 22;

                var asignado = !string.IsNullOrEmpty(o.NombreOperario);
                var operario = new Label
                {
                    Text = asignado ? $"Operario: {o.NombreOperario}" : "Sin asignar",
                    ForeColor = asignado ? Color.SeaGreen : Color.DarkOrange,
                    AutoSize = true,
                    Location = new Point(24, y)
                };
                Controls.Add(operario);
                y += 28;
            }

            Height = y + 10;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using var pen = new Pen(Color.Gainsboro);
            e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
        }
    }
}
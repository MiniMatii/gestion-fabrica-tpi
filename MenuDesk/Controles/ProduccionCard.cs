using Alemana.DTOs;

namespace MenuDesk.Controles
{
    public class ProduccionCard : UserControl
    {
        private static readonly Color Fondo = Color.FromArgb(30, 41, 59);
        private static readonly Color Borde = Color.FromArgb(51, 65, 85);
        private static readonly Color Texto = Color.White;
        private static readonly Color TextoSuave = Color.FromArgb(148, 163, 184);

        public int IdProd { get; }
        public event Action<int>? ConfirmarClick;
        public event Action<int>? FinalizarClick;

        public ProduccionCard(OrdenProduccionDTO o)
        {
            IdProd = o.IdProd;
            DoubleBuffered = true;
            Width = 340;
            BackColor = Fondo;
            Margin = new Padding(8);

            int y = 12;
            bool pendiente = o.EstadoOrden == "Pendiente";
            bool enProceso = o.EstadoOrden == "En Proceso";

            Controls.Add(Etiqueta($"Orden #{o.IdProd}", new Font("Segoe UI", 12f, FontStyle.Bold), Texto, 14, ref y, 26));
            Controls.Add(Etiqueta(
                $"Creada: {o.FechaCreacion:dd/MM/yyyy}   Estimada: {(o.FechaEstimada.HasValue ? o.FechaEstimada.Value.ToString("dd/MM/yyyy") : "-")}",
                new Font("Segoe UI", 8.5f), TextoSuave, 14, ref y, 24));
            Controls.Add(Etiqueta($"{o.NombreProducto}  ×{o.CantidadAproducir}",
                new Font("Segoe UI", 10f, FontStyle.Bold), Texto, 14, ref y, 22));

            bool asignado = !string.IsNullOrEmpty(o.NombreOperario);
            Controls.Add(Etiqueta(asignado ? $"Operario: {o.NombreOperario}" : "Sin operario asignado",
                new Font("Segoe UI", 9f),
                asignado ? Color.FromArgb(52, 211, 153) : Color.FromArgb(251, 191, 36), 14, ref y, 20));

            Controls.Add(Etiqueta(o.EstadoOrden, new Font("Segoe UI", 9f, FontStyle.Bold),
                enProceso ? Color.FromArgb(96, 165, 250) : Color.FromArgb(251, 191, 36), 14, ref y, 20));

            if (pendiente || enProceso)
            {
                var btn = new Button
                {
                    Text = pendiente ? "Confirmar (asignar operario)" : "Finalizar producción",
                    Location = new Point(14, y + 4),
                    Size = new Size(Width - 28, 32),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.FromArgb(173, 151, 98),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 9.5f, FontStyle.Bold)
                };
                btn.Click += (_, _) =>
                {
                    if (pendiente) ConfirmarClick?.Invoke(IdProd);
                    else FinalizarClick?.Invoke(IdProd);
                };
                Controls.Add(btn);
                y += 40;
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

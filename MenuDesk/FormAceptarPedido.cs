using Alemana.DTOs;

namespace MenuDesk
{
    /// <summary>
    /// Menú para aceptar un pedido: por cada producto, cuánto se acepta (0 a lo pedido).
    /// </summary>
    public class FormAceptarPedido : Form
    {
        private readonly List<(ItemPedidoAceptacionDTO Item, NumericUpDown Cantidad)> _filas = new();

        /// <summary>Cantidades aceptadas, disponibles al cerrar con Confirmar.</summary>
        public List<AceptacionItemDTO> Aceptaciones { get; private set; } = new();

        public FormAceptarPedido(int idPedido, List<ItemPedidoAceptacionDTO> items)
        {
            Text = $"Aceptar pedido #{idPedido}";
            Width = 640;
            Height = 170 + items.Count * 44;
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            var lblInfo = new Label
            {
                Text = "Indicá cuánto aceptás de cada producto. Lo que haya en stock se despacha; " +
                       "lo que falte queda pendiente de producción. Lo que no aceptes se descarta.",
                AutoSize = false,
                Dock = DockStyle.Top,
                Height = 60,
                Padding = new Padding(12, 12, 12, 0)
            };

            var grilla = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = items.Count + 1,
                Padding = new Padding(12, 4, 12, 4)
            };
            grilla.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
            grilla.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            grilla.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));
            grilla.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));

            var negrita = new Font(Font, FontStyle.Bold);
            grilla.Controls.Add(new Label { Text = "Producto", AutoSize = true, Font = negrita }, 0, 0);
            grilla.Controls.Add(new Label { Text = "Pedido", AutoSize = true, Font = negrita }, 1, 0);
            grilla.Controls.Add(new Label { Text = "Stock", AutoSize = true, Font = negrita }, 2, 0);
            grilla.Controls.Add(new Label { Text = "Aceptar", AutoSize = true, Font = negrita }, 3, 0);

            for (int i = 0; i < items.Count; i++)
            {
                var item = items[i];
                var fila = i + 1;

                var cantidad = new NumericUpDown
                {
                    Minimum = 0,
                    Maximum = item.CantidadPedida,
                    DecimalPlaces = 0,
                    Value = item.CantidadPedida,
                    Width = 90,
                    Anchor = AnchorStyles.Left
                };

                grilla.Controls.Add(new Label { Text = item.NombreProducto, AutoSize = true, Anchor = AnchorStyles.Left }, 0, fila);
                grilla.Controls.Add(new Label { Text = item.CantidadPedida.ToString(), AutoSize = true, Anchor = AnchorStyles.Left }, 1, fila);
                grilla.Controls.Add(new Label { Text = item.StockDisponible.ToString(), AutoSize = true, Anchor = AnchorStyles.Left }, 2, fila);
                grilla.Controls.Add(cantidad, 3, fila);

                _filas.Add((item, cantidad));
            }

            var btnConfirmar = new Button { Text = "Confirmar", AutoSize = true };
            btnConfirmar.Click += BtnConfirmar_Click;

            var btnCancelar = new Button { Text = "Cancelar", AutoSize = true, DialogResult = DialogResult.Cancel };
            CancelButton = btnCancelar;

            var pie = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                FlowDirection = FlowDirection.RightToLeft,
                Height = 52,
                Padding = new Padding(12, 8, 12, 8)
            };
            pie.Controls.Add(btnCancelar);
            pie.Controls.Add(btnConfirmar);

            Controls.Add(grilla);
            Controls.Add(lblInfo);
            Controls.Add(pie);
        }

        private void BtnConfirmar_Click(object? sender, EventArgs e)
        {
            Aceptaciones = _filas
                .Select(f => new AceptacionItemDTO
                {
                    IdProducto = f.Item.IdProducto,
                    CantidadAceptada = (int)f.Cantidad.Value
                })
                .ToList();

            DialogResult = DialogResult.OK;
        }
    }
}

using Alemana.DTOs;

namespace MenuDesk
{
    /// <summary>
    /// Gestión de un pedido: por producto se fija la cantidad aceptada (total) y cuánto se despacha ahora.
    /// El despacho no puede superar lo aceptado sin despachar ni el stock actual.
    /// </summary>
    public class FormGestionPedido : Form
    {
        private sealed class Fila
        {
            public ItemPedidoDespachoDTO Item = null!;
            public NumericUpDown Aceptar = null!;
            public NumericUpDown Despachar = null!;
            public Label LblMax = null!;
        }

        private readonly List<Fila> _filas = new();
        private readonly ComboBox _cmbEmpleado = new() { DropDownStyle = ComboBoxStyle.DropDownList, Width = 260 };

        public List<AceptacionItemDTO> Aceptaciones { get; private set; } = new();
        public List<DespachoItemDTO> Despachos { get; private set; } = new();
        public int IdEmpleado { get; private set; }

        /// <param name="empleados">Empleados que pueden figurar como quien despacha.</param>
        /// <param name="idEmpleadoActual">Preselecciona al empleado logueado (si lo es).</param>
        public FormGestionPedido(int idPedido, List<ItemPedidoDespachoDTO> items,
                                 List<EmpleadoDTO> empleados, int? idEmpleadoActual)
        {
            Text = $"Pedido #{idPedido}";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = new Size(820, Math.Min(150 + items.Count * 42 + 80, 620));

            var lblInfo = new Label
            {
                Text = "Aceptá cuánto vas a entregar de cada producto (no puede bajar de lo ya despachado) y " +
                       "cuánto despachás ahora (hasta el stock). Lo aceptado sin despachar queda pendiente.",
                Dock = DockStyle.Top,
                Height = 56,
                Padding = new Padding(12, 10, 12, 0)
            };

            var grilla = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                ColumnCount = 7,
                Padding = new Padding(12, 4, 12, 4)
            };
            grilla.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
            for (int i = 0; i < 6; i++) grilla.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.6f));

            var negrita = new Font(Font, FontStyle.Bold);
            foreach (var h in new[] { "Producto", "Pedido", "Despachado", "Stock", "Aceptar total", "Despachar ahora", "Máx. ahora" })
                grilla.Controls.Add(new Label { Text = h, AutoSize = true, Font = negrita });

            foreach (var item in items)
            {
                var f = new Fila { Item = item };

                int piso = item.CantidadDespachada;
                // lo aceptado se descuenta del stock: se puede subir hasta lo ya aceptado + stock disponible
                int tope = Math.Min(item.CantidadSolicitada, item.CantidadAceptada + Math.Max(item.StockDisponible, 0));

                f.Aceptar = new NumericUpDown
                {
                    Minimum = piso,
                    Maximum = tope,
                    Value = Math.Clamp(tope, piso, tope),
                    Width = 80
                };
                f.Despachar = new NumericUpDown { Minimum = 0, Maximum = 0, Width = 80 };
                f.LblMax = new Label { AutoSize = true, Anchor = AnchorStyles.Left };

                f.Aceptar.ValueChanged += (_, _) => Recalcular(f, reiniciar: false);
                Recalcular(f, reiniciar: true);

                grilla.Controls.Add(new Label { Text = item.NombreProducto, AutoSize = true, Anchor = AnchorStyles.Left });
                grilla.Controls.Add(new Label { Text = item.CantidadSolicitada.ToString(), AutoSize = true, Anchor = AnchorStyles.Left });
                grilla.Controls.Add(new Label { Text = item.CantidadDespachada.ToString(), AutoSize = true, Anchor = AnchorStyles.Left });
                grilla.Controls.Add(new Label { Text = item.StockDisponible.ToString(), AutoSize = true, Anchor = AnchorStyles.Left });
                grilla.Controls.Add(f.Aceptar);
                grilla.Controls.Add(f.Despachar);
                grilla.Controls.Add(f.LblMax);

                _filas.Add(f);
            }

            var scroll = new Panel { Dock = DockStyle.Fill, AutoScroll = true };
            scroll.Controls.Add(grilla);

            _cmbEmpleado.DisplayMember = "Texto";
            _cmbEmpleado.ValueMember = "Id";
            _cmbEmpleado.DataSource = empleados
                .Select(e => new { Id = e.IdEmpleado, Texto = $"{e.Apellido}, {e.Nombre}" })
                .ToList();
            if (idEmpleadoActual.HasValue && empleados.Any(e => e.IdEmpleado == idEmpleadoActual.Value))
                _cmbEmpleado.SelectedValue = idEmpleadoActual.Value;

            var btnConfirmar = new Button { Text = "Confirmar", Size = new Size(100, 32) };
            btnConfirmar.Click += BtnConfirmar_Click;
            var btnCancelar = new Button { Text = "Cancelar", Size = new Size(100, 32), DialogResult = DialogResult.Cancel };
            CancelButton = btnCancelar;

            var pie = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                FlowDirection = FlowDirection.RightToLeft,
                Height = 56,
                Padding = new Padding(12, 10, 12, 8)
            };
            pie.Controls.Add(btnCancelar);
            pie.Controls.Add(btnConfirmar);
            pie.Controls.Add(_cmbEmpleado);
            pie.Controls.Add(new Label { Text = "Despacha:", AutoSize = true, Padding = new Padding(0, 8, 0, 0) });

            Controls.Add(scroll);
            Controls.Add(lblInfo);
            Controls.Add(pie);
        }

        /// <summary>Máximo despachable ahora = aceptado - despachado (el stock ya se descontó al aceptar).</summary>
        private static void Recalcular(Fila f, bool reiniciar)
        {
            int pendiente = (int)f.Aceptar.Value - f.Item.CantidadDespachada;
            int max = Math.Max(pendiente, 0);

            f.Despachar.Maximum = max;
            f.Despachar.Enabled = max > 0;
            if (reiniciar || f.Despachar.Value > max) f.Despachar.Value = max;
            f.LblMax.Text = max.ToString();
        }

        private void BtnConfirmar_Click(object? sender, EventArgs e)
        {
            if (_cmbEmpleado.SelectedValue is not int idEmpleado)
            {
                MessageBox.Show("Elegí el empleado que despacha.", "Pedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Aceptaciones = _filas
                .Where(f => (int)f.Aceptar.Value != f.Item.CantidadAceptada)
                .Select(f => new AceptacionItemDTO { IdProducto = f.Item.IdProducto, CantidadAceptada = (int)f.Aceptar.Value })
                .ToList();

            Despachos = _filas
                .Where(f => (int)f.Despachar.Value > 0)
                .Select(f => new DespachoItemDTO { IdProducto = f.Item.IdProducto, Cantidad = (int)f.Despachar.Value })
                .ToList();

            if (Aceptaciones.Count == 0 && Despachos.Count == 0)
            {
                MessageBox.Show("No hay cambios para guardar: ajustá una cantidad aceptada o despachá algo.",
                    "Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            IdEmpleado = idEmpleado;
            DialogResult = DialogResult.OK;
        }
    }
}

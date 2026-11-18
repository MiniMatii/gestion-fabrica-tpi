using Alemana.API;
using Alemana.DTOs;

namespace MenuDesk
{
    /// <summary>
    /// Muestra los productos que quedaron pendientes de producción y permite generar la producción de cada uno.
    /// </summary>
    public class FormPendientesProduccion : Form
    {
        private readonly ApiClient _api;

        public FormPendientesProduccion(int idPedido, List<ProductoPendienteProduccionDTO> pendientes, ApiClient api)
        {
            _api = api;

            Text = $"Pedido #{idPedido}: productos pendientes de producción";
            Width = 620;
            Height = 170 + pendientes.Count * 44;
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            var lblInfo = new Label
            {
                Text = "No alcanzó el stock para estos productos. El pedido queda pendiente de ellos " +
                       "hasta que la producción esté disponible.",
                AutoSize = false,
                Dock = DockStyle.Top,
                Height = 56,
                Padding = new Padding(12, 12, 12, 0)
            };

            var grilla = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 3,
                RowCount = pendientes.Count + 1,
                Padding = new Padding(12, 4, 12, 4)
            };
            grilla.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            grilla.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            grilla.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));

            var negrita = new Font(Font, FontStyle.Bold);
            grilla.Controls.Add(new Label { Text = "Producto", AutoSize = true, Font = negrita }, 0, 0);
            grilla.Controls.Add(new Label { Text = "A producir", AutoSize = true, Font = negrita }, 1, 0);

            for (int i = 0; i < pendientes.Count; i++)
            {
                var p = pendientes[i];
                var fila = i + 1;

                var btn = new Button { Text = "Generar producción", AutoSize = true, Tag = p };
                btn.Click += BtnGenerar_Click;

                grilla.Controls.Add(new Label { Text = p.NombreProducto, AutoSize = true, Anchor = AnchorStyles.Left }, 0, fila);
                grilla.Controls.Add(new Label { Text = p.CantidadAProducir.ToString(), AutoSize = true, Anchor = AnchorStyles.Left }, 1, fila);
                grilla.Controls.Add(btn, 2, fila);
            }

            var btnCerrar = new Button { Text = "Cerrar", AutoSize = true, DialogResult = DialogResult.Cancel };
            CancelButton = btnCerrar;

            var pie = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                FlowDirection = FlowDirection.RightToLeft,
                Height = 52,
                Padding = new Padding(12, 8, 12, 8)
            };
            pie.Controls.Add(btnCerrar);

            Controls.Add(grilla);
            Controls.Add(lblInfo);
            Controls.Add(pie);
        }

        private async void BtnGenerar_Click(object? sender, EventArgs e)
        {
            if (sender is not Button btn || btn.Tag is not ProductoPendienteProduccionDTO p) return;

            btn.Enabled = false;
            try
            {
                var creada = await _api.PostAsync("ordenproduccion", new OrdenProduccionDTO
                {
                    IdProducto = p.IdProducto,
                    CantidadRequerida = p.CantidadAProducir
                });

                if (creada)
                {
                    btn.Text = "Generada";
                }
                else
                {
                    btn.Enabled = true;
                    MessageBox.Show("No se pudo generar la producción.", "Producción",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                btn.Enabled = true;
                MessageBox.Show("Error al generar la producción: " + ex.Message, "Producción",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

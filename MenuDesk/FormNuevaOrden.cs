using Alemana.API;
using Alemana.DTOs;

namespace MenuDesk
{
    /// <summary>Alta de una orden de producción: producto + cantidad + cálculo de materia prima. Queda Pendiente.</summary>
    public class FormNuevaOrden : Form
    {
        private readonly ApiClient _api;
        private readonly ComboBox _cmbProducto = new() { DropDownStyle = ComboBoxStyle.DropDownList, Width = 300 };
        private readonly NumericUpDown _nudCantidad = new() { Minimum = 1, Maximum = 1000000, Value = 100, Width = 120 };
        private readonly Button _btnCalcular = new() { Text = "Calcular materia prima", Width = 180, Height = 30 };
        private readonly ListView _lv = new() { View = View.Details, FullRowSelect = true, Width = 640, Height = 190 };
        private readonly Label _lblEstado = new() { AutoSize = false, Width = 640, Height = 40 };
        private readonly CheckBox _chkFecha = new() { Text = "Fecha estimada", AutoSize = true };
        private readonly DateTimePicker _dtpFecha = new() { Format = DateTimePickerFormat.Short, Width = 130, Enabled = false };
        private readonly Button _btnCrear = new() { Text = "Crear orden", Width = 130, Height = 34, Enabled = false };
        private readonly Button _btnCancelar = new() { Text = "Cancelar", Width = 100, Height = 34, DialogResult = DialogResult.Cancel };

        private CalculoProduccionDTO? _calculo;

        public FormNuevaOrden(ApiClient api)
        {
            _api = api;
            Text = "Nueva orden de producción";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = new Size(680, 440);

            _lv.Columns.Add("Materia prima", 230);
            _lv.Columns.Add("Necesaria", 130, HorizontalAlignment.Right);
            _lv.Columns.Add("Disponible", 130, HorizontalAlignment.Right);
            _lv.Columns.Add("Estado", 130);

            Colocar(new Label { Text = "Producto", AutoSize = true }, 20, 14);
            Colocar(_cmbProducto, 20, 38);
            Colocar(new Label { Text = "Cantidad a producir", AutoSize = true }, 340, 14);
            Colocar(_nudCantidad, 340, 38);
            Colocar(_btnCalcular, 475, 36);
            Colocar(_lv, 20, 84);
            Colocar(_lblEstado, 20, 282);
            Colocar(_chkFecha, 20, 332);
            Colocar(_dtpFecha, 150, 328);

            _btnCrear.Location = new Point(420, 388);
            _btnCancelar.Location = new Point(560, 388);
            Controls.Add(_btnCrear);
            Controls.Add(_btnCancelar);
            CancelButton = _btnCancelar;

            _dtpFecha.MinDate = DateTime.Today;
            _chkFecha.CheckedChanged += (_, _) => _dtpFecha.Enabled = _chkFecha.Checked;
            _cmbProducto.SelectedIndexChanged += (_, _) => Invalidar();
            _nudCantidad.ValueChanged += (_, _) => Invalidar();
            _btnCalcular.Click += async (_, _) => await CalcularAsync();
            _btnCrear.Click += async (_, _) => await CrearAsync();
            Load += async (_, _) => await CargarProductosAsync();
        }

        private void Colocar(Control c, int x, int y)
        {
            c.Location = new Point(x, y);
            Controls.Add(c);
        }

        private void Invalidar()
        {
            _calculo = null;
            _btnCrear.Enabled = false;
            _lv.Items.Clear();
            _lblEstado.Text = "Calculá la materia prima para continuar.";
        }

        private async Task CargarProductosAsync()
        {
            try
            {
                var productos = await _api.ObtenerListaAsync<ProductoDTO>("producto") ?? new List<ProductoDTO>();
                _cmbProducto.DisplayMember = nameof(ProductoDTO.Nombre);
                _cmbProducto.ValueMember = nameof(ProductoDTO.IdProducto);
                _cmbProducto.DataSource = productos;
                Invalidar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los productos: " + ex.Message, "Nueva orden",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CalcularAsync()
        {
            if (_cmbProducto.SelectedValue is not int idProducto) return;
            try
            {
                _btnCalcular.Enabled = false;
                var (ok, _, calculo, mensaje) = await _api.PostConDatosAsync<CalculoProduccionDTO, CalcularProduccionDTO>(
                    "ordenproduccion/calcular",
                    new CalcularProduccionDTO { IdProducto = idProducto, Cantidad = (int)_nudCantidad.Value });

                if (!ok || calculo == null)
                {
                    _lblEstado.Text = mensaje ?? "No se pudo calcular.";
                    return;
                }

                _calculo = calculo;
                _lv.Items.Clear();
                foreach (var m in calculo.MateriasPrimas)
                {
                    var it = new ListViewItem(m.NombreMateriaP);
                    it.SubItems.Add($"{m.CantidadNecesaria:0.##} {m.Unidad}");
                    it.SubItems.Add($"{m.StockDisponible:0.##} {m.Unidad}");
                    it.SubItems.Add(m.Suficiente ? "OK" : "Insuficiente");
                    it.ForeColor = m.Suficiente ? Color.Black : Color.Firebrick;
                    _lv.Items.Add(it);
                }

                _lblEstado.Text = calculo.Suficiente
                    ? "Materia prima suficiente. Al crear la orden queda Pendiente; después se confirma y se le asigna un operario."
                    : "Materia prima insuficiente. Podés crear la orden, pero no se va a poder confirmar hasta que haya stock.";
                _btnCrear.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo calcular: " + ex.Message, "Nueva orden",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _btnCalcular.Enabled = true;
            }
        }

        private async Task CrearAsync()
        {
            if (_calculo == null) return;

            var (ok, _, mensaje) = await _api.PostConRespuestaAsync("ordenproduccion", new OrdenProduccionDTO
            {
                IdProducto = _calculo.IdProducto,
                CantidadAproducir = _calculo.Cantidad,
                EstadoOrden = "Pendiente",
                FechaEstimada = _chkFecha.Checked ? _dtpFecha.Value.Date : null
            });

            if (ok) { DialogResult = DialogResult.OK; return; }

            MessageBox.Show(mensaje ?? "No se pudo crear la orden.", "Nueva orden",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}

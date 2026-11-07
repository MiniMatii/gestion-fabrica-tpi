using Alemana.API;
using Alemana.DTOs;
using KimTools.WinForms;
using System.Globalization;


namespace MenuDesk
{
    public partial class MiniMenuReceta : KtWindow
    {
        private readonly ApiClient _apiClient = new ApiClient();
        private const string endpointMP = "materiap";
        private bool _yaCargo;
        private readonly System.Windows.Forms.Timer _tmrMensaje =
            new System.Windows.Forms.Timer { Interval = 4000 };

        public MiniMenuReceta()
        {
            InitializeComponent();
            AplicarEstiloTabla(tablaER);
            MaximizeBox = false;
            Deactivate += MiniMenuReceta_Deactivate;
            VisibleChanged += MiniMenuReceta_VisibleChanged;

            _tmrMensaje.Tick += (s, e) =>
            {
                _tmrMensaje.Stop();
                lblMensaje.Text = "";
            };
            ConfigurarGrillaMaterias();
            dgvMateriasAR.CellValueChanged += DgvMateriasAR_CellValueChanged;
            dgvMateriasAR.DataError += (s, e) => e.ThrowException = false;
        }

        private void MiniMenuReceta_Deactivate(object? sender, EventArgs e)
        {
            this.Close();
        }


        private async void MiniMenuReceta_VisibleChanged(object? sender, EventArgs e)
        {
            if (Visible && _yaCargo)
            {
                LimpiarMensaje();
                await CargarRecetasEnGrilla();
                await CargarMateriasAsync();
            }
        }

        private void Mostrar(string texto, bool esError)
        {
            lblMensaje.ForeColor = esError
                ? Color.FromArgb(248, 113, 113)
                : Color.FromArgb(52, 211, 153);
            lblMensaje.Text = texto;

            _tmrMensaje.Stop();
            _tmrMensaje.Start();
        }

        private void LimpiarMensaje()
        {
            _tmrMensaje.Stop();
            lblMensaje.Text = "";
        }


        private async void MiniMenuReceta_Load(object sender, EventArgs e)
        {
            await CargarRecetasEnGrilla();
            await CargarMateriasAsync();
            _yaCargo = true;
        }


        private async Task CargarRecetasEnGrilla()
        {
            try
            {
                string endpoint = "Recetas";
                var listado = await _apiClient.ObtenerListaAsync<RecetaProductoDTO>(endpoint);

                if (listado != null)
                {
                    tablaER.DataSource = listado;
                }
            }
            catch (Exception ex)
            {
                Mostrar("No se pudieron cargar las recetas: " + ex.Message, true);
            }
        }

        private void altaRecetaButton_Click(object sender, EventArgs e)
        {
            LimpiarMensaje();
            navBarRecetas.SelectedTab = altaRecetaPage;
        }


        private void EliminarReceta_Click(object sender, EventArgs e)
        {
            LimpiarMensaje();
            navBarRecetas.SelectedTab = eliminarRecetaPage;
        }



        private async void buttonGuardarReceta_Click(object sender, EventArgs e)
        {
            try
            {
                dgvMateriasAR.EndEdit();

                if (string.IsNullOrWhiteSpace(textBoxDescAR.Text))
                {
                    Mostrar("Ingresá la descripción de la receta.", true);
                    return;
                }

                var insumos = new List<MateriapRecetaDTO>();

                foreach (DataGridViewRow fila in dgvMateriasAR.Rows)
                {
                    bool usa = fila.Cells["Usa"].Value is bool b && b;
                    if (!usa) continue;

                    var texto = Convert.ToString(fila.Cells["Cantidad"].Value);
                    if (!decimal.TryParse(texto, NumberStyles.Number, CultureInfo.CurrentCulture, out var cantidad)
                        || Math.Round(cantidad, 2) <= 0)
                    {
                        Mostrar($"Ingresá una cantidad mayor a cero para \"{fila.Cells["Nombre"].Value}\".", true);
                        dgvMateriasAR.CurrentCell = fila.Cells["Cantidad"];
                        return;
                    }

                    insumos.Add(new MateriapRecetaDTO
                    {
                        IdMateriaP = Convert.ToInt32(fila.Cells["Id"].Value),
                        CantidadNecesaria = Math.Round(cantidad, 2)      // la columna es DECIMAL(10,2)
                    });
                }

                if (insumos.Count == 0)
                {
                    Mostrar("Seleccioná al menos una materia prima e indicá su cantidad.", true);
                    return;
                }

                var r = new RecetaProductoDTO
                {
                    Descripcion = textBoxDescAR.Text.Trim(),
                    MateriapReceta = insumos
                };

                buttonGuardarReceta.Enabled = false;     // evita el doble clic
                try
                {
                    bool ok = await _apiClient.PostAsync("Recetas", r);
                    if (ok)
                    {
                        Mostrar("Receta guardada con éxito.", false);
                        textBoxDescAR.Clear();
                        LimpiarSeleccionMaterias();
                    }
                    else
                    {
                        Mostrar("No se pudo guardar la receta.", true);
                    }
                }
                finally
                {
                    buttonGuardarReceta.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Mostrar("Error al conectar con el servidor: " + ex.Message, true);
            }
        }



        private async void buttonGuardarER_Click(object sender, EventArgs e)
        {
            try
            {
                string endpoint = "Recetas";
                var rE = tablaER.CurrentRow;

                if (rE == null)
                {
                    Mostrar("Seleccioná una receta de la tabla.", true);
                    return;
                }

                var rElim = new RecetaProductoDTO();
                rElim.IdReceta = Convert.ToInt32(rE.Cells["idER"].Value);

                var eliminado = await _apiClient.DeleteAsync($"{endpoint}/{rElim.IdReceta}");
                if (eliminado)
                    Mostrar("Receta eliminada.", false);
                else
                    Mostrar("No se pudo eliminar la receta.", true);
            }
            catch (Exception ex)
            {
                Mostrar("Error al eliminar la receta: " + ex.Message, true);
            }
        }

        private async void buttonActualizarER_Click(object sender, EventArgs e)
        {
            await CargarRecetasEnGrilla();
        }

        private void ConfigurarGrillaMaterias()
        {
            dgvMateriasAR.AutoGenerateColumns = false;
            dgvMateriasAR.AllowUserToAddRows = false;
            dgvMateriasAR.AllowUserToDeleteRows = false;
            dgvMateriasAR.RowHeadersVisible = false;
            dgvMateriasAR.Columns.Clear();

            dgvMateriasAR.Columns.Add(new DataGridViewCheckBoxColumn
            { Name = "Usa", HeaderText = "Usa", Width = 50 });

            dgvMateriasAR.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "Id", Visible = false });

            dgvMateriasAR.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nombre",
                HeaderText = "Materia prima",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvMateriasAR.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "Unidad", HeaderText = "Unidad", ReadOnly = true, Width = 90 });

            dgvMateriasAR.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "Cantidad", HeaderText = "Cantidad", ValueType = typeof(string), Width = 90 });
        }


        private async Task CargarMateriasAsync()
        {
            try
            {
                var previas = new Dictionary<int, (bool Usa, string Cantidad)>();
                foreach (DataGridViewRow f in dgvMateriasAR.Rows)
                {
                    previas[Convert.ToInt32(f.Cells["Id"].Value)] =
                        (f.Cells["Usa"].Value is bool b && b,
                         Convert.ToString(f.Cells["Cantidad"].Value) ?? "");
                }

                var materias = await _apiClient.ObtenerListaAsync<MateriapDTO>(endpointMP);

                dgvMateriasAR.SuspendLayout();
                dgvMateriasAR.Rows.Clear();
                foreach (var mp in materias ?? new List<MateriapDTO>())
                {
                    previas.TryGetValue(mp.IdMateriaP, out var previa);
                    dgvMateriasAR.Rows.Add(previa.Usa, mp.IdMateriaP, mp.Nombre, mp.Unidad, previa.Cantidad ?? "");
                }
                dgvMateriasAR.ResumeLayout();
            }
            catch (Exception ex)
            {
                Mostrar("No se pudieron cargar las materias primas: " + ex.Message, true);
            }
        }

        private void DgvMateriasAR_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvMateriasAR.Columns[e.ColumnIndex].Name != "Cantidad") return;

            var fila = dgvMateriasAR.Rows[e.RowIndex];
            if (!string.IsNullOrWhiteSpace(Convert.ToString(fila.Cells["Cantidad"].Value)))
                fila.Cells["Usa"].Value = true;
        }

        private void LimpiarSeleccionMaterias()
        {
            foreach (DataGridViewRow fila in dgvMateriasAR.Rows)
            {
                fila.Cells["Usa"].Value = false;
                fila.Cells["Cantidad"].Value = "";
            }
        }

        private void AplicarEstiloTabla(DataGridView g)
        {
            var fondo = Color.FromArgb(0, 78, 65);
            var texto = Color.White;

            foreach (var estilo in new[] { g.DefaultCellStyle, g.AlternatingRowsDefaultCellStyle })
            {
                estilo.BackColor = fondo;
                estilo.ForeColor = texto;
                estilo.SelectionBackColor = Color.FromArgb(173, 151, 98);  
                estilo.SelectionForeColor = Color.White;
            }
        }

    }
}
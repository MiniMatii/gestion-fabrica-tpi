using Alemana.DTOs;


namespace MenuDesk.Controles
{
    public partial class FilaAsignacion : UserControl
    {
        public ItemAsignableDTO Item { get; private set; } = null!;
        public bool RequiereOperario => Item.CantidadAProducir > 0;



        public FilaAsignacion()
        {
            InitializeComponent();
        }

        public void Cargar(ItemAsignableDTO item)
        {
            Item = item;
            lblProducto.Text = item.NombreProducto;
            lblCantidad.Text = "× " + item.Cantidad;

            var opciones = new List<OperarioOpcionDTO>
            {
                new() { IdOperario = 0, NombreCompleto = "— Sin asignar —" }
            };
            opciones.AddRange(item.Operarios);

            cboOperario.DropDownStyle = ComboBoxStyle.DropDownList;
            cboOperario.DisplayMember = nameof(OperarioOpcionDTO.NombreCompleto);
            cboOperario.ValueMember = nameof(OperarioOpcionDTO.IdOperario);
            cboOperario.DataSource = opciones;

            if (item.CantidadAProducir == 0)
            {
                cboOperario.Enabled = false;            
            }
            else if (item.Operarios.Count == 0)
            {
                cboOperario.Enabled = false;            
                lblCantidad.Text += "  (sin operario disponible)";
            }
        }

        public int? IdOperarioElegido =>
            cboOperario.SelectedValue is int id && id != 0 ? id : null;
    }
}


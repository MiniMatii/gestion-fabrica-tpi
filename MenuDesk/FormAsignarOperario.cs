using Alemana.DTOs;
using KimTools.WinForms;
using MenuDesk.Controles;

namespace MenuDesk
{
    public partial class FormAsignarOperario : KtWindow
    {
        private readonly List<FilaAsignacion> _filas = new();

        public List<AsignacionItemDTO> Asignaciones { get; private set; } = new();

        public FormAsignarOperario()            
        {
            InitializeComponent();
        }

        public FormAsignarOperario(int idPedido, List<ItemAsignableDTO> items) : this()
        {
            lblTitulo.Text = $"Pedido #{idPedido}: asigná un operario a cada producto";
            btnCancelar.DialogResult = DialogResult.Cancel;
            CancelButton = btnCancelar;

            pnlItems.SuspendLayout();
            foreach (var item in items)
            {
                var fila = new FilaAsignacion();
                fila.Cargar(item);
                fila.Width = pnlItems.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - fila.Margin.Horizontal;
                flowItems.Controls.Add(fila);
                _filas.Add(fila);
            }
            pnlItems.ResumeLayout();
            lblAviso.Text = $"Ítems: {items.Count} | Filas: {flowItems.Controls.Count}";

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Asignaciones = _filas.Select(f => new AsignacionItemDTO
            {
                IdProducto = f.Item.IdProducto,
                IdOperario = f.IdOperarioElegido
            }).ToList();

            int sinAsignar = _filas.Count(f => f.RequiereOperario && f.IdOperarioElegido == null);
            if (sinAsignar > 0)
            {
                var r = MessageBox.Show(
                    $"{sinAsignar} producto(s) quedarán sin operario asignado. ¿Continuar?",
                    "Aceptar pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r != DialogResult.Yes) return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
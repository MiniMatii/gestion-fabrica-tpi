using Alemana.DTOs;
using KimTools.WinForms;

namespace MenuDesk
{
    public partial class FormPedidoDetalleMini : KtWindow
    {
        public FormPedidoDetalleMini(int pedidoId, List<PedidoItemDTO> productos)
        {
            InitializeComponent();
            Text = "Pedido #" + pedidoId;
            lblTitulo.Text = "Pedido #" + pedidoId;
            dgvDetalle.AutoGenerateColumns = false;
            dgvDetalle.ColumnHeadersVisible = false;   
            dgvDetalle.RowHeadersVisible = false;
            dgvDetalle.Columns.Clear();


            dgvDetalle.Columns.Add(new DataGridViewTextBoxColumn
            { HeaderText = "Id", DataPropertyName = "IdProducto", Width = 60 });
            dgvDetalle.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Producto",
                DataPropertyName = "NombreProducto",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvDetalle.Columns.Add(new DataGridViewTextBoxColumn
            { HeaderText = "Cantidad", DataPropertyName = "CantidadPedida", Width = 90 });
            dgvDetalle.DataSource = productos;

        }


        private void FormPedidoDetalleMini_Deactivate(object sender, EventArgs e)
        {
            if (!IsDisposed) 
            {
                Close();
            } 
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) 
            {
                Close(); return true; 
            }
            
            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}

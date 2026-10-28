namespace MenuDesk
{
    partial class FormPedidoDetalleMini
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPedidoDetalleMini));
            lblTitulo = new KimTools.WinForms.KtLabel();
            ktPanel1 = new KimTools.WinForms.KtPanel();
            dgvDetalle = new KimTools.WinForms.KtTable();
            ktPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Align = ContentAlignment.MiddleCenter;
            lblTitulo.Auto = false;
            lblTitulo.Background = KimTools.WinForms.KtColor.Empty;
            lblTitulo.Color = new KimTools.WinForms.KtColor(Color.White, null, null);
            lblTitulo.Dock = DockStyle.Left;
            lblTitulo.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(254, 40);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Pedido";
            // 
            // ktPanel1
            // 
            Set_Drag(ktPanel1, true);
            ktPanel1.Background = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(0, 78, 65), null, null));
            ktPanel1.Border = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            ktPanel1.BorderEdges.BottomLeft = false;
            ktPanel1.BorderEdges.BottomRight = false;
            ktPanel1.BorderEdges.TopLeft = false;
            ktPanel1.BorderEdges.TopRight = false;
            ktPanel1.BorderRadius = 24F;
            ktPanel1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            ktPanel1.BorderWidth = 0F;
            ktPanel1.Controls.Add(lblTitulo);
            ktPanel1.Dock = DockStyle.Top;
            ktPanel1.Foreground = new KimTools.WinForms.KtColor(Color.White, null, null);
            ktPanel1.Location = new Point(0, 0);
            ktPanel1.Name = "ktPanel1";
            ktPanel1.PatternColor = KimTools.WinForms.KtColor.Empty;
            ktPanel1.Size = new Size(800, 40);
            ktPanel1.TabIndex = 2;
            // 
            // dgvDetalle
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(15, 23, 43);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(20, 31, 62);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(160, 180, 240);
            dgvDetalle.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvDetalle.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgvDetalle.BackgroundColor = Color.FromArgb(173, 151, 98);
            dgvDetalle.BorderStyle = BorderStyle.None;
            dgvDetalle.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvDetalle.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(65, 105, 225);
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(65, 105, 225);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvDetalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvDetalle.ColumnHeadersHeight = 45;
            dgvDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(0, 78, 65);
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(34, 29, 17);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(0, 78, 65);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvDetalle.DefaultCellStyle = dataGridViewCellStyle3;
            dgvDetalle.Dock = DockStyle.Fill;
            dgvDetalle.EnableHeadersVisualStyles = false;
            dgvDetalle.GridColor = Color.FromArgb(0, 78, 65);
            dgvDetalle.Location = new Point(0, 40);
            dgvDetalle.Name = "dgvDetalle";
            dgvDetalle.ReadOnly = true;
            dgvDetalle.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(30, 41, 57);
            dataGridViewCellStyle4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(30, 41, 57);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(30, 41, 57);
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(30, 41, 57);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvDetalle.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvDetalle.RowHeadersVisible = false;
            dgvDetalle.RowHeadersWidth = 50;
            dgvDetalle.RowTemplate.Height = 45;
            dgvDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalle.Size = new Size(800, 410);
            dgvDetalle.Style.Background = KimTools.WinForms.KtColor.BASE_2;
            dgvDetalle.Style.Border = 0F;
            dgvDetalle.Style.Color = KimTools.WinForms.KtColor.PRIMARY;
            dgvDetalle.Style.Foreground = KimTools.WinForms.KtColor.CONTENT;
            dgvDetalle.Style.Header.Background = KimTools.WinForms.KtColor.Empty;
            dgvDetalle.Style.Header.Foreground = KimTools.WinForms.KtColor.Empty;
            dgvDetalle.Style.Row.Background = KimTools.WinForms.KtColor.BASE_2;
            dgvDetalle.Style.Row.Foreground = KimTools.WinForms.KtColor.CONTENT;
            dgvDetalle.Style.RowAlt.Background = KimTools.WinForms.KtColor.BASE_1;
            dgvDetalle.Style.RowAlt.Foreground = KimTools.WinForms.KtColor.CONTENT;
            dgvDetalle.Style.ScrollBar.Background = KimTools.WinForms.KtColor.Empty;
            dgvDetalle.Style.ScrollBar.Foreground = KimTools.WinForms.KtColor.Empty;
            dgvDetalle.TabIndex = 1;
            // 
            // FormPedidoDetalleMini
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(173, 151, 98);
            Background = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(173, 151, 98), null, null));
            ClientSize = new Size(800, 450);
            Controls.Add(dgvDetalle);
            Controls.Add(ktPanel1);
            ForeColor = Color.FromArgb(34, 29, 17);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormPedidoDetalleMini";
            Text = "FormPedidoDetalleMini";
            Deactivate += FormPedidoDetalleMini_Deactivate;
            ktPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private KimTools.WinForms.KtLabel lblTitulo;
        private KimTools.WinForms.KtPanel ktPanel1;
        private KimTools.WinForms.KtTable dgvDetalle;
    }
}
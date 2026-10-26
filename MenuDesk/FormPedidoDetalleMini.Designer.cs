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
            lblFecha = new KimTools.WinForms.KtLabel();
            dgvDetalle = new KimTools.WinForms.KtTable();
            ktPanel1 = new KimTools.WinForms.KtPanel();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).BeginInit();
            ktPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblFecha
            // 
            lblFecha.Align = ContentAlignment.TopLeft;
            lblFecha.Auto = false;
            lblFecha.Background = KimTools.WinForms.KtColor.Empty;
            lblFecha.Color = KimTools.WinForms.KtColor.Empty;
            lblFecha.Dock = DockStyle.Left;
            lblFecha.Location = new Point(0, 0);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(254, 70);
            lblFecha.TabIndex = 0;
            lblFecha.Text = "ktLabel1";
            // 
            // dgvDetalle
            // 
            dgvDetalle.BorderStyle = BorderStyle.None;
            dgvDetalle.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvDetalle.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalle.Dock = DockStyle.Fill;
            dgvDetalle.EnableHeadersVisualStyles = false;
            dgvDetalle.Location = new Point(0, 0);
            dgvDetalle.Name = "dgvDetalle";
            dgvDetalle.ReadOnly = true;
            dgvDetalle.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvDetalle.RowHeadersVisible = false;
            dgvDetalle.RowHeadersWidth = 20;
            dgvDetalle.RowTemplate.Height = 45;
            dgvDetalle.Size = new Size(800, 450);
            dgvDetalle.Style.Background = KimTools.WinForms.KtColor.BASE_2;
            dgvDetalle.Style.Border = 0.99F;
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
            // ktPanel1
            // 
            ktPanel1.Background = new KimTools.WinForms.KtBrushSolid(KimTools.WinForms.KtColor.BASE_2);
            ktPanel1.Border = new KimTools.WinForms.KtBrushGradient(KimTools.WinForms.KtColor.BASE_1, KimTools.WinForms.KtColor.BASE_3);
            ktPanel1.BorderRadius = 24F;
            ktPanel1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            ktPanel1.BorderWidth = 1.5F;
            ktPanel1.Controls.Add(lblFecha);
            ktPanel1.Dock = DockStyle.Top;
            ktPanel1.Foreground = KimTools.WinForms.KtColor.Empty;
            ktPanel1.Location = new Point(0, 0);
            ktPanel1.Name = "ktPanel1";
            ktPanel1.PatternColor = KimTools.WinForms.KtColor.Empty;
            ktPanel1.Size = new Size(800, 70);
            ktPanel1.TabIndex = 2;
            // 
            // FormPedidoDetalleMini
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ktPanel1);
            Controls.Add(dgvDetalle);
            ForeColor = Color.FromArgb(255, 255, 255);
            Name = "FormPedidoDetalleMini";
            Text = "FormPedidoDetalleMini";
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).EndInit();
            ktPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private KimTools.WinForms.KtLabel lblFecha;
        private KimTools.WinForms.KtTable dgvDetalle;
        private KimTools.WinForms.KtPanel ktPanel1;
    }
}
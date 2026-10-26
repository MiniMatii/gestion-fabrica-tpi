namespace MenuDesk.Controles
{
    partial class PedidoCard
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            ktPanel1 = new KimTools.WinForms.KtPanel();
            lblFecha = new KimTools.WinForms.KtLabel();
            lblNumero = new KimTools.WinForms.KtLabel();
            btnVer = new KimTools.WinForms.KtButton();
            ktPanel2 = new KimTools.WinForms.KtPanel();
            ktPanel1.SuspendLayout();
            ktPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // ktPanel1
            // 
            ktPanel1.Background = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(0, 78, 65), null, null));
            ktPanel1.Border = new KimTools.WinForms.KtBrushGradient(KimTools.WinForms.KtColor.BASE_1, KimTools.WinForms.KtColor.BASE_3);
            ktPanel1.BorderEdges.BottomLeft = false;
            ktPanel1.BorderEdges.BottomRight = false;
            ktPanel1.BorderRadius = 6F;
            ktPanel1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            ktPanel1.BorderWidth = 1.5F;
            ktPanel1.Controls.Add(lblFecha);
            ktPanel1.Controls.Add(lblNumero);
            ktPanel1.Dock = DockStyle.Top;
            ktPanel1.Foreground = KimTools.WinForms.KtColor.Empty;
            ktPanel1.Location = new Point(0, 0);
            ktPanel1.Name = "ktPanel1";
            ktPanel1.Padding = new Padding(5, 5, 5, 0);
            ktPanel1.PatternColor = KimTools.WinForms.KtColor.Empty;
            ktPanel1.Size = new Size(220, 61);
            ktPanel1.TabIndex = 0;
            // 
            // lblFecha
            // 
            lblFecha.Align = ContentAlignment.TopLeft;
            lblFecha.Auto = false;
            lblFecha.Background = KimTools.WinForms.KtColor.Empty;
            lblFecha.Color = new KimTools.WinForms.KtColor(Color.White, null, null);
            lblFecha.Dock = DockStyle.Left;
            lblFecha.Location = new Point(105, 5);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(117, 56);
            lblFecha.TabIndex = 1;
            lblFecha.Text = "ktLabel2";
            // 
            // lblNumero
            // 
            lblNumero.Align = ContentAlignment.TopLeft;
            lblNumero.Auto = false;
            lblNumero.Background = KimTools.WinForms.KtColor.Empty;
            lblNumero.Color = new KimTools.WinForms.KtColor(Color.White, null, null);
            lblNumero.Dock = DockStyle.Left;
            lblNumero.Location = new Point(5, 5);
            lblNumero.Name = "lblNumero";
            lblNumero.Size = new Size(100, 56);
            lblNumero.TabIndex = 0;
            lblNumero.Text = "ktLabel1";
            // 
            // btnVer
            // 
            btnVer.BackColor = Color.Transparent;
            btnVer.Background = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(0, 78, 65), null, null));
            btnVer.Border = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            btnVer.BorderMargin = new Padding(0);
            btnVer.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            btnVer.BorderWidth = 2F;
            btnVer.Cursor = Cursors.Default;
            btnVer.Dock = DockStyle.Right;
            btnVer.Font = new Font("Segoe UI Symbol", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVer.ForeColor = Color.FromArgb(204, 255, 246);
            btnVer.Foreground = KimTools.WinForms.KtColor.Empty;
            btnVer.Icon = "";
            btnVer.IconColor = KimTools.WinForms.KtColor.Empty;
            btnVer.IconSize = 16;
            btnVer.IconStroke = 2.5D;
            btnVer.Location = new Point(113, 5);
            btnVer.Name = "btnVer";
            btnVer.Padding = new Padding(8, 0, 8, 0);
            btnVer.Pattern.Color = new KimTools.WinForms.KtColor(Color.FromArgb(0, 78, 65), null, null);
            btnVer.Pattern.Style = KimTools.WinForms.KtPatternStyle.Default;
            btnVer.Size = new Size(97, 42);
            btnVer.TabIndex = 2;
            btnVer.Text = "Ver";
            btnVer.UseVisualStyleBackColor = false;
            btnVer.Click += btnVer_Click;
            // 
            // ktPanel2
            // 
            ktPanel2.Background = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(53, 114, 106), null, null));
            ktPanel2.Border = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.Black, null, null));
            ktPanel2.BorderEdges.TopLeft = false;
            ktPanel2.BorderEdges.TopRight = false;
            ktPanel2.BorderRadius = 24F;
            ktPanel2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            ktPanel2.BorderWidth = 1F;
            ktPanel2.Controls.Add(btnVer);
            ktPanel2.Dock = DockStyle.Bottom;
            ktPanel2.Foreground = KimTools.WinForms.KtColor.Empty;
            ktPanel2.Location = new Point(0, 58);
            ktPanel2.Name = "ktPanel2";
            ktPanel2.Padding = new Padding(0, 5, 10, 5);
            ktPanel2.PatternColor = KimTools.WinForms.KtColor.Empty;
            ktPanel2.Size = new Size(220, 52);
            ktPanel2.TabIndex = 3;
            // 
            // PedidoCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(173, 151, 98);
            Controls.Add(ktPanel2);
            Controls.Add(ktPanel1);
            Enabled = false;
            Name = "PedidoCard";
            Size = new Size(220, 110);
            ktPanel1.ResumeLayout(false);
            ktPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private KimTools.WinForms.KtPanel ktPanel1;
        private KimTools.WinForms.KtLabel lblFecha;
        private KimTools.WinForms.KtLabel lblNumero;
        private KimTools.WinForms.KtButton btnVer;
        private KimTools.WinForms.KtPanel ktPanel2;
    }
}

namespace MenuDesk.Controles
{
    partial class FilaAsignacion
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
            lblProducto = new KimTools.WinForms.KtLabel();
            lblCantidad = new KimTools.WinForms.KtLabel();
            cboOperario = new KimTools.WinForms.KtSelect();
            SuspendLayout();
            // 
            // lblProducto
            // 
            lblProducto.Align = ContentAlignment.MiddleLeft;
            lblProducto.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblProducto.Auto = false;
            lblProducto.Background = KimTools.WinForms.KtColor.Empty;
            lblProducto.Color = new KimTools.WinForms.KtColor(Color.Black, null, null);
            lblProducto.Location = new Point(0, 0);
            lblProducto.Name = "lblProducto";
            lblProducto.Size = new Size(134, 50);
            lblProducto.TabIndex = 0;
            lblProducto.Text = "ktLabel1";
            // 
            // lblCantidad
            // 
            lblCantidad.Align = ContentAlignment.MiddleCenter;
            lblCantidad.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblCantidad.Auto = false;
            lblCantidad.Background = KimTools.WinForms.KtColor.Empty;
            lblCantidad.Color = new KimTools.WinForms.KtColor(Color.Black, null, null);
            lblCantidad.Location = new Point(183, 0);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(134, 50);
            lblCantidad.TabIndex = 1;
            lblCantidad.Text = "ktLabel1";
            // 
            // cboOperario
            // 
            cboOperario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            cboOperario.Bg = new KimTools.WinForms.KtColor(Color.FromArgb(173, 151, 98), null, null);
            cboOperario.BorderColor = new KimTools.WinForms.KtColor(Color.Black, null, null);
            cboOperario.BorderRadius = 3;
            cboOperario.Direction = KimTools.WinForms.KtSelect.Directions.Down;
            cboOperario.DisabledBackColor = KimTools.WinForms.KtColor.Gray;
            cboOperario.DisabledBorderColor = new KimTools.WinForms.KtColor("@Gray", null, 50);
            cboOperario.DisabledColor = KimTools.WinForms.KtColor.Gray;
            cboOperario.DisabledForeColor = new KimTools.WinForms.KtColor(Color.White, null, null);
            cboOperario.DisabledIndicatorColor = new KimTools.WinForms.KtColor(Color.WhiteSmoke, null, null);
            cboOperario.DrawMode = DrawMode.OwnerDrawFixed;
            cboOperario.DropdownBorderThickness = KimTools.WinForms.KtSelect.BorderThickness.Thick;
            cboOperario.DropDownStyle = ComboBoxStyle.DropDownList;
            cboOperario.DropDownTextAlign = KimTools.WinForms.KtSelect.TextAlign.Left;
            cboOperario.FillDropDown = true;
            cboOperario.FillIndicator = false;
            cboOperario.FlatStyle = FlatStyle.Flat;
            cboOperario.ForeColor = Color.FromArgb(255, 255, 255);
            cboOperario.FormattingEnabled = true;
            cboOperario.IndicatorAlignment = KimTools.WinForms.KtSelect.Indicator.Right;
            cboOperario.IndicatorColor = new KimTools.WinForms.KtColor("$PrimaryContent", null, null);
            cboOperario.IndicatorLocation = KimTools.WinForms.KtSelect.Indicator.Right;
            cboOperario.ItemBackColor = new KimTools.WinForms.KtColor(Color.FromArgb(173, 151, 98), null, null);
            cboOperario.ItemBorderColor = new KimTools.WinForms.KtColor(Color.Black, null, null);
            cboOperario.ItemForeColor = KimTools.WinForms.KtColor.CONTENT;
            cboOperario.ItemHeight = 15;
            cboOperario.ItemHighLightColor = KimTools.WinForms.KtColor.PRIMARY;
            cboOperario.ItemHighLightForeColor = new KimTools.WinForms.KtColor("$PrimaryContent", null, null);
            cboOperario.ItemTopMargin = 1;
            cboOperario.Location = new Point(323, 16);
            cboOperario.Name = "cboOperario";
            cboOperario.Size = new Size(174, 21);
            cboOperario.TabIndex = 2;
            cboOperario.Text = null;
            cboOperario.TextAlignment = KimTools.WinForms.KtSelect.TextAlign.Left;
            cboOperario.TextColor = new KimTools.WinForms.KtColor("$PrimaryContent", null, null);
            cboOperario.TextLeftMargin = 5;
            // 
            // FilaAsignacion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cboOperario);
            Controls.Add(lblCantidad);
            Controls.Add(lblProducto);
            Name = "FilaAsignacion";
            Size = new Size(500, 50);
            ResumeLayout(false);
        }

        #endregion

        private KimTools.WinForms.KtLabel lblProducto;
        private KimTools.WinForms.KtLabel lblCantidad;
        private KimTools.WinForms.KtSelect cboOperario;
    }
}

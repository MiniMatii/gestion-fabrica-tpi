namespace MenuDesk
{
    partial class FormAsignarOperario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAsignarOperario));
            pnlTitulo = new KimTools.WinForms.KtPanel();
            lblTitulo = new KimTools.WinForms.KtLabel();
            pnlItems = new KimTools.WinForms.KtPanel();
            flowItems = new FlowLayoutPanel();
            pnlBotones = new KimTools.WinForms.KtPanel();
            lblAviso = new KimTools.WinForms.KtLabel();
            btnAceptar = new KimTools.WinForms.KtButton();
            btnCancelar = new KimTools.WinForms.KtButton();
            pnlTitulo.SuspendLayout();
            pnlItems.SuspendLayout();
            pnlBotones.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTitulo
            // 
            pnlTitulo.Background = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(6, 72, 60), null, null));
            pnlTitulo.Border = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.Black, null, null));
            pnlTitulo.BorderEdges.BottomLeft = false;
            pnlTitulo.BorderEdges.BottomRight = false;
            pnlTitulo.BorderEdges.TopLeft = false;
            pnlTitulo.BorderEdges.TopRight = false;
            pnlTitulo.BorderRadius = 24F;
            pnlTitulo.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            pnlTitulo.BorderWidth = 1.5F;
            pnlTitulo.Controls.Add(lblTitulo);
            pnlTitulo.Dock = DockStyle.Top;
            pnlTitulo.Foreground = KimTools.WinForms.KtColor.Empty;
            pnlTitulo.Location = new Point(0, 0);
            pnlTitulo.Name = "pnlTitulo";
            pnlTitulo.PatternColor = KimTools.WinForms.KtColor.Empty;
            pnlTitulo.Size = new Size(800, 100);
            pnlTitulo.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.Align = ContentAlignment.TopLeft;
            lblTitulo.Auto = false;
            lblTitulo.Background = KimTools.WinForms.KtColor.Empty;
            lblTitulo.Color = KimTools.WinForms.KtColor.Empty;
            lblTitulo.Location = new Point(27, 25);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(209, 48);
            lblTitulo.TabIndex = 3;
            lblTitulo.Text = "ktLabel2";
            // 
            // pnlItems
            // 
            pnlItems.Background = new KimTools.WinForms.KtBrushSolid(KimTools.WinForms.KtColor.BASE_2);
            pnlItems.Border = new KimTools.WinForms.KtBrushGradient(KimTools.WinForms.KtColor.BASE_1, KimTools.WinForms.KtColor.BASE_3);
            pnlItems.BorderRadius = 24F;
            pnlItems.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            pnlItems.BorderWidth = 1.5F;
            pnlItems.Controls.Add(flowItems);
            pnlItems.Dock = DockStyle.Fill;
            pnlItems.Foreground = KimTools.WinForms.KtColor.Empty;
            pnlItems.Location = new Point(0, 100);
            pnlItems.Name = "pnlItems";
            pnlItems.PatternColor = KimTools.WinForms.KtColor.Empty;
            pnlItems.Size = new Size(800, 271);
            pnlItems.TabIndex = 1;
            // 
            // flowItems
            // 
            flowItems.BackColor = Color.FromArgb(35, 103, 92);
            flowItems.BorderStyle = BorderStyle.FixedSingle;
            flowItems.Dock = DockStyle.Fill;
            flowItems.FlowDirection = FlowDirection.TopDown;
            flowItems.Location = new Point(0, 0);
            flowItems.Name = "flowItems";
            flowItems.Size = new Size(800, 271);
            flowItems.TabIndex = 0;
            flowItems.WrapContents = false;
            // 
            // pnlBotones
            // 
            pnlBotones.Background = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(6, 72, 60), null, null));
            pnlBotones.Border = (KimTools.WinForms.KtBrushSolid)KimTools.WinForms.KtBrush.Solid;
            pnlBotones.BorderEdges.BottomLeft = false;
            pnlBotones.BorderEdges.BottomRight = false;
            pnlBotones.BorderEdges.TopLeft = false;
            pnlBotones.BorderEdges.TopRight = false;
            pnlBotones.BorderRadius = 24F;
            pnlBotones.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            pnlBotones.BorderWidth = 1.5F;
            pnlBotones.Controls.Add(btnCancelar);
            pnlBotones.Controls.Add(btnAceptar);
            pnlBotones.Controls.Add(lblAviso);
            pnlBotones.Dock = DockStyle.Bottom;
            pnlBotones.Foreground = KimTools.WinForms.KtColor.Empty;
            pnlBotones.Location = new Point(0, 371);
            pnlBotones.Name = "pnlBotones";
            pnlBotones.PatternColor = KimTools.WinForms.KtColor.Empty;
            pnlBotones.Size = new Size(800, 79);
            pnlBotones.TabIndex = 2;
            // 
            // lblAviso
            // 
            lblAviso.Align = ContentAlignment.TopLeft;
            lblAviso.Auto = false;
            lblAviso.Background = KimTools.WinForms.KtColor.Empty;
            lblAviso.Color = KimTools.WinForms.KtColor.Empty;
            lblAviso.Location = new Point(27, 19);
            lblAviso.Name = "lblAviso";
            lblAviso.Size = new Size(209, 48);
            lblAviso.TabIndex = 2;
            lblAviso.Text = "ktLabel1";
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = Color.Transparent;
            btnAceptar.Background = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(45, 108, 99), null, null));
            btnAceptar.Border = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(13, 63, 59), null, null));
            btnAceptar.BorderMargin = new Padding(0);
            btnAceptar.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            btnAceptar.BorderWidth = 2F;
            btnAceptar.Cursor = Cursors.Default;
            btnAceptar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAceptar.ForeColor = Color.FromArgb(219, 240, 237);
            btnAceptar.Foreground = KimTools.WinForms.KtColor.Empty;
            btnAceptar.Icon = "";
            btnAceptar.IconColor = KimTools.WinForms.KtColor.Empty;
            btnAceptar.IconSize = 16;
            btnAceptar.IconStroke = 2.5D;
            btnAceptar.Location = new Point(668, 19);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Padding = new Padding(8, 0, 8, 0);
            btnAceptar.Pattern.Style = KimTools.WinForms.KtPatternStyle.Default;
            btnAceptar.Size = new Size(120, 48);
            btnAceptar.TabIndex = 7;
            btnAceptar.Text = "Confirmar";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Transparent;
            btnCancelar.Background = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(45, 108, 99), null, null));
            btnCancelar.Border = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(13, 63, 59), null, null));
            btnCancelar.BorderMargin = new Padding(0);
            btnCancelar.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            btnCancelar.BorderWidth = 2F;
            btnCancelar.Cursor = Cursors.Default;
            btnCancelar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.ForeColor = Color.FromArgb(219, 240, 237);
            btnCancelar.Foreground = KimTools.WinForms.KtColor.Empty;
            btnCancelar.Icon = "";
            btnCancelar.IconColor = KimTools.WinForms.KtColor.Empty;
            btnCancelar.IconSize = 16;
            btnCancelar.IconStroke = 2.5D;
            btnCancelar.Location = new Point(542, 19);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Padding = new Padding(8, 0, 8, 0);
            btnCancelar.Pattern.Style = KimTools.WinForms.KtPatternStyle.Default;
            btnCancelar.Size = new Size(120, 48);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // FormAsignarOperario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Background = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(6, 72, 60), null, null));
            ClientSize = new Size(800, 450);
            Controls.Add(pnlItems);
            Controls.Add(pnlBotones);
            Controls.Add(pnlTitulo);
            ForeColor = Color.FromArgb(208, 251, 243);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormAsignarOperario";
            Text = "FormAsignarOperario";
            pnlTitulo.ResumeLayout(false);
            pnlItems.ResumeLayout(false);
            pnlBotones.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private KimTools.WinForms.KtPanel pnlTitulo;
        private KimTools.WinForms.KtPanel pnlItems;
        private KimTools.WinForms.KtPanel pnlBotones;
        private KimTools.WinForms.KtLabel lblTitulo;
        private FlowLayoutPanel flowItems;
        private KimTools.WinForms.KtLabel lblAviso;
        private KimTools.WinForms.KtButton btnAceptar;
        private KimTools.WinForms.KtButton btnCancelar;
    }
}
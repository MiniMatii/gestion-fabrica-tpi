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
            pnlTitulo = new KimTools.WinForms.KtPanel();
            lblTitulo = new KimTools.WinForms.KtLabel();
            pnlItems = new KimTools.WinForms.KtPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
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
            pnlTitulo.Background = new KimTools.WinForms.KtBrushSolid(KimTools.WinForms.KtColor.BASE_2);
            pnlTitulo.Border = new KimTools.WinForms.KtBrushGradient(KimTools.WinForms.KtColor.BASE_1, KimTools.WinForms.KtColor.BASE_3);
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
            pnlItems.Controls.Add(flowLayoutPanel1);
            pnlItems.Dock = DockStyle.Fill;
            pnlItems.Foreground = KimTools.WinForms.KtColor.Empty;
            pnlItems.Location = new Point(0, 100);
            pnlItems.Name = "pnlItems";
            pnlItems.PatternColor = KimTools.WinForms.KtColor.Empty;
            pnlItems.Size = new Size(800, 271);
            pnlItems.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(57, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(743, 271);
            flowLayoutPanel1.TabIndex = 0;
            flowLayoutPanel1.WrapContents = false;
            // 
            // pnlBotones
            // 
            pnlBotones.Background = new KimTools.WinForms.KtBrushSolid(KimTools.WinForms.KtColor.BASE_2);
            pnlBotones.Border = new KimTools.WinForms.KtBrushGradient(KimTools.WinForms.KtColor.BASE_1, KimTools.WinForms.KtColor.BASE_3);
            pnlBotones.BorderRadius = 24F;
            pnlBotones.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            pnlBotones.BorderWidth = 1.5F;
            pnlBotones.Controls.Add(lblAviso);
            pnlBotones.Controls.Add(btnAceptar);
            pnlBotones.Controls.Add(btnCancelar);
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
            btnAceptar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAceptar.BackColor = Color.Transparent;
            btnAceptar.Background = new KimTools.WinForms.KtBrushGradient(KimTools.WinForms.KtColor.PRIMARY, KimTools.WinForms.KtColor.SECONDARY);
            btnAceptar.Border = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            btnAceptar.BorderMargin = new Padding(0);
            btnAceptar.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            btnAceptar.BorderWidth = 2F;
            btnAceptar.Cursor = Cursors.Default;
            btnAceptar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAceptar.ForeColor = Color.FromArgb(255, 255, 255);
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
            btnAceptar.TabIndex = 1;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancelar.BackColor = Color.Transparent;
            btnCancelar.Background = new KimTools.WinForms.KtBrushGradient(KimTools.WinForms.KtColor.PRIMARY, KimTools.WinForms.KtColor.SECONDARY);
            btnCancelar.Border = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            btnCancelar.BorderMargin = new Padding(0);
            btnCancelar.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            btnCancelar.BorderWidth = 2F;
            btnCancelar.Cursor = Cursors.Default;
            btnCancelar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.ForeColor = Color.FromArgb(255, 255, 255);
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
            btnCancelar.TabIndex = 0;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // FormAsignarOperario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlItems);
            Controls.Add(pnlBotones);
            Controls.Add(pnlTitulo);
            ForeColor = Color.FromArgb(255, 255, 255);
            FormBorderStyle = FormBorderStyle.None;
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
        private KimTools.WinForms.KtButton btnAceptar;
        private KimTools.WinForms.KtButton btnCancelar;
        private KimTools.WinForms.KtLabel lblTitulo;
        private FlowLayoutPanel flowLayoutPanel1;
        private KimTools.WinForms.KtLabel lblAviso;
    }
}
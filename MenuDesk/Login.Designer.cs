namespace MenuDesk
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            ktPictureBox1 = new KimTools.WinForms.KtPictureBox();
            ktPanel1 = new KimTools.WinForms.KtPanel();
            ktPanel2 = new KimTools.WinForms.KtPanel();
            lblError = new KimTools.WinForms.KtLabel();
            btnIngresar = new KimTools.WinForms.KtButton();
            txtClave = new KimTools.WinForms.KtTextBox();
            btnSalir = new KimTools.WinForms.KtButton();
            txtUsuario = new KimTools.WinForms.KtTextBox();
            ((System.ComponentModel.ISupportInitialize)ktPictureBox1).BeginInit();
            ktPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // ktPictureBox1
            // 
            ktPictureBox1.BackColor = Color.Transparent;
            ktPictureBox1.Dock = DockStyle.Fill;
            ktPictureBox1.Image = Properties.Resources.BackgroundLogin;
            ktPictureBox1.ImageBrush = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            ktPictureBox1.Location = new Point(0, 0);
            ktPictureBox1.Name = "ktPictureBox1";
            ktPictureBox1.Size = new Size(714, 450);
            ktPictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            ktPictureBox1.TabIndex = 0;
            ktPictureBox1.TabStop = false;
            // 
            // ktPanel1
            // 
            ktPanel1.Background = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(0, 78, 65), null, null));
            ktPanel1.Border = new KimTools.WinForms.KtBrushGradient(KimTools.WinForms.KtColor.BASE_1, KimTools.WinForms.KtColor.BASE_3);
            ktPanel1.BorderRadius = 24F;
            ktPanel1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            ktPanel1.BorderWidth = 1.5F;
            ktPanel1.Dock = DockStyle.Fill;
            ktPanel1.Foreground = KimTools.WinForms.KtColor.Empty;
            ktPanel1.Location = new Point(0, 0);
            ktPanel1.Name = "ktPanel1";
            ktPanel1.PatternColor = KimTools.WinForms.KtColor.Empty;
            ktPanel1.Size = new Size(714, 450);
            ktPanel1.TabIndex = 1;
            // 
            // ktPanel2
            // 
            ktPanel2.Background = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            ktPanel2.Border = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(173, 151, 98), null, null));
            ktPanel2.BorderRadius = 18F;
            ktPanel2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            ktPanel2.BorderWidth = 3F;
            ktPanel2.Controls.Add(lblError);
            ktPanel2.Controls.Add(btnIngresar);
            ktPanel2.Controls.Add(txtClave);
            ktPanel2.Controls.Add(btnSalir);
            ktPanel2.Controls.Add(txtUsuario);
            ktPanel2.Foreground = KimTools.WinForms.KtColor.Empty;
            ktPanel2.Location = new Point(151, 101);
            ktPanel2.Name = "ktPanel2";
            ktPanel2.PatternColor = KimTools.WinForms.KtColor.Empty;
            ktPanel2.PatternStyle = System.Drawing.Drawing2D.HatchStyle.Wave;
            ktPanel2.Size = new Size(412, 249);
            ktPanel2.TabIndex = 2;
            // 
            // lblError
            // 
            lblError.Align = ContentAlignment.TopLeft;
            lblError.Auto = false;
            lblError.Background = KimTools.WinForms.KtColor.Empty;
            lblError.Color = new KimTools.WinForms.KtColor(Color.FromArgb(150, 0, 0), null, null);
            lblError.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblError.Location = new Point(87, 129);
            lblError.Name = "lblError";
            lblError.Size = new Size(230, 63);
            lblError.TabIndex = 7;
            lblError.Visible = false;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.Transparent;
            btnIngresar.Background = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(45, 108, 99), null, null));
            btnIngresar.Border = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(13, 63, 59), null, null));
            btnIngresar.BorderMargin = new Padding(0);
            btnIngresar.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            btnIngresar.BorderWidth = 2F;
            btnIngresar.Cursor = Cursors.Default;
            btnIngresar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIngresar.ForeColor = Color.FromArgb(219, 240, 237);
            btnIngresar.Foreground = KimTools.WinForms.KtColor.Empty;
            btnIngresar.Icon = "";
            btnIngresar.IconColor = KimTools.WinForms.KtColor.Empty;
            btnIngresar.IconSize = 16;
            btnIngresar.IconStroke = 2.5D;
            btnIngresar.Location = new Point(87, 195);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Padding = new Padding(8, 0, 8, 0);
            btnIngresar.Pattern.Style = KimTools.WinForms.KtPatternStyle.Default;
            btnIngresar.Size = new Size(89, 39);
            btnIngresar.TabIndex = 6;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // txtClave
            // 
            txtClave.AcceptsReturn = false;
            txtClave.AcceptsTab = false;
            txtClave.AnimationSpeed = 200;
            txtClave.AutoCompleteMode = AutoCompleteMode.None;
            txtClave.AutoCompleteSource = AutoCompleteSource.None;
            txtClave.AutoSizeHeight = true;
            txtClave.AutoValidate = AutoValidate.EnableAllowFocusChange;
            txtClave.BackgroundImageLayout = ImageLayout.None;
            txtClave.Bg = new KimTools.WinForms.KtColor(Color.FromArgb(173, 151, 98), null, null);
            txtClave.Border = new KimTools.WinForms.KtColor(Color.FromArgb(0, 78, 65), null, null);
            txtClave.BorderActive = new KimTools.WinForms.KtColor(Color.Black, null, null);
            txtClave.Content = KimTools.WinForms.KtColor.CONTENT;
            txtClave.CustomIconLeft = null;
            txtClave.CustomIconRight = null;
            txtClave.DefaultFont = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtClave.ForeColor = Color.Empty;
            txtClave.HideSelection = true;
            txtClave.Location = new Point(87, 81);
            txtClave.MaxLength = 32767;
            txtClave.MinimumSize = new Size(1, 1);
            txtClave.Modified = false;
            txtClave.Name = "txtClave";
            txtClave.Password = false;
            txtClave.PasswordChar = '*';
            txtClave.ScrollBars = ScrollBars.None;
            txtClave.SelectedText = "";
            txtClave.SelectionLength = 0;
            txtClave.SelectionStart = 0;
            txtClave.ShortcutsEnabled = true;
            txtClave.Size = new Size(230, 35);
            txtClave.Style = KimTools.WinForms.KtTextBox.KtTextBoxStyle.Tailwind;
            txtClave.TabIndex = 5;
            txtClave.TextMarginBottom = 0;
            txtClave.TextPlaceholder = "Clave";
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.Transparent;
            btnSalir.Background = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(45, 108, 99), null, null));
            btnSalir.Border = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(13, 63, 59), null, null));
            btnSalir.BorderMargin = new Padding(0);
            btnSalir.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            btnSalir.BorderWidth = 2F;
            btnSalir.Cursor = Cursors.Default;
            btnSalir.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = Color.FromArgb(219, 240, 237);
            btnSalir.Foreground = KimTools.WinForms.KtColor.Empty;
            btnSalir.Icon = "";
            btnSalir.IconColor = KimTools.WinForms.KtColor.Empty;
            btnSalir.IconSize = 16;
            btnSalir.IconStroke = 2.5D;
            btnSalir.Location = new Point(228, 195);
            btnSalir.Name = "btnSalir";
            btnSalir.Padding = new Padding(8, 0, 8, 0);
            btnSalir.Pattern.Style = KimTools.WinForms.KtPatternStyle.Default;
            btnSalir.Size = new Size(89, 39);
            btnSalir.TabIndex = 4;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // txtUsuario
            // 
            txtUsuario.AcceptsReturn = false;
            txtUsuario.AcceptsTab = false;
            txtUsuario.AnimationSpeed = 200;
            txtUsuario.AutoCompleteMode = AutoCompleteMode.None;
            txtUsuario.AutoCompleteSource = AutoCompleteSource.None;
            txtUsuario.AutoSizeHeight = true;
            txtUsuario.AutoValidate = AutoValidate.EnableAllowFocusChange;
            txtUsuario.BackgroundImageLayout = ImageLayout.None;
            txtUsuario.Bg = new KimTools.WinForms.KtColor(Color.FromArgb(173, 151, 98), null, null);
            txtUsuario.Border = new KimTools.WinForms.KtColor(Color.FromArgb(0, 78, 65), null, null);
            txtUsuario.BorderActive = new KimTools.WinForms.KtColor(Color.Black, null, null);
            txtUsuario.Content = KimTools.WinForms.KtColor.CONTENT;
            txtUsuario.CustomIconLeft = null;
            txtUsuario.CustomIconRight = null;
            txtUsuario.DefaultFont = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtUsuario.ForeColor = Color.Empty;
            txtUsuario.HideSelection = true;
            txtUsuario.Location = new Point(87, 40);
            txtUsuario.MaxLength = 32767;
            txtUsuario.MinimumSize = new Size(1, 1);
            txtUsuario.Modified = false;
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Password = false;
            txtUsuario.PasswordChar = '\0';
            txtUsuario.ScrollBars = ScrollBars.None;
            txtUsuario.SelectedText = "";
            txtUsuario.SelectionLength = 0;
            txtUsuario.SelectionStart = 0;
            txtUsuario.ShortcutsEnabled = true;
            txtUsuario.Size = new Size(230, 35);
            txtUsuario.Style = KimTools.WinForms.KtTextBox.KtTextBoxStyle.Tailwind;
            txtUsuario.TabIndex = 2;
            txtUsuario.TextMarginBottom = 0;
            txtUsuario.TextPlaceholder = "Usuario";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 78, 65);
            Background = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(0, 78, 65), null, null));
            ClientSize = new Size(714, 450);
            Controls.Add(ktPanel2);
            Controls.Add(ktPictureBox1);
            Controls.Add(ktPanel1);
            ForeColor = Color.FromArgb(204, 255, 246);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)ktPictureBox1).EndInit();
            ktPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private KimTools.WinForms.KtPictureBox ktPictureBox1;
        private KimTools.WinForms.KtPanel ktPanel1;
        private KimTools.WinForms.KtPanel ktPanel2;
        private KimTools.WinForms.KtButton btnSalir;
        private KimTools.WinForms.KtTextBox txtUsuario;
        private KimTools.WinForms.KtTextBox txtClave;
        private KimTools.WinForms.KtButton btnIngresar;
        private KimTools.WinForms.KtLabel lblError;
    }
}
namespace MenuDesk
{
    partial class MenuPPal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ktPanel1 = new KimTools.WinForms.KtPanel();
            botonSolicitudes = new KimTools.WinForms.KtButton();
            ktPanel2 = new KimTools.WinForms.KtPanel();
            ktPictureBox1 = new KimTools.WinForms.KtPictureBox();
            ktPanel1.SuspendLayout();
            ktPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ktPictureBox1).BeginInit();
            SuspendLayout();
            // 
            // ktPanel1
            // 
            ktPanel1.Background = new KimTools.WinForms.KtBrushSolid(KimTools.WinForms.KtColor.BASE_2);
            ktPanel1.Border = new KimTools.WinForms.KtBrushGradient(KimTools.WinForms.KtColor.BASE_1, KimTools.WinForms.KtColor.BASE_3);
            ktPanel1.BorderRadius = 24F;
            ktPanel1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            ktPanel1.BorderWidth = 1.5F;
            ktPanel1.Controls.Add(botonSolicitudes);
            ktPanel1.Controls.Add(ktPanel2);
            ktPanel1.Dock = DockStyle.Left;
            ktPanel1.Foreground = KimTools.WinForms.KtColor.Empty;
            ktPanel1.Location = new Point(0, 0);
            ktPanel1.Name = "ktPanel1";
            ktPanel1.PatternColor = KimTools.WinForms.KtColor.Empty;
            ktPanel1.Size = new Size(360, 450);
            ktPanel1.TabIndex = 0;
            // 
            // botonSolicitudes
            // 
            botonSolicitudes.BackColor = Color.Transparent;
            botonSolicitudes.Background = (KimTools.WinForms.KtBrushSolid)KimTools.WinForms.KtBrush.Solid;
            botonSolicitudes.Border = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            botonSolicitudes.BorderMargin = new Padding(0);
            botonSolicitudes.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            botonSolicitudes.BorderWidth = 2F;
            botonSolicitudes.Cursor = Cursors.Default;
            botonSolicitudes.Dock = DockStyle.Top;
            botonSolicitudes.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            botonSolicitudes.ForeColor = Color.FromArgb(255, 255, 255);
            botonSolicitudes.Foreground = KimTools.WinForms.KtColor.Empty;
            botonSolicitudes.Icon = "";
            botonSolicitudes.IconColor = KimTools.WinForms.KtColor.Empty;
            botonSolicitudes.IconSize = 16;
            botonSolicitudes.IconStroke = 2.5D;
            botonSolicitudes.Location = new Point(0, 141);
            botonSolicitudes.Name = "botonSolicitudes";
            botonSolicitudes.Padding = new Padding(8, 0, 8, 0);
            botonSolicitudes.Pattern.Style = KimTools.WinForms.KtPatternStyle.Default;
            botonSolicitudes.Size = new Size(360, 60);
            botonSolicitudes.TabIndex = 1;
            botonSolicitudes.Text = "Solicitudes";
            botonSolicitudes.UseVisualStyleBackColor = false;
            // 
            // ktPanel2
            // 
            ktPanel2.Background = new KimTools.WinForms.KtBrushSolid(KimTools.WinForms.KtColor.BASE_2);
            ktPanel2.Border = new KimTools.WinForms.KtBrushGradient(KimTools.WinForms.KtColor.BASE_1, KimTools.WinForms.KtColor.BASE_3);
            ktPanel2.BorderRadius = 24F;
            ktPanel2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            ktPanel2.BorderWidth = 1.5F;
            ktPanel2.Controls.Add(ktPictureBox1);
            ktPanel2.Dock = DockStyle.Top;
            ktPanel2.Foreground = KimTools.WinForms.KtColor.Empty;
            ktPanel2.Location = new Point(0, 0);
            ktPanel2.Name = "ktPanel2";
            ktPanel2.PatternColor = KimTools.WinForms.KtColor.Empty;
            ktPanel2.Size = new Size(360, 141);
            ktPanel2.TabIndex = 0;
            // 
            // ktPictureBox1
            // 
            ktPictureBox1.BackColor = Color.Transparent;
            ktPictureBox1.Image = Properties.Resources.AlemanaLogo_SF;
            ktPictureBox1.ImageBrush = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            ktPictureBox1.Location = new Point(0, 0);
            ktPictureBox1.Name = "ktPictureBox1";
            ktPictureBox1.Size = new Size(360, 142);
            ktPictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            ktPictureBox1.TabIndex = 0;
            ktPictureBox1.TabStop = false;
            // 
            // MenuPPal
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ktPanel1);
            ForeColor = Color.FromArgb(255, 255, 255);
            Name = "MenuPPal";
            Text = "Form1";
            Load += Form1_Load;
            ktPanel1.ResumeLayout(false);
            ktPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ktPictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private KimTools.WinForms.KtPanel ktPanel1;
        private KimTools.WinForms.KtPanel ktPanel2;
        private KimTools.WinForms.KtPictureBox ktPictureBox1;
        private KimTools.WinForms.KtButton botonSolicitudes;
    }
}

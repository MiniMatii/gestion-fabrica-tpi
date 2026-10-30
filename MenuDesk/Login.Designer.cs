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
            ktPictureBox1 = new KimTools.WinForms.KtPictureBox();
            ktPanel1 = new KimTools.WinForms.KtPanel();
            ((System.ComponentModel.ISupportInitialize)ktPictureBox1).BeginInit();
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
            ktPanel1.Background = new KimTools.WinForms.KtBrushSolid(KimTools.WinForms.KtColor.BASE_2);
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
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 23, 43);
            ClientSize = new Size(714, 450);
            Controls.Add(ktPictureBox1);
            Controls.Add(ktPanel1);
            ForeColor = Color.FromArgb(255, 255, 255);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)ktPictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private KimTools.WinForms.KtPictureBox ktPictureBox1;
        private KimTools.WinForms.KtPanel ktPanel1;
    }
}
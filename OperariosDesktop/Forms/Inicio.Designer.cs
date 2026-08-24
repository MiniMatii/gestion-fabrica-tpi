

using KimTools.WinForms;

namespace OperariosDesktop.Forms
{
    partial class Inicio
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
            components = new System.ComponentModel.Container();
            ktTheme1 = new KtTheme(components);
            SuspendLayout();
            // 
            // ktTheme1
            // 
            ktTheme1.Accent = Color.FromArgb(0, 206, 209);
            ktTheme1.AccentContent = Color.FromArgb(255, 255, 255);
            ktTheme1.Base = Color.FromArgb(5, 81, 69);
            ktTheme1.BaseContent = Color.FromArgb(0, 0, 0);
            ktTheme1.Error = Color.FromArgb(255, 0, 0);
            ktTheme1.ErrorContent = Color.FromArgb(255, 228, 225);
            ktTheme1.Info = Color.FromArgb(30, 144, 255);
            ktTheme1.InfoContent = Color.FromArgb(176, 224, 230);
            ktTheme1.Primary = Color.FromArgb(65, 105, 225);
            ktTheme1.PrimaryContent = Color.FromArgb(255, 255, 255);
            ktTheme1.Secondary = Color.FromArgb(138, 43, 226);
            ktTheme1.SecondaryContent = Color.FromArgb(255, 255, 255);
            ktTheme1.Success = Color.FromArgb(60, 179, 113);
            ktTheme1.SuccessContent = Color.FromArgb(240, 255, 240);
            ktTheme1.Warning = Color.FromArgb(218, 165, 32);
            ktTheme1.WarningContent = Color.FromArgb(255, 255, 240);
            // 
            // Inicio
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(5, 81, 69);
            Background = (KtBrushSolid)KtBrush.Solid;
            ClientSize = new Size(1129, 625);
            ForeColor = Color.FromArgb(5, 81, 69);
            Foreground = KtColor.BASE_2;
            Name = "Inicio";
            PatternColor = KtColor.BASE_2;
            Text = "Inicio";
            Load += Inicio_Load;
            ResumeLayout(false);
        }

        #endregion

        private KtTheme ktTheme1;
    }
}
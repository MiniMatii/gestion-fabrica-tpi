namespace OperariosDesktop
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            ktTheme1 = new KimTools.WinForms.KtTheme(components);
            ktTooltips1 = new KimTools.WinForms.KtTooltips(components);
            SuspendLayout();
            // 
            // ktTheme1
            // 
            ktTheme1.Accent = Color.FromArgb(0, 206, 209);
            ktTheme1.AccentContent = Color.FromArgb(255, 255, 255);
            ktTheme1.Base = Color.FromArgb(30, 41, 57);
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
            // ktTooltips1
            // 
            ktTooltips1.Active = true;
            ktTooltips1.AllowAutoClose = false;
            ktTooltips1.AllowFading = true;
            ktTooltips1.AutoCloseDuration = 5000;
            ktTooltips1.Background = KimTools.WinForms.KtColor.BASE_2;
            ktTooltips1.Border = KimTools.WinForms.KtColor.BASE_1;
            ktTooltips1.ClickToShowDisplayControl = false;
            ktTooltips1.DisplayControl = null;
            ktTooltips1.EntryAnimationSpeed = 350;
            ktTooltips1.ExitAnimationSpeed = 200;
            ktTooltips1.Foreground = KimTools.WinForms.KtColor.CONTENT;
            ktTooltips1.GenerateAutoCloseDuration = false;
            ktTooltips1.IconMargin = 6;
            ktTooltips1.InitialDelay = 0;
            ktTooltips1.Name = "ktTooltips1";
            ktTooltips1.Opacity = 1D;
            ktTooltips1.Padding = new Padding(10);
            ktTooltips1.ReshowDelay = 100;
            ktTooltips1.ShowAlways = true;
            ktTooltips1.ShowBorders = false;
            ktTooltips1.ShowIcons = true;
            ktTooltips1.ShowShadows = true;
            ktTooltips1.Tag = null;
            ktTooltips1.TextFont = new Font("Segoe UI", 9F);
            ktTooltips1.TextMargin = 2;
            ktTooltips1.ToolTipPosition = new Point(0, 0);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private KimTools.WinForms.KtTheme ktTheme1;
        private KimTools.WinForms.KtTooltips ktTooltips1;
    }
}

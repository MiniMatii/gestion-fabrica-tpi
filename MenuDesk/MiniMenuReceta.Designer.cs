namespace MenuDesk
{
    partial class MiniMenuReceta
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
            KimTools.WinForms.KtToastHelpers.KtPages.KtPgAnimatorNS.Animation animation1 = new KimTools.WinForms.KtToastHelpers.KtPages.KtPgAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MiniMenuReceta));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            hudSuperiorCierre = new KimTools.WinForms.KtPanel();
            panelRecetas = new KimTools.WinForms.KtPanel();
            navBarRecetas = new KimTools.WinForms.KtPages();
            altaRecetaPage = new TabPage();
            altaRecetaSubPage = new KimTools.WinForms.KtPanel();
            ktPanel5 = new KimTools.WinForms.KtPanel();
            dgvMateriasAR = new KimTools.WinForms.KtTable();
            ktPanel6 = new KimTools.WinForms.KtPanel();
            lblMensaje = new KimTools.WinForms.KtLabel();
            buttonGuardarReceta = new KimTools.WinForms.KtButton();
            panelDescAR = new KimTools.WinForms.KtPanel();
            ktPanel3 = new KimTools.WinForms.KtPanel();
            textBoxDescAR = new KimTools.WinForms.KtTextBox();
            ktPanel42 = new KimTools.WinForms.KtPanel();
            ktPanel45 = new KimTools.WinForms.KtPanel();
            ktLabel46 = new KimTools.WinForms.KtLabel();
            ktPanel8 = new KimTools.WinForms.KtPanel();
            btnIrEliminar = new KimTools.WinForms.KtButton();
            eliminarRecetaPage = new TabPage();
            ktPanel7 = new KimTools.WinForms.KtPanel();
            ktPanel2 = new KimTools.WinForms.KtPanel();
            ktPanel4 = new KimTools.WinForms.KtPanel();
            tablaER = new KimTools.WinForms.KtTable();
            idER = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            ktPanel1 = new KimTools.WinForms.KtPanel();
            btnVolver = new KimTools.WinForms.KtButton();
            footerER = new KimTools.WinForms.KtPanel();
            buttonActualizarER = new KimTools.WinForms.KtButton();
            buttonGuardarER = new KimTools.WinForms.KtButton();
            panelRecetas.SuspendLayout();
            navBarRecetas.SuspendLayout();
            altaRecetaPage.SuspendLayout();
            altaRecetaSubPage.SuspendLayout();
            ktPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMateriasAR).BeginInit();
            ktPanel6.SuspendLayout();
            panelDescAR.SuspendLayout();
            ktPanel3.SuspendLayout();
            ktPanel42.SuspendLayout();
            ktPanel45.SuspendLayout();
            ktPanel8.SuspendLayout();
            eliminarRecetaPage.SuspendLayout();
            ktPanel7.SuspendLayout();
            ktPanel2.SuspendLayout();
            ktPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tablaER).BeginInit();
            ktPanel1.SuspendLayout();
            footerER.SuspendLayout();
            SuspendLayout();
            // 
            // hudSuperiorCierre
            // 
            hudSuperiorCierre.Background = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(173, 151, 98), null, null));
            hudSuperiorCierre.Border = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(173, 151, 98), null, null));
            hudSuperiorCierre.BorderEdges.BottomLeft = false;
            hudSuperiorCierre.BorderEdges.BottomRight = false;
            hudSuperiorCierre.BorderEdges.TopLeft = false;
            hudSuperiorCierre.BorderEdges.TopRight = false;
            hudSuperiorCierre.BorderRadius = 24F;
            hudSuperiorCierre.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            hudSuperiorCierre.BorderWidth = 1.5F;
            hudSuperiorCierre.Dock = DockStyle.Top;
            hudSuperiorCierre.Foreground = KimTools.WinForms.KtColor.Empty;
            hudSuperiorCierre.Location = new Point(0, 0);
            hudSuperiorCierre.Margin = new Padding(4);
            hudSuperiorCierre.Name = "hudSuperiorCierre";
            hudSuperiorCierre.PatternColor = KimTools.WinForms.KtColor.Empty;
            hudSuperiorCierre.Size = new Size(800, 28);
            hudSuperiorCierre.TabIndex = 1;
            // 
            // panelRecetas
            // 
            panelRecetas.Background = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            panelRecetas.Border = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            panelRecetas.BorderRadius = 24F;
            panelRecetas.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            panelRecetas.BorderWidth = 1.5F;
            panelRecetas.Controls.Add(navBarRecetas);
            panelRecetas.Dock = DockStyle.Fill;
            panelRecetas.Foreground = KimTools.WinForms.KtColor.Empty;
            panelRecetas.Location = new Point(0, 28);
            panelRecetas.Name = "panelRecetas";
            panelRecetas.PatternColor = KimTools.WinForms.KtColor.Empty;
            panelRecetas.Size = new Size(800, 422);
            panelRecetas.TabIndex = 4;
            // 
            // navBarRecetas
            // 
            navBarRecetas.Alignment = TabAlignment.Bottom;
            navBarRecetas.AllowTransitions = false;
            navBarRecetas.Background = KimTools.WinForms.KtColor.Empty;
            navBarRecetas.Controls.Add(altaRecetaPage);
            navBarRecetas.Controls.Add(eliminarRecetaPage);
            navBarRecetas.Dock = DockStyle.Fill;
            navBarRecetas.Location = new Point(0, 0);
            navBarRecetas.Multiline = true;
            navBarRecetas.Name = "navBarRecetas";
            navBarRecetas.SelectedIndex = 0;
            navBarRecetas.Size = new Size(800, 422);
            navBarRecetas.TabIndex = 0;
            animation1.AnimateOnlyDifferences = false;
            animation1.BlindCoeff = (PointF)resources.GetObject("animation1.BlindCoeff");
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = (PointF)resources.GetObject("animation1.MosaicCoeff");
            animation1.MosaicShift = (PointF)resources.GetObject("animation1.MosaicShift");
            animation1.MosaicSize = 0;
            animation1.Padding = new Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = (PointF)resources.GetObject("animation1.ScaleCoeff");
            animation1.SlideCoeff = (PointF)resources.GetObject("animation1.SlideCoeff");
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 0F;
            navBarRecetas.Transition = animation1;
            navBarRecetas.TransitionType = KimTools.WinForms.KtToastHelpers.KtPages.KtPgAnimatorNS.AnimationType.Custom;
            // 
            // altaRecetaPage
            // 
            navBarRecetas.Set_Background(altaRecetaPage, new KimTools.WinForms.KtColor(Color.FromArgb(173, 151, 98), null, null));
            altaRecetaPage.BackColor = Color.FromArgb(173, 151, 98);
            altaRecetaPage.Controls.Add(altaRecetaSubPage);
            altaRecetaPage.Controls.Add(ktPanel8);
            altaRecetaPage.Location = new Point(0, 0);
            altaRecetaPage.Name = "altaRecetaPage";
            altaRecetaPage.Padding = new Padding(3);
            altaRecetaPage.Size = new Size(800, 422);
            altaRecetaPage.TabIndex = 0;
            altaRecetaPage.Text = "tabPage1";
            // 
            // altaRecetaSubPage
            // 
            altaRecetaSubPage.Background = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            altaRecetaSubPage.Border = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            altaRecetaSubPage.BorderRadius = 24F;
            altaRecetaSubPage.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            altaRecetaSubPage.BorderWidth = 1.5F;
            altaRecetaSubPage.Controls.Add(ktPanel5);
            altaRecetaSubPage.Dock = DockStyle.Fill;
            altaRecetaSubPage.Foreground = KimTools.WinForms.KtColor.Empty;
            altaRecetaSubPage.Location = new Point(3, 45);
            altaRecetaSubPage.Name = "altaRecetaSubPage";
            altaRecetaSubPage.PatternColor = KimTools.WinForms.KtColor.Empty;
            altaRecetaSubPage.Size = new Size(794, 374);
            altaRecetaSubPage.TabIndex = 0;
            // 
            // ktPanel5
            // 
            ktPanel5.Background = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            ktPanel5.Border = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            ktPanel5.BorderRadius = 24F;
            ktPanel5.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            ktPanel5.BorderWidth = 1.5F;
            ktPanel5.Controls.Add(dgvMateriasAR);
            ktPanel5.Controls.Add(ktPanel6);
            ktPanel5.Controls.Add(panelDescAR);
            ktPanel5.Dock = DockStyle.Fill;
            ktPanel5.Foreground = KimTools.WinForms.KtColor.Empty;
            ktPanel5.Location = new Point(0, 0);
            ktPanel5.Name = "ktPanel5";
            ktPanel5.PatternColor = KimTools.WinForms.KtColor.Empty;
            ktPanel5.Size = new Size(794, 374);
            ktPanel5.TabIndex = 13;
            // 
            // dgvMateriasAR
            // 
            dgvMateriasAR.BackgroundColor = Color.FromArgb(173, 151, 98);
            dgvMateriasAR.BorderStyle = BorderStyle.None;
            dgvMateriasAR.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvMateriasAR.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 78, 65);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(173, 151, 98);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvMateriasAR.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvMateriasAR.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(0, 78, 65);
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(34, 29, 17);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(173, 151, 98);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvMateriasAR.DefaultCellStyle = dataGridViewCellStyle2;
            dgvMateriasAR.Dock = DockStyle.Fill;
            dgvMateriasAR.EnableHeadersVisualStyles = false;
            dgvMateriasAR.GridColor = Color.FromArgb(173, 151, 98);
            dgvMateriasAR.Location = new Point(0, 105);
            dgvMateriasAR.Name = "dgvMateriasAR";
            dgvMateriasAR.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvMateriasAR.RowHeadersVisible = false;
            dgvMateriasAR.RowHeadersWidth = 20;
            dgvMateriasAR.RowTemplate.Height = 45;
            dgvMateriasAR.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMateriasAR.Size = new Size(794, 221);
            dgvMateriasAR.Style.Background = KimTools.WinForms.KtColor.BASE_2;
            dgvMateriasAR.Style.Border = 0.99F;
            dgvMateriasAR.Style.Color = KimTools.WinForms.KtColor.PRIMARY;
            dgvMateriasAR.Style.Foreground = KimTools.WinForms.KtColor.CONTENT;
            dgvMateriasAR.Style.Header.Background = KimTools.WinForms.KtColor.Empty;
            dgvMateriasAR.Style.Header.Foreground = KimTools.WinForms.KtColor.Empty;
            dgvMateriasAR.Style.Row.Background = KimTools.WinForms.KtColor.BASE_2;
            dgvMateriasAR.Style.Row.Foreground = KimTools.WinForms.KtColor.CONTENT;
            dgvMateriasAR.Style.RowAlt.Background = KimTools.WinForms.KtColor.BASE_1;
            dgvMateriasAR.Style.RowAlt.Foreground = KimTools.WinForms.KtColor.CONTENT;
            dgvMateriasAR.Style.ScrollBar.Background = KimTools.WinForms.KtColor.Empty;
            dgvMateriasAR.Style.ScrollBar.Foreground = KimTools.WinForms.KtColor.Empty;
            dgvMateriasAR.TabIndex = 6;
            // 
            // ktPanel6
            // 
            ktPanel6.Background = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            ktPanel6.Border = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            ktPanel6.BorderRadius = 24F;
            ktPanel6.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            ktPanel6.BorderWidth = 1.5F;
            ktPanel6.Controls.Add(lblMensaje);
            ktPanel6.Controls.Add(buttonGuardarReceta);
            ktPanel6.Dock = DockStyle.Bottom;
            ktPanel6.Foreground = KimTools.WinForms.KtColor.Empty;
            ktPanel6.Location = new Point(0, 326);
            ktPanel6.Name = "ktPanel6";
            ktPanel6.PatternColor = KimTools.WinForms.KtColor.Empty;
            ktPanel6.Size = new Size(794, 48);
            ktPanel6.TabIndex = 5;
            // 
            // lblMensaje
            // 
            lblMensaje.Align = ContentAlignment.MiddleCenter;
            lblMensaje.Auto = false;
            lblMensaje.Background = KimTools.WinForms.KtColor.Empty;
            lblMensaje.Color = new KimTools.WinForms.KtColor(Color.Red, null, null);
            lblMensaje.Dock = DockStyle.Left;
            lblMensaje.Location = new Point(0, 0);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(375, 48);
            lblMensaje.TabIndex = 1;
            // 
            // buttonGuardarReceta
            // 
            buttonGuardarReceta.BackColor = Color.Transparent;
            buttonGuardarReceta.Background = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            buttonGuardarReceta.Border = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(0, 78, 65), null, null));
            buttonGuardarReceta.BorderMargin = new Padding(0);
            buttonGuardarReceta.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            buttonGuardarReceta.BorderWidth = 3F;
            buttonGuardarReceta.Cursor = Cursors.Default;
            buttonGuardarReceta.Dock = DockStyle.Right;
            buttonGuardarReceta.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonGuardarReceta.ForeColor = Color.FromArgb(34, 29, 17);
            buttonGuardarReceta.Foreground = KimTools.WinForms.KtColor.Empty;
            buttonGuardarReceta.Icon = "";
            buttonGuardarReceta.IconColor = KimTools.WinForms.KtColor.Empty;
            buttonGuardarReceta.IconSize = 16;
            buttonGuardarReceta.IconStroke = 2.5D;
            buttonGuardarReceta.Location = new Point(649, 0);
            buttonGuardarReceta.Name = "buttonGuardarReceta";
            buttonGuardarReceta.Padding = new Padding(8, 0, 8, 0);
            buttonGuardarReceta.Pattern.Style = KimTools.WinForms.KtPatternStyle.Default;
            buttonGuardarReceta.Size = new Size(145, 48);
            buttonGuardarReceta.TabIndex = 0;
            buttonGuardarReceta.Text = "Guardar";
            buttonGuardarReceta.UseVisualStyleBackColor = false;
            buttonGuardarReceta.Click += buttonGuardarReceta_Click;
            // 
            // panelDescAR
            // 
            panelDescAR.Background = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            panelDescAR.Border = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            panelDescAR.BorderRadius = 24F;
            panelDescAR.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            panelDescAR.BorderWidth = 1.5F;
            panelDescAR.Controls.Add(ktPanel3);
            panelDescAR.Controls.Add(ktPanel42);
            panelDescAR.Dock = DockStyle.Top;
            panelDescAR.Foreground = KimTools.WinForms.KtColor.Empty;
            panelDescAR.Location = new Point(0, 0);
            panelDescAR.Margin = new Padding(4);
            panelDescAR.Name = "panelDescAR";
            panelDescAR.PatternColor = KimTools.WinForms.KtColor.Empty;
            panelDescAR.Size = new Size(794, 105);
            panelDescAR.TabIndex = 3;
            // 
            // ktPanel3
            // 
            ktPanel3.Background = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(0, 0, 0), null, null));
            ktPanel3.Border = new KimTools.WinForms.KtBrushGradient(KimTools.WinForms.KtColor.BASE_1, KimTools.WinForms.KtColor.BASE_3);
            ktPanel3.BorderEdges.TopLeft = false;
            ktPanel3.BorderRadius = 90F;
            ktPanel3.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            ktPanel3.BorderWidth = 1.5F;
            ktPanel3.Controls.Add(textBoxDescAR);
            ktPanel3.Dock = DockStyle.Top;
            ktPanel3.Foreground = KimTools.WinForms.KtColor.Empty;
            ktPanel3.Location = new Point(0, 33);
            ktPanel3.Name = "ktPanel3";
            ktPanel3.PatternColor = KimTools.WinForms.KtColor.Empty;
            ktPanel3.Size = new Size(794, 64);
            ktPanel3.TabIndex = 1;
            // 
            // textBoxDescAR
            // 
            textBoxDescAR.AcceptsReturn = false;
            textBoxDescAR.AcceptsTab = false;
            textBoxDescAR.AccessibleRole = AccessibleRole.None;
            textBoxDescAR.AnimationSpeed = 200;
            textBoxDescAR.AutoCompleteMode = AutoCompleteMode.None;
            textBoxDescAR.AutoCompleteSource = AutoCompleteSource.None;
            textBoxDescAR.AutoSizeHeight = true;
            textBoxDescAR.AutoValidate = AutoValidate.EnableAllowFocusChange;
            textBoxDescAR.Bg = new KimTools.WinForms.KtColor(Color.FromArgb(0, 78, 65), null, null);
            textBoxDescAR.Border = new KimTools.WinForms.KtColor(Color.FromArgb(0, 0, 0), null, null);
            textBoxDescAR.BorderActive = new KimTools.WinForms.KtColor(Color.FromArgb(255, 255, 255), null, null);
            textBoxDescAR.BorderRadius = 60;
            textBoxDescAR.BorderThickness = 0;
            textBoxDescAR.Content = KimTools.WinForms.KtColor.CONTENT;
            textBoxDescAR.CustomIconLeft = null;
            textBoxDescAR.CustomIconRight = null;
            textBoxDescAR.DefaultFont = new Font("Segoe UI Symbol", 12F, FontStyle.Bold);
            textBoxDescAR.Dock = DockStyle.Fill;
            textBoxDescAR.ForeColor = Color.Empty;
            textBoxDescAR.HideSelection = true;
            textBoxDescAR.Location = new Point(0, 0);
            textBoxDescAR.MaxLength = 32767;
            textBoxDescAR.MinimumSize = new Size(1, 1);
            textBoxDescAR.Modified = false;
            textBoxDescAR.Name = "textBoxDescAR";
            textBoxDescAR.Password = false;
            textBoxDescAR.PasswordChar = '\0';
            textBoxDescAR.ScrollBars = ScrollBars.None;
            textBoxDescAR.SelectedText = "";
            textBoxDescAR.SelectionLength = 0;
            textBoxDescAR.SelectionStart = 0;
            textBoxDescAR.ShortcutsEnabled = true;
            textBoxDescAR.Size = new Size(794, 64);
            textBoxDescAR.Style = KimTools.WinForms.KtTextBox.KtTextBoxStyle.Tailwind;
            textBoxDescAR.TabIndex = 5;
            textBoxDescAR.TextMarginBottom = 0;
            textBoxDescAR.TextPlaceholder = "Ingrese aqui . . .";
            // 
            // ktPanel42
            // 
            ktPanel42.Background = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(173, 151, 98), null, null));
            ktPanel42.Border = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(173, 151, 98), null, null));
            ktPanel42.BorderRadius = 0F;
            ktPanel42.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            ktPanel42.BorderWidth = 0F;
            ktPanel42.Controls.Add(ktPanel45);
            ktPanel42.Dock = DockStyle.Top;
            ktPanel42.Foreground = new KimTools.WinForms.KtColor(Color.FromArgb(173, 151, 98), null, null);
            ktPanel42.Location = new Point(0, 0);
            ktPanel42.Margin = new Padding(4);
            ktPanel42.Name = "ktPanel42";
            ktPanel42.PatternColor = KimTools.WinForms.KtColor.Empty;
            ktPanel42.Size = new Size(794, 33);
            ktPanel42.TabIndex = 0;
            // 
            // ktPanel45
            // 
            ktPanel45.Background = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(0, 0, 0), null, null));
            ktPanel45.Border = new KimTools.WinForms.KtBrushGradient(KimTools.WinForms.KtColor.BASE_1, KimTools.WinForms.KtColor.BASE_3);
            ktPanel45.BorderEdges.BottomLeft = false;
            ktPanel45.BorderEdges.BottomRight = false;
            ktPanel45.BorderRadius = 24F;
            ktPanel45.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            ktPanel45.BorderWidth = 1.5F;
            ktPanel45.Controls.Add(ktLabel46);
            ktPanel45.Dock = DockStyle.Left;
            ktPanel45.Foreground = KimTools.WinForms.KtColor.Empty;
            ktPanel45.Location = new Point(0, 0);
            ktPanel45.Margin = new Padding(4);
            ktPanel45.Name = "ktPanel45";
            ktPanel45.PatternColor = KimTools.WinForms.KtColor.Empty;
            ktPanel45.Size = new Size(333, 33);
            ktPanel45.TabIndex = 1;
            // 
            // ktLabel46
            // 
            ktLabel46.Align = ContentAlignment.MiddleCenter;
            ktLabel46.Auto = false;
            ktLabel46.Background = KimTools.WinForms.KtColor.Empty;
            ktLabel46.Color = KimTools.WinForms.KtColor.CONTENT;
            ktLabel46.Dock = DockStyle.Fill;
            ktLabel46.Font = new Font("Segoe UI Symbol", 14F, FontStyle.Bold);
            ktLabel46.Location = new Point(0, 0);
            ktLabel46.Margin = new Padding(4, 0, 4, 0);
            ktLabel46.Name = "ktLabel46";
            ktLabel46.Size = new Size(333, 33);
            ktLabel46.TabIndex = 0;
            ktLabel46.Text = "DESCRIPCION";
            // 
            // ktPanel8
            // 
            ktPanel8.Background = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            ktPanel8.Border = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            ktPanel8.BorderRadius = 24F;
            ktPanel8.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            ktPanel8.BorderWidth = 1.5F;
            ktPanel8.Controls.Add(btnIrEliminar);
            ktPanel8.Dock = DockStyle.Top;
            ktPanel8.Foreground = KimTools.WinForms.KtColor.Empty;
            ktPanel8.Location = new Point(3, 3);
            ktPanel8.Name = "ktPanel8";
            ktPanel8.PatternColor = KimTools.WinForms.KtColor.Empty;
            ktPanel8.Size = new Size(794, 42);
            ktPanel8.TabIndex = 1;
            // 
            // btnIrEliminar
            // 
            btnIrEliminar.BackColor = Color.Transparent;
            btnIrEliminar.Background = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(173, 151, 98), null, null));
            btnIrEliminar.Border = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(0, 78, 65), null, null));
            btnIrEliminar.BorderMargin = new Padding(0);
            btnIrEliminar.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            btnIrEliminar.BorderWidth = 2.5F;
            btnIrEliminar.Cursor = Cursors.Default;
            btnIrEliminar.Dock = DockStyle.Right;
            btnIrEliminar.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnIrEliminar.ForeColor = Color.FromArgb(34, 29, 17);
            btnIrEliminar.Foreground = KimTools.WinForms.KtColor.Empty;
            btnIrEliminar.Icon = "tabler.arrow_narrow_right";
            btnIrEliminar.IconColor = KimTools.WinForms.KtColor.Empty;
            btnIrEliminar.IconSize = 25;
            btnIrEliminar.IconStroke = 2D;
            btnIrEliminar.ImageAlign = ContentAlignment.MiddleRight;
            btnIrEliminar.Location = new Point(649, 0);
            btnIrEliminar.Name = "btnIrEliminar";
            btnIrEliminar.Padding = new Padding(8, 0, 8, 0);
            btnIrEliminar.Pattern.Color = new KimTools.WinForms.KtColor(Color.FromArgb(173, 151, 98), null, null);
            btnIrEliminar.Size = new Size(145, 42);
            btnIrEliminar.TabIndex = 4;
            btnIrEliminar.Text = "Eliminar";
            btnIrEliminar.UseVisualStyleBackColor = false;
            btnIrEliminar.Click += EliminarReceta_Click;
            // 
            // eliminarRecetaPage
            // 
            navBarRecetas.Set_Background(eliminarRecetaPage, new KimTools.WinForms.KtColor(Color.FromArgb(173, 151, 98), null, null));
            eliminarRecetaPage.BackColor = Color.FromArgb(173, 151, 98);
            eliminarRecetaPage.Controls.Add(ktPanel7);
            eliminarRecetaPage.Location = new Point(4, 4);
            eliminarRecetaPage.Name = "eliminarRecetaPage";
            eliminarRecetaPage.Padding = new Padding(3);
            eliminarRecetaPage.Size = new Size(792, 394);
            eliminarRecetaPage.TabIndex = 2;
            eliminarRecetaPage.Text = "tabPage3";
            // 
            // ktPanel7
            // 
            ktPanel7.Background = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(173, 151, 98), null, null));
            ktPanel7.Border = new KimTools.WinForms.KtBrushGradient(KimTools.WinForms.KtColor.BASE_1, KimTools.WinForms.KtColor.BASE_3);
            ktPanel7.BorderRadius = 24F;
            ktPanel7.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            ktPanel7.BorderWidth = 1.5F;
            ktPanel7.Controls.Add(ktPanel2);
            ktPanel7.Controls.Add(ktPanel1);
            ktPanel7.Controls.Add(footerER);
            ktPanel7.Dock = DockStyle.Fill;
            ktPanel7.Foreground = KimTools.WinForms.KtColor.Empty;
            ktPanel7.Location = new Point(3, 3);
            ktPanel7.Name = "ktPanel7";
            ktPanel7.PatternColor = KimTools.WinForms.KtColor.Empty;
            ktPanel7.Size = new Size(786, 388);
            ktPanel7.TabIndex = 3;
            // 
            // ktPanel2
            // 
            ktPanel2.AutoScroll = true;
            ktPanel2.Background = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(173, 151, 98), null, null));
            ktPanel2.Border = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            ktPanel2.BorderEdges.BottomLeft = false;
            ktPanel2.BorderEdges.BottomRight = false;
            ktPanel2.BorderEdges.TopLeft = false;
            ktPanel2.BorderEdges.TopRight = false;
            ktPanel2.BorderRadius = 0F;
            ktPanel2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            ktPanel2.BorderWidth = 0F;
            ktPanel2.Controls.Add(ktPanel4);
            ktPanel2.Dock = DockStyle.Fill;
            ktPanel2.Font = new Font("Segoe UI Symbol", 8F, FontStyle.Bold);
            ktPanel2.Foreground = KimTools.WinForms.KtColor.Empty;
            ktPanel2.Location = new Point(0, 42);
            ktPanel2.Margin = new Padding(4);
            ktPanel2.Name = "ktPanel2";
            ktPanel2.Padding = new Padding(20, 20, 20, 10);
            ktPanel2.PatternColor = KimTools.WinForms.KtColor.Empty;
            ktPanel2.Size = new Size(786, 306);
            ktPanel2.TabIndex = 3;
            // 
            // ktPanel4
            // 
            ktPanel4.Background = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(173, 151, 98), null, null));
            ktPanel4.Border = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            ktPanel4.BorderRadius = 24F;
            ktPanel4.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            ktPanel4.BorderWidth = 1.5F;
            ktPanel4.Controls.Add(tablaER);
            ktPanel4.Dock = DockStyle.Fill;
            ktPanel4.Foreground = KimTools.WinForms.KtColor.Empty;
            ktPanel4.Location = new Point(20, 20);
            ktPanel4.Name = "ktPanel4";
            ktPanel4.PatternColor = KimTools.WinForms.KtColor.Empty;
            ktPanel4.Size = new Size(746, 276);
            ktPanel4.TabIndex = 6;
            // 
            // tablaER
            // 
            tablaER.AllowUserToAddRows = false;
            tablaER.AllowUserToDeleteRows = false;
            tablaER.AllowUserToResizeColumns = false;
            tablaER.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(0, 78, 65);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(0, 78, 65);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(127, 166, 160);
            tablaER.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            tablaER.BackgroundColor = Color.FromArgb(173, 151, 98);
            tablaER.BorderStyle = BorderStyle.None;
            tablaER.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
            tablaER.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
            tablaER.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(0, 78, 65);
            dataGridViewCellStyle4.Font = new Font("Segoe UI Symbol", 12F, FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(204, 255, 246);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(0, 78, 65);
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(204, 255, 246);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            tablaER.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            tablaER.ColumnHeadersHeight = 40;
            tablaER.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tablaER.Columns.AddRange(new DataGridViewColumn[] { idER, dataGridViewTextBoxColumn2 });
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(0, 78, 65);
            dataGridViewCellStyle5.Font = new Font("Segoe UI Symbol", 12F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(34, 29, 17);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(0, 78, 65);
            dataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(127, 166, 160);
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            tablaER.DefaultCellStyle = dataGridViewCellStyle5;
            tablaER.Dock = DockStyle.Fill;
            tablaER.EnableHeadersVisualStyles = false;
            tablaER.GridColor = Color.FromArgb(173, 151, 98);
            tablaER.Location = new Point(0, 0);
            tablaER.MultiSelect = false;
            tablaER.Name = "tablaER";
            tablaER.ReadOnly = true;
            tablaER.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(173, 151, 98);
            dataGridViewCellStyle6.Font = new Font("Segoe UI Symbol", 8F, FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(173, 151, 98);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(173, 151, 98);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(173, 151, 98);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            tablaER.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            tablaER.RowHeadersVisible = false;
            tablaER.RowHeadersWidth = 20;
            tablaER.RowTemplate.Height = 45;
            tablaER.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tablaER.Size = new Size(746, 276);
            tablaER.Style.Background = new KimTools.WinForms.KtColor(Color.FromArgb(173, 151, 98), null, null);
            tablaER.Style.Border = 0F;
            tablaER.Style.BorderHeader = 0F;
            tablaER.Style.Color = new KimTools.WinForms.KtColor(Color.FromArgb(0, 78, 65), null, null);
            tablaER.Style.Foreground = new KimTools.WinForms.KtColor(Color.FromArgb(173, 151, 98), null, null);
            tablaER.Style.Header.Background = KimTools.WinForms.KtColor.Empty;
            tablaER.Style.Header.Foreground = KimTools.WinForms.KtColor.Empty;
            tablaER.Style.Row.Background = new KimTools.WinForms.KtColor(Color.FromArgb(0, 78, 65), null, null);
            tablaER.Style.Row.Foreground = new KimTools.WinForms.KtColor(Color.White, null, null);
            tablaER.Style.RowAlt.Background = new KimTools.WinForms.KtColor(Color.FromArgb(0, 78, 65), null, null);
            tablaER.Style.RowAlt.Foreground = new KimTools.WinForms.KtColor(Color.White, null, null);
            tablaER.Style.ScrollBar.Background = KimTools.WinForms.KtColor.Empty;
            tablaER.Style.ScrollBar.Foreground = KimTools.WinForms.KtColor.Empty;
            tablaER.TabIndex = 1;
            // 
            // idER
            // 
            idER.DataPropertyName = "IdReceta";
            idER.Frozen = true;
            idER.HeaderText = "IdReceta";
            idER.MinimumWidth = 6;
            idER.Name = "idER";
            idER.ReadOnly = true;
            idER.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.DataPropertyName = "Descripcion";
            dataGridViewTextBoxColumn2.Frozen = true;
            dataGridViewTextBoxColumn2.HeaderText = "Descripción";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.Width = 125;
            // 
            // ktPanel1
            // 
            ktPanel1.Background = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(173, 151, 98), null, null));
            ktPanel1.Border = new KimTools.WinForms.KtBrushGradient(KimTools.WinForms.KtColor.BASE_1, KimTools.WinForms.KtColor.BASE_3);
            ktPanel1.BorderRadius = 24F;
            ktPanel1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            ktPanel1.BorderWidth = 1.5F;
            ktPanel1.Controls.Add(btnVolver);
            ktPanel1.Dock = DockStyle.Top;
            ktPanel1.Foreground = KimTools.WinForms.KtColor.Empty;
            ktPanel1.Location = new Point(0, 0);
            ktPanel1.Name = "ktPanel1";
            ktPanel1.PatternColor = KimTools.WinForms.KtColor.Empty;
            ktPanel1.Size = new Size(786, 42);
            ktPanel1.TabIndex = 14;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.Transparent;
            btnVolver.Background = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(173, 151, 98), null, null));
            btnVolver.Border = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(0, 78, 65), null, null));
            btnVolver.BorderMargin = new Padding(0);
            btnVolver.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            btnVolver.BorderWidth = 2.5F;
            btnVolver.Cursor = Cursors.Default;
            btnVolver.Dock = DockStyle.Right;
            btnVolver.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnVolver.ForeColor = Color.FromArgb(34, 29, 17);
            btnVolver.Foreground = KimTools.WinForms.KtColor.Empty;
            btnVolver.Icon = "tabler.arrow_narrow_left";
            btnVolver.IconColor = KimTools.WinForms.KtColor.Empty;
            btnVolver.IconSize = 25;
            btnVolver.IconStroke = 2D;
            btnVolver.Location = new Point(646, 0);
            btnVolver.Name = "btnVolver";
            btnVolver.Padding = new Padding(8, 0, 8, 0);
            btnVolver.Pattern.Color = new KimTools.WinForms.KtColor(Color.FromArgb(173, 151, 98), null, null);
            btnVolver.Size = new Size(140, 42);
            btnVolver.TabIndex = 3;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += altaRecetaButton_Click;
            // 
            // footerER
            // 
            footerER.Background = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            footerER.Border = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            footerER.BorderRadius = 24F;
            footerER.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            footerER.BorderWidth = 1.5F;
            footerER.Controls.Add(buttonActualizarER);
            footerER.Controls.Add(buttonGuardarER);
            footerER.Dock = DockStyle.Bottom;
            footerER.Foreground = KimTools.WinForms.KtColor.Empty;
            footerER.Location = new Point(0, 348);
            footerER.Name = "footerER";
            footerER.PatternColor = KimTools.WinForms.KtColor.Empty;
            footerER.Size = new Size(786, 40);
            footerER.TabIndex = 13;
            // 
            // buttonActualizarER
            // 
            buttonActualizarER.BackColor = Color.Transparent;
            buttonActualizarER.Background = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(173, 151, 98), null, null));
            buttonActualizarER.Border = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(0, 78, 65), null, null));
            buttonActualizarER.BorderMargin = new Padding(0);
            buttonActualizarER.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            buttonActualizarER.BorderWidth = 2.5F;
            buttonActualizarER.Cursor = Cursors.Default;
            buttonActualizarER.Dock = DockStyle.Left;
            buttonActualizarER.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            buttonActualizarER.ForeColor = Color.FromArgb(34, 29, 17);
            buttonActualizarER.Foreground = KimTools.WinForms.KtColor.Empty;
            buttonActualizarER.Icon = "";
            buttonActualizarER.IconColor = KimTools.WinForms.KtColor.Empty;
            buttonActualizarER.IconSize = 16;
            buttonActualizarER.IconStroke = 2.5D;
            buttonActualizarER.Location = new Point(213, 0);
            buttonActualizarER.Name = "buttonActualizarER";
            buttonActualizarER.Padding = new Padding(8, 0, 8, 0);
            buttonActualizarER.Pattern.Color = new KimTools.WinForms.KtColor(Color.FromArgb(173, 151, 98), null, null);
            buttonActualizarER.Size = new Size(213, 40);
            buttonActualizarER.TabIndex = 2;
            buttonActualizarER.Text = "Actualizar";
            buttonActualizarER.UseVisualStyleBackColor = false;
            // 
            // buttonGuardarER
            // 
            buttonGuardarER.BackColor = Color.Transparent;
            buttonGuardarER.Background = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(173, 151, 98), null, null));
            buttonGuardarER.Border = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(0, 78, 65), null, null));
            buttonGuardarER.BorderMargin = new Padding(0);
            buttonGuardarER.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            buttonGuardarER.BorderWidth = 2.5F;
            buttonGuardarER.Cursor = Cursors.Default;
            buttonGuardarER.Dock = DockStyle.Left;
            buttonGuardarER.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            buttonGuardarER.ForeColor = Color.FromArgb(34, 29, 17);
            buttonGuardarER.Foreground = KimTools.WinForms.KtColor.Empty;
            buttonGuardarER.Icon = "";
            buttonGuardarER.IconColor = KimTools.WinForms.KtColor.Empty;
            buttonGuardarER.IconSize = 16;
            buttonGuardarER.IconStroke = 2.5D;
            buttonGuardarER.Location = new Point(0, 0);
            buttonGuardarER.Name = "buttonGuardarER";
            buttonGuardarER.Padding = new Padding(8, 0, 8, 0);
            buttonGuardarER.Pattern.Color = new KimTools.WinForms.KtColor(Color.FromArgb(173, 151, 98), null, null);
            buttonGuardarER.Size = new Size(213, 40);
            buttonGuardarER.TabIndex = 1;
            buttonGuardarER.Text = "Eliminar";
            buttonGuardarER.UseVisualStyleBackColor = false;
            // 
            // MiniMenuReceta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(173, 151, 98);
            Background = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(173, 151, 98), null, null));
            ClientSize = new Size(800, 450);
            Controls.Add(panelRecetas);
            Controls.Add(hudSuperiorCierre);
            ForeColor = Color.FromArgb(34, 29, 17);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MiniMenuReceta";
            Text = "MiniMenuReceta";
            Load += MiniMenuReceta_Load;
            panelRecetas.ResumeLayout(false);
            navBarRecetas.ResumeLayout(false);
            altaRecetaPage.ResumeLayout(false);
            altaRecetaSubPage.ResumeLayout(false);
            ktPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMateriasAR).EndInit();
            ktPanel6.ResumeLayout(false);
            panelDescAR.ResumeLayout(false);
            ktPanel3.ResumeLayout(false);
            ktPanel42.ResumeLayout(false);
            ktPanel45.ResumeLayout(false);
            ktPanel8.ResumeLayout(false);
            eliminarRecetaPage.ResumeLayout(false);
            ktPanel7.ResumeLayout(false);
            ktPanel2.ResumeLayout(false);
            ktPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tablaER).EndInit();
            ktPanel1.ResumeLayout(false);
            footerER.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private KimTools.WinForms.KtPanel hudSuperiorCierre;
        private KimTools.WinForms.KtPanel panelRecetas;
        private KimTools.WinForms.KtPages navBarRecetas;
        private TabPage altaRecetaPage;
        private KimTools.WinForms.KtPanel altaRecetaSubPage;
        private KimTools.WinForms.KtPanel panelApellidoOp;
        private KimTools.WinForms.KtPanel ktPanel46;
        private KimTools.WinForms.KtTextBox apellidoOpText;
        private KimTools.WinForms.KtPanel ktPanel47;
        private KimTools.WinForms.KtPanel ktPanel48;
        private KimTools.WinForms.KtLabel ktLabel10;
        private KimTools.WinForms.KtDivider ktDivider10;
        private KimTools.WinForms.KtDivider ktDivider21;
        private KimTools.WinForms.KtPanel ktPanel66;
        private KimTools.WinForms.KtPanel ktPanel69;
        private KimTools.WinForms.KtTextBox valorEstadoC;
        private KimTools.WinForms.KtPanel ktPanel70;
        private KimTools.WinForms.KtPanel ktPanel71;
        private KimTools.WinForms.KtLabel ktLabel12;
        private KimTools.WinForms.KtDivider ktDivider18;
        private KimTools.WinForms.KtPanel ktPanel62;
        private KimTools.WinForms.KtPanel ktPanel63;
        private KimTools.WinForms.KtTextBox valorApelldioC;
        private KimTools.WinForms.KtPanel ktPanel64;
        private KimTools.WinForms.KtPanel ktPanel65;
        private KimTools.WinForms.KtLabel ktLabel11;
        private TabPage eliminarRecetaPage;
        private KimTools.WinForms.KtPanel ktPanel5;
        private KimTools.WinForms.KtPanel panelDescAR;
        private KimTools.WinForms.KtPanel ktPanel42;
        private KimTools.WinForms.KtPanel ktPanel45;
        private KimTools.WinForms.KtLabel ktLabel46;
        private KimTools.WinForms.KtTable dgvMateriasAR;
        private KimTools.WinForms.KtPanel ktPanel6;
        private KimTools.WinForms.KtButton buttonGuardarReceta;
        private KimTools.WinForms.KtPanel ktPanel3;
        private KimTools.WinForms.KtTextBox textBoxDescAR;
        private KimTools.WinForms.KtLabel lblMensaje;
        private KimTools.WinForms.KtPanel ktPanel7;
        private KimTools.WinForms.KtPanel ktPanel2;
        private KimTools.WinForms.KtPanel ktPanel4;
        private KimTools.WinForms.KtTable tablaER;
        private DataGridViewTextBoxColumn idER;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private KimTools.WinForms.KtPanel ktPanel1;
        private KimTools.WinForms.KtButton btnVolver;
        private KimTools.WinForms.KtPanel footerER;
        private KimTools.WinForms.KtButton buttonActualizarER;
        private KimTools.WinForms.KtButton buttonGuardarER;
        private KimTools.WinForms.KtPanel ktPanel8;
        private KimTools.WinForms.KtButton btnIrEliminar;
    }
}
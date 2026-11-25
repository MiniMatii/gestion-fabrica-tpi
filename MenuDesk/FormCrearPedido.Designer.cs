namespace MenuDesk
{
    partial class FormCrearPedido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCrearPedido));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            hudLateral = new KimTools.WinForms.KtPanel();
            ContenedorPanel = new KimTools.WinForms.KtPanel();
            ktPanel5 = new KimTools.WinForms.KtPanel();
            fechaIng = new KimTools.WinForms.KtPanel();
            fechaEstimada = new KimTools.WinForms.KtDate();
            ktPanel10 = new KimTools.WinForms.KtPanel();
            ktPanel11 = new KimTools.WinForms.KtPanel();
            ktLabel1 = new KimTools.WinForms.KtLabel();
            ktPanel3 = new KimTools.WinForms.KtPanel();
            btnSalirPedidosSucursal = new KimTools.WinForms.KtButton();
            btnEnviarPedido = new KimTools.WinForms.KtButton();
            SeguimientoPedidosPage = new KimTools.WinForms.KtRadioButton();
            GenerarPedidosPage = new KimTools.WinForms.KtRadioButton();
            ktDivider1 = new KimTools.WinForms.KtDivider();
            ktPanel4 = new KimTools.WinForms.KtPanel();
            ktPictureBox2 = new KimTools.WinForms.KtPictureBox();
            PagePedidoSucursal = new KimTools.WinForms.KtPages();
            CrearPedido = new TabPage();
            tablaGPedido = new KimTools.WinForms.KtTable();
            Id = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            Camara = new DataGridViewTextBoxColumn();
            Disponible = new DataGridViewTextBoxColumn();
            StockActual = new DataGridViewTextBoxColumn();
            IdCap = new DataGridViewTextBoxColumn();
            IdReceta = new DataGridViewTextBoxColumn();
            CantidadSolicitada = new DataGridViewTextBoxColumn();
            ktPanel2 = new KimTools.WinForms.KtPanel();
            hudSuperiorCierre = new KimTools.WinForms.KtPanel();
            ktButton1 = new KimTools.WinForms.KtButton();
            ktButton2 = new KimTools.WinForms.KtButton();
            ktButton3 = new KimTools.WinForms.KtButton();
            hudLateral.SuspendLayout();
            ContenedorPanel.SuspendLayout();
            ktPanel5.SuspendLayout();
            fechaIng.SuspendLayout();
            ktPanel10.SuspendLayout();
            ktPanel11.SuspendLayout();
            ktPanel3.SuspendLayout();
            ktPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ktPictureBox2).BeginInit();
            PagePedidoSucursal.SuspendLayout();
            CrearPedido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tablaGPedido).BeginInit();
            hudSuperiorCierre.SuspendLayout();
            SuspendLayout();
            // 
            // hudLateral
            // 
            hudLateral.Background = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(0, 78, 65), null, null));
            hudLateral.BackgroundImageLayout = ImageLayout.None;
            hudLateral.Border = new KimTools.WinForms.KtBrushGradient(new KimTools.WinForms.KtColor(Color.FromArgb(0, 78, 65), null, null), new KimTools.WinForms.KtColor(Color.FromArgb(173, 151, 98), null, null), 180);
            hudLateral.BorderEdges.BottomLeft = false;
            hudLateral.BorderEdges.BottomRight = false;
            hudLateral.BorderEdges.TopLeft = false;
            hudLateral.BorderEdges.TopRight = false;
            hudLateral.BorderRadius = 24F;
            hudLateral.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            hudLateral.BorderWidth = 0F;
            hudLateral.Controls.Add(ContenedorPanel);
            hudLateral.Controls.Add(ktPanel3);
            hudLateral.Controls.Add(SeguimientoPedidosPage);
            hudLateral.Controls.Add(GenerarPedidosPage);
            hudLateral.Controls.Add(ktDivider1);
            hudLateral.Controls.Add(ktPanel4);
            hudLateral.Dock = DockStyle.Left;
            hudLateral.Foreground = KimTools.WinForms.KtColor.Empty;
            hudLateral.Location = new Point(0, 0);
            hudLateral.Margin = new Padding(4);
            hudLateral.Name = "hudLateral";
            hudLateral.PatternColor = KimTools.WinForms.KtColor.Empty;
            hudLateral.Size = new Size(340, 900);
            hudLateral.TabIndex = 2;
            // 
            // ContenedorPanel
            // 
            ContenedorPanel.Background = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            ContenedorPanel.Border = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            ContenedorPanel.BorderRadius = 24F;
            ContenedorPanel.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            ContenedorPanel.BorderWidth = 1.5F;
            ContenedorPanel.Controls.Add(ktPanel5);
            ContenedorPanel.Controls.Add(ktPanel10);
            ContenedorPanel.Dock = DockStyle.Bottom;
            ContenedorPanel.Foreground = KimTools.WinForms.KtColor.Empty;
            ContenedorPanel.Location = new Point(0, 651);
            ContenedorPanel.Margin = new Padding(4);
            ContenedorPanel.Name = "ContenedorPanel";
            ContenedorPanel.Padding = new Padding(10, 0, 10, 0);
            ContenedorPanel.PatternColor = KimTools.WinForms.KtColor.Empty;
            ContenedorPanel.Size = new Size(340, 86);
            ContenedorPanel.TabIndex = 12;
            // 
            // ktPanel5
            // 
            ktPanel5.Background = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(0, 0, 0), null, null));
            ktPanel5.Border = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.Black, null, null));
            ktPanel5.BorderEdges.TopLeft = false;
            ktPanel5.BorderEdges.TopRight = false;
            ktPanel5.BorderRadius = 45F;
            ktPanel5.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            ktPanel5.BorderWidth = 1.5F;
            ktPanel5.Controls.Add(fechaIng);
            ktPanel5.Dock = DockStyle.Top;
            ktPanel5.Foreground = KimTools.WinForms.KtColor.Empty;
            ktPanel5.Location = new Point(10, 40);
            ktPanel5.Name = "ktPanel5";
            ktPanel5.PatternColor = KimTools.WinForms.KtColor.Empty;
            ktPanel5.Size = new Size(320, 46);
            ktPanel5.TabIndex = 1;
            // 
            // fechaIng
            // 
            fechaIng.Background = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(173, 151, 98), null, null));
            fechaIng.Border = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(0, 0, 0), null, null));
            fechaIng.BorderRadius = 45F;
            fechaIng.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            fechaIng.BorderWidth = 2.5F;
            fechaIng.Controls.Add(fechaEstimada);
            fechaIng.Dock = DockStyle.Fill;
            fechaIng.Foreground = KimTools.WinForms.KtColor.Empty;
            fechaIng.Location = new Point(0, 0);
            fechaIng.Name = "fechaIng";
            fechaIng.PatternColor = KimTools.WinForms.KtColor.Empty;
            fechaIng.Size = new Size(320, 46);
            fechaIng.TabIndex = 0;
            // 
            // fechaEstimada
            // 
            fechaEstimada.BackColor = Color.Transparent;
            fechaEstimada.Background = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            fechaEstimada.Border = KimTools.WinForms.KtColor.Empty;
            fechaEstimada.BorderWidth = 1.5F;
            fechaEstimada.DisplayWeekNumbers = true;
            fechaEstimada.Dock = DockStyle.Fill;
            fechaEstimada.DPHeight = 0;
            fechaEstimada.Font = new Font("Segoe UI Symbol", 20F, FontStyle.Bold);
            fechaEstimada.Format = DateTimePickerFormat.Short;
            fechaEstimada.IconAlign = HorizontalAlignment.Center;
            fechaEstimada.IconColor = KimTools.WinForms.KtColor.Empty;
            fechaEstimada.Location = new Point(0, 0);
            fechaEstimada.MinimumSize = new Size(0, 40);
            fechaEstimada.Name = "fechaEstimada";
            fechaEstimada.Size = new Size(320, 52);
            fechaEstimada.TabIndex = 0;
            fechaEstimada.TextAlign = HorizontalAlignment.Center;
            fechaEstimada.TextColor = KimTools.WinForms.KtColor.Empty;
            fechaEstimada.TextMargin = 8;
            // 
            // ktPanel10
            // 
            ktPanel10.Background = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            ktPanel10.Border = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(173, 151, 98), null, null));
            ktPanel10.BorderRadius = 0F;
            ktPanel10.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            ktPanel10.BorderWidth = 0F;
            ktPanel10.Controls.Add(ktPanel11);
            ktPanel10.Dock = DockStyle.Top;
            ktPanel10.Foreground = new KimTools.WinForms.KtColor(Color.FromArgb(173, 151, 98), null, null);
            ktPanel10.Location = new Point(10, 0);
            ktPanel10.Margin = new Padding(4);
            ktPanel10.Name = "ktPanel10";
            ktPanel10.PatternColor = KimTools.WinForms.KtColor.Empty;
            ktPanel10.Size = new Size(320, 40);
            ktPanel10.TabIndex = 0;
            // 
            // ktPanel11
            // 
            ktPanel11.Background = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(0, 0, 0), null, null));
            ktPanel11.Border = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.Black, null, null));
            ktPanel11.BorderEdges.BottomLeft = false;
            ktPanel11.BorderEdges.BottomRight = false;
            ktPanel11.BorderRadius = 24F;
            ktPanel11.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            ktPanel11.BorderWidth = 1.5F;
            ktPanel11.Controls.Add(ktLabel1);
            ktPanel11.Dock = DockStyle.Fill;
            ktPanel11.Foreground = KimTools.WinForms.KtColor.Empty;
            ktPanel11.Location = new Point(0, 0);
            ktPanel11.Margin = new Padding(4);
            ktPanel11.Name = "ktPanel11";
            ktPanel11.PatternColor = KimTools.WinForms.KtColor.Empty;
            ktPanel11.Size = new Size(320, 40);
            ktPanel11.TabIndex = 1;
            // 
            // ktLabel1
            // 
            ktLabel1.Align = ContentAlignment.MiddleCenter;
            ktLabel1.Auto = false;
            ktLabel1.Background = KimTools.WinForms.KtColor.Empty;
            ktLabel1.Color = KimTools.WinForms.KtColor.CONTENT;
            ktLabel1.Dock = DockStyle.Fill;
            ktLabel1.Font = new Font("Segoe UI Symbol", 14F, FontStyle.Bold);
            ktLabel1.Location = new Point(0, 0);
            ktLabel1.Margin = new Padding(4, 0, 4, 0);
            ktLabel1.Name = "ktLabel1";
            ktLabel1.Size = new Size(320, 40);
            ktLabel1.TabIndex = 0;
            ktLabel1.Text = "Fecha Entrega";
            // 
            // ktPanel3
            // 
            ktPanel3.Background = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            ktPanel3.Border = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            ktPanel3.BorderEdges.BottomLeft = false;
            ktPanel3.BorderEdges.BottomRight = false;
            ktPanel3.BorderEdges.TopLeft = false;
            ktPanel3.BorderEdges.TopRight = false;
            ktPanel3.BorderRadius = 24F;
            ktPanel3.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            ktPanel3.BorderWidth = 1.5F;
            ktPanel3.Controls.Add(btnSalirPedidosSucursal);
            ktPanel3.Controls.Add(btnEnviarPedido);
            ktPanel3.Dock = DockStyle.Bottom;
            ktPanel3.Foreground = KimTools.WinForms.KtColor.Empty;
            ktPanel3.Location = new Point(0, 737);
            ktPanel3.Name = "ktPanel3";
            ktPanel3.Padding = new Padding(20);
            ktPanel3.PatternColor = KimTools.WinForms.KtColor.Empty;
            ktPanel3.Size = new Size(340, 163);
            ktPanel3.TabIndex = 11;
            // 
            // btnSalirPedidosSucursal
            // 
            btnSalirPedidosSucursal.BackColor = Color.Transparent;
            btnSalirPedidosSucursal.Background = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(45, 108, 99), null, null));
            btnSalirPedidosSucursal.Border = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(13, 63, 59), null, null));
            btnSalirPedidosSucursal.BorderMargin = new Padding(0);
            btnSalirPedidosSucursal.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            btnSalirPedidosSucursal.BorderWidth = 2F;
            btnSalirPedidosSucursal.Cursor = Cursors.Default;
            btnSalirPedidosSucursal.Dock = DockStyle.Bottom;
            btnSalirPedidosSucursal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalirPedidosSucursal.ForeColor = Color.FromArgb(219, 240, 237);
            btnSalirPedidosSucursal.Foreground = KimTools.WinForms.KtColor.Empty;
            btnSalirPedidosSucursal.Icon = "";
            btnSalirPedidosSucursal.IconColor = KimTools.WinForms.KtColor.Empty;
            btnSalirPedidosSucursal.IconSize = 16;
            btnSalirPedidosSucursal.IconStroke = 2.5D;
            btnSalirPedidosSucursal.Location = new Point(20, 104);
            btnSalirPedidosSucursal.Name = "btnSalirPedidosSucursal";
            btnSalirPedidosSucursal.Padding = new Padding(8, 0, 8, 0);
            btnSalirPedidosSucursal.Pattern.Style = KimTools.WinForms.KtPatternStyle.Default;
            btnSalirPedidosSucursal.Size = new Size(300, 39);
            btnSalirPedidosSucursal.TabIndex = 12;
            btnSalirPedidosSucursal.Text = "Salir";
            btnSalirPedidosSucursal.UseVisualStyleBackColor = false;
            // 
            // btnEnviarPedido
            // 
            btnEnviarPedido.BackColor = Color.Transparent;
            btnEnviarPedido.Background = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(45, 108, 99), null, null));
            btnEnviarPedido.Border = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(13, 63, 59), null, null));
            btnEnviarPedido.BorderMargin = new Padding(0);
            btnEnviarPedido.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            btnEnviarPedido.BorderWidth = 2F;
            btnEnviarPedido.Cursor = Cursors.Default;
            btnEnviarPedido.Dock = DockStyle.Top;
            btnEnviarPedido.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEnviarPedido.ForeColor = Color.FromArgb(219, 240, 237);
            btnEnviarPedido.Foreground = KimTools.WinForms.KtColor.Empty;
            btnEnviarPedido.Icon = "";
            btnEnviarPedido.IconColor = KimTools.WinForms.KtColor.Empty;
            btnEnviarPedido.IconSize = 16;
            btnEnviarPedido.IconStroke = 2.5D;
            btnEnviarPedido.Location = new Point(20, 20);
            btnEnviarPedido.Name = "btnEnviarPedido";
            btnEnviarPedido.Padding = new Padding(8, 0, 8, 0);
            btnEnviarPedido.Pattern.Style = KimTools.WinForms.KtPatternStyle.Default;
            btnEnviarPedido.Size = new Size(300, 39);
            btnEnviarPedido.TabIndex = 11;
            btnEnviarPedido.Text = "Enviar";
            btnEnviarPedido.UseVisualStyleBackColor = false;
            btnEnviarPedido.Click += buttonGenerarPedido_Click;
            // 
            // SeguimientoPedidosPage
            // 
            SeguimientoPedidosPage.BackColor = Color.Transparent;
            SeguimientoPedidosPage.Background = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            SeguimientoPedidosPage.Background_Checked = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            SeguimientoPedidosPage.Border = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            SeguimientoPedidosPage.Border_Checked = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            SeguimientoPedidosPage.BorderEdges.BottomRight = false;
            SeguimientoPedidosPage.BorderEdges.TopRight = false;
            SeguimientoPedidosPage.BorderMargin = new Padding(0);
            SeguimientoPedidosPage.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            SeguimientoPedidosPage.BorderStyle_Checked = System.Drawing.Drawing2D.DashStyle.Solid;
            SeguimientoPedidosPage.BorderWidth = 0F;
            SeguimientoPedidosPage.Cursor = Cursors.Default;
            SeguimientoPedidosPage.Dock = DockStyle.Top;
            SeguimientoPedidosPage.Font = new Font("Segoe UI Symbol", 12F, FontStyle.Bold);
            SeguimientoPedidosPage.ForeColor = Color.White;
            SeguimientoPedidosPage.Foreground = new KimTools.WinForms.KtColor(Color.White, null, null);
            SeguimientoPedidosPage.Foreground_Checked = new KimTools.WinForms.KtColor(Color.FromArgb(173, 151, 98), null, null);
            SeguimientoPedidosPage.Icon = "tabler.building_factory_2";
            SeguimientoPedidosPage.Icon_Checked = "tabler.user";
            SeguimientoPedidosPage.IconColor = KimTools.WinForms.KtColor.Empty;
            SeguimientoPedidosPage.IconColor_Checked = KimTools.WinForms.KtColor.Empty;
            SeguimientoPedidosPage.IconSize = 32;
            SeguimientoPedidosPage.IconStroke = 1D;
            SeguimientoPedidosPage.Location = new Point(0, 368);
            SeguimientoPedidosPage.Margin = new Padding(0);
            SeguimientoPedidosPage.Name = "SeguimientoPedidosPage";
            SeguimientoPedidosPage.Padding = new Padding(8, 0, 8, 0);
            SeguimientoPedidosPage.Pattern.Color = new KimTools.WinForms.KtColor(Color.FromArgb(173, 151, 98), null, null);
            SeguimientoPedidosPage.Size = new Size(340, 67);
            SeguimientoPedidosPage.TabIndex = 9;
            SeguimientoPedidosPage.Text = "SEGUIMIENTO";
            SeguimientoPedidosPage.UseVisualStyleBackColor = false;
            // 
            // GenerarPedidosPage
            // 
            GenerarPedidosPage.BackColor = Color.Transparent;
            GenerarPedidosPage.Background = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            GenerarPedidosPage.Background_Checked = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            GenerarPedidosPage.Border = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            GenerarPedidosPage.Border_Checked = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            GenerarPedidosPage.BorderEdges.BottomRight = false;
            GenerarPedidosPage.BorderEdges.TopRight = false;
            GenerarPedidosPage.BorderMargin = new Padding(0);
            GenerarPedidosPage.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            GenerarPedidosPage.BorderStyle_Checked = System.Drawing.Drawing2D.DashStyle.Solid;
            GenerarPedidosPage.BorderWidth = 0F;
            GenerarPedidosPage.Cursor = Cursors.Default;
            GenerarPedidosPage.Dock = DockStyle.Top;
            GenerarPedidosPage.Font = new Font("Segoe UI Symbol", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            GenerarPedidosPage.ForeColor = Color.White;
            GenerarPedidosPage.Foreground = new KimTools.WinForms.KtColor(Color.White, null, null);
            GenerarPedidosPage.Foreground_Checked = new KimTools.WinForms.KtColor(Color.FromArgb(173, 151, 98), null, null);
            GenerarPedidosPage.Icon = "tabler.file_description";
            GenerarPedidosPage.Icon_Checked = "tabler.file_description";
            GenerarPedidosPage.IconColor = KimTools.WinForms.KtColor.Empty;
            GenerarPedidosPage.IconColor_Checked = KimTools.WinForms.KtColor.Empty;
            GenerarPedidosPage.IconSize = 32;
            GenerarPedidosPage.IconStroke = 1D;
            GenerarPedidosPage.Location = new Point(0, 301);
            GenerarPedidosPage.Margin = new Padding(0);
            GenerarPedidosPage.Name = "GenerarPedidosPage";
            GenerarPedidosPage.Padding = new Padding(8, 0, 8, 0);
            GenerarPedidosPage.Pattern.Color = new KimTools.WinForms.KtColor(Color.FromArgb(173, 151, 98), null, null);
            GenerarPedidosPage.Size = new Size(340, 67);
            GenerarPedidosPage.TabIndex = 8;
            GenerarPedidosPage.Text = "PEDIDOS";
            GenerarPedidosPage.UseVisualStyleBackColor = false;
            GenerarPedidosPage.Click += GenerarPedidosPage_Click;
            // 
            // ktDivider1
            // 
            ktDivider1.BackColor = Color.Transparent;
            ktDivider1.BackgroundImageLayout = ImageLayout.Stretch;
            ktDivider1.DashCap = KimTools.WinForms.KtDivider.CapStyles.Round;
            ktDivider1.Dock = DockStyle.Top;
            ktDivider1.LineColor = new KimTools.WinForms.KtColor(Color.FromArgb(0, 78, 65), null, null);
            ktDivider1.LineStyle = KimTools.WinForms.KtDivider.LineStyles.DashDotDot;
            ktDivider1.Location = new Point(0, 279);
            ktDivider1.Margin = new Padding(7, 4, 7, 4);
            ktDivider1.Name = "ktDivider1";
            ktDivider1.Orientation = KimTools.WinForms.KtDivider.LineOrientation.Horizontal;
            ktDivider1.Size = new Size(340, 22);
            ktDivider1.TabIndex = 1;
            // 
            // ktPanel4
            // 
            ktPanel4.Background = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            ktPanel4.Border = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(0, 78, 65), null, null));
            ktPanel4.BorderEdges.BottomLeft = false;
            ktPanel4.BorderEdges.BottomRight = false;
            ktPanel4.BorderEdges.TopLeft = false;
            ktPanel4.BorderEdges.TopRight = false;
            ktPanel4.BorderRadius = 24F;
            ktPanel4.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            ktPanel4.BorderWidth = 1.5F;
            ktPanel4.Controls.Add(ktPictureBox2);
            ktPanel4.Dock = DockStyle.Top;
            ktPanel4.Foreground = KimTools.WinForms.KtColor.Empty;
            ktPanel4.Location = new Point(0, 0);
            ktPanel4.Margin = new Padding(4);
            ktPanel4.Name = "ktPanel4";
            ktPanel4.PatternColor = KimTools.WinForms.KtColor.Empty;
            ktPanel4.Size = new Size(340, 279);
            ktPanel4.TabIndex = 0;
            // 
            // ktPictureBox2
            // 
            ktPictureBox2.BackColor = Color.Transparent;
            ktPictureBox2.Dock = DockStyle.Fill;
            ktPictureBox2.Image = Properties.Resources.escudo_variante_VD;
            ktPictureBox2.ImageBrush = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            ktPictureBox2.Location = new Point(0, 0);
            ktPictureBox2.Margin = new Padding(4);
            ktPictureBox2.Name = "ktPictureBox2";
            ktPictureBox2.Size = new Size(340, 279);
            ktPictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            ktPictureBox2.TabIndex = 0;
            ktPictureBox2.TabStop = false;
            // 
            // PagePedidoSucursal
            // 
            PagePedidoSucursal.Alignment = TabAlignment.Bottom;
            PagePedidoSucursal.AllowTransitions = false;
            PagePedidoSucursal.Background = new KimTools.WinForms.KtColor(Color.FromArgb(173, 151, 98), null, null);
            PagePedidoSucursal.Controls.Add(CrearPedido);
            PagePedidoSucursal.Dock = DockStyle.Fill;
            PagePedidoSucursal.Location = new Point(340, 0);
            PagePedidoSucursal.Multiline = true;
            PagePedidoSucursal.Name = "PagePedidoSucursal";
            PagePedidoSucursal.SelectedIndex = 0;
            PagePedidoSucursal.Size = new Size(1150, 900);
            PagePedidoSucursal.TabIndex = 4;
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
            PagePedidoSucursal.Transition = animation1;
            PagePedidoSucursal.TransitionType = KimTools.WinForms.KtToastHelpers.KtPages.KtPgAnimatorNS.AnimationType.Custom;
            PagePedidoSucursal.Visible = false;
            // 
            // CrearPedido
            // 
            PagePedidoSucursal.Set_Background(CrearPedido, new KimTools.WinForms.KtColor(Color.FromArgb(0, 78, 65), null, null));
            CrearPedido.BackColor = Color.FromArgb(0, 78, 65);
            CrearPedido.Controls.Add(tablaGPedido);
            CrearPedido.Controls.Add(ktPanel2);
            CrearPedido.Location = new Point(0, 0);
            CrearPedido.Name = "CrearPedido";
            CrearPedido.Padding = new Padding(3);
            CrearPedido.Size = new Size(1150, 900);
            CrearPedido.TabIndex = 0;
            CrearPedido.Text = "tabPage1";
            // 
            // tablaGPedido
            // 
            tablaGPedido.AllowUserToAddRows = false;
            tablaGPedido.AllowUserToDeleteRows = false;
            tablaGPedido.AllowUserToOrderColumns = true;
            tablaGPedido.AllowUserToResizeColumns = false;
            tablaGPedido.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 78, 65);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(7, 81, 81);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(160, 180, 240);
            tablaGPedido.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            tablaGPedido.BackgroundColor = Color.FromArgb(0, 78, 65);
            tablaGPedido.BorderStyle = BorderStyle.None;
            tablaGPedido.CellBorderStyle = DataGridViewCellBorderStyle.None;
            tablaGPedido.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(0, 78, 65);
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(0, 78, 65);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            tablaGPedido.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            tablaGPedido.ColumnHeadersHeight = 45;
            tablaGPedido.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tablaGPedido.Columns.AddRange(new DataGridViewColumn[] { Id, Nombre, Camara, Disponible, StockActual, IdCap, IdReceta, CantidadSolicitada });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(0, 78, 65);
            dataGridViewCellStyle4.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(34, 29, 17);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(7, 81, 81);
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(160, 180, 240);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            tablaGPedido.DefaultCellStyle = dataGridViewCellStyle4;
            tablaGPedido.Dock = DockStyle.Fill;
            tablaGPedido.EnableHeadersVisualStyles = false;
            tablaGPedido.GridColor = Color.FromArgb(0, 78, 65);
            tablaGPedido.Location = new Point(3, 115);
            tablaGPedido.Name = "tablaGPedido";
            tablaGPedido.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(0, 78, 65);
            dataGridViewCellStyle5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(0, 78, 65);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(0, 78, 65);
            dataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(0, 78, 65);
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            tablaGPedido.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            tablaGPedido.RowHeadersVisible = false;
            tablaGPedido.RowHeadersWidth = 20;
            tablaGPedido.RowTemplate.Height = 45;
            tablaGPedido.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tablaGPedido.Size = new Size(1144, 782);
            tablaGPedido.Style.Background = new KimTools.WinForms.KtColor(Color.FromArgb(0, 78, 65), null, null);
            tablaGPedido.Style.Border = 0F;
            tablaGPedido.Style.Color = KimTools.WinForms.KtColor.PRIMARY;
            tablaGPedido.Style.Foreground = KimTools.WinForms.KtColor.CONTENT;
            tablaGPedido.Style.Header.Background = new KimTools.WinForms.KtColor(Color.FromArgb(0, 78, 65), null, null);
            tablaGPedido.Style.Header.Foreground = new KimTools.WinForms.KtColor(Color.White, null, null);
            tablaGPedido.Style.Row.Background = new KimTools.WinForms.KtColor(Color.FromArgb(0, 78, 65), null, null);
            tablaGPedido.Style.Row.Foreground = new KimTools.WinForms.KtColor(Color.White, null, null);
            tablaGPedido.Style.RowAlt.Background = new KimTools.WinForms.KtColor(Color.FromArgb(0, 78, 65), null, null);
            tablaGPedido.Style.RowAlt.Foreground = new KimTools.WinForms.KtColor(Color.White, null, null);
            tablaGPedido.Style.ScrollBar.Background = KimTools.WinForms.KtColor.Empty;
            tablaGPedido.Style.ScrollBar.Foreground = KimTools.WinForms.KtColor.Empty;
            tablaGPedido.TabIndex = 4;
            // 
            // Id
            // 
            Id.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Id.DataPropertyName = "IdProducto";
            Id.HeaderText = "IdProducto";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Resizable = DataGridViewTriState.False;
            Id.Visible = false;
            // 
            // Nombre
            // 
            Nombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Nombre.DataPropertyName = "Nombre";
            Nombre.HeaderText = "Nombre";
            Nombre.MinimumWidth = 6;
            Nombre.Name = "Nombre";
            Nombre.ReadOnly = true;
            Nombre.Resizable = DataGridViewTriState.False;
            Nombre.Width = 209;
            // 
            // Camara
            // 
            Camara.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Camara.DataPropertyName = "Camara";
            Camara.HeaderText = "Camara";
            Camara.MinimumWidth = 6;
            Camara.Name = "Camara";
            Camara.ReadOnly = true;
            Camara.Resizable = DataGridViewTriState.False;
            // 
            // Disponible
            // 
            Disponible.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Disponible.DataPropertyName = "Disponible";
            Disponible.HeaderText = "Disponible";
            Disponible.MinimumWidth = 6;
            Disponible.Name = "Disponible";
            Disponible.ReadOnly = true;
            Disponible.Resizable = DataGridViewTriState.False;
            // 
            // StockActual
            // 
            StockActual.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            StockActual.DataPropertyName = "StockActual";
            StockActual.HeaderText = "StockEnFabrica";
            StockActual.MinimumWidth = 6;
            StockActual.Name = "StockActual";
            StockActual.ReadOnly = true;
            StockActual.Resizable = DataGridViewTriState.False;
            StockActual.Visible = false;
            StockActual.Width = 209;
            // 
            // IdCap
            // 
            IdCap.DataPropertyName = "IdCap";
            IdCap.HeaderText = "IdCap";
            IdCap.MinimumWidth = 6;
            IdCap.Name = "IdCap";
            IdCap.ReadOnly = true;
            IdCap.Visible = false;
            IdCap.Width = 125;
            // 
            // IdReceta
            // 
            IdReceta.DataPropertyName = "IdReceta";
            IdReceta.HeaderText = "IdReceta";
            IdReceta.MinimumWidth = 6;
            IdReceta.Name = "IdReceta";
            IdReceta.ReadOnly = true;
            IdReceta.Visible = false;
            IdReceta.Width = 125;
            // 
            // CantidadSolicitada
            // 
            CantidadSolicitada.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            CantidadSolicitada.DefaultCellStyle = dataGridViewCellStyle3;
            CantidadSolicitada.HeaderText = "CantidadPedida";
            CantidadSolicitada.MinimumWidth = 6;
            CantidadSolicitada.Name = "CantidadSolicitada";
            // 
            // ktPanel2
            // 
            ktPanel2.Background = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(0, 78, 65), null, null));
            ktPanel2.Border = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            ktPanel2.BorderEdges.BottomLeft = false;
            ktPanel2.BorderEdges.BottomRight = false;
            ktPanel2.BorderEdges.TopLeft = false;
            ktPanel2.BorderEdges.TopRight = false;
            ktPanel2.BorderRadius = 24F;
            ktPanel2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            ktPanel2.BorderWidth = 1.5F;
            ktPanel2.Dock = DockStyle.Top;
            ktPanel2.Foreground = KimTools.WinForms.KtColor.Empty;
            ktPanel2.Location = new Point(3, 3);
            ktPanel2.Name = "ktPanel2";
            ktPanel2.PatternColor = KimTools.WinForms.KtColor.Empty;
            ktPanel2.Size = new Size(1144, 112);
            ktPanel2.TabIndex = 5;
            // 
            // hudSuperiorCierre
            // 
            Set_Drag(hudSuperiorCierre, true);
            hudSuperiorCierre.Background = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(0, 78, 65), null, null));
            hudSuperiorCierre.Border = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(0, 78, 65), null, null));
            hudSuperiorCierre.BorderEdges.BottomLeft = false;
            hudSuperiorCierre.BorderEdges.BottomRight = false;
            hudSuperiorCierre.BorderEdges.TopLeft = false;
            hudSuperiorCierre.BorderEdges.TopRight = false;
            hudSuperiorCierre.BorderRadius = 24F;
            hudSuperiorCierre.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            hudSuperiorCierre.BorderWidth = 1.5F;
            hudSuperiorCierre.Controls.Add(ktButton1);
            hudSuperiorCierre.Controls.Add(ktButton2);
            hudSuperiorCierre.Controls.Add(ktButton3);
            hudSuperiorCierre.Dock = DockStyle.Top;
            hudSuperiorCierre.Foreground = KimTools.WinForms.KtColor.Empty;
            hudSuperiorCierre.Location = new Point(340, 0);
            hudSuperiorCierre.Margin = new Padding(4);
            hudSuperiorCierre.Name = "hudSuperiorCierre";
            hudSuperiorCierre.PatternColor = KimTools.WinForms.KtColor.Empty;
            hudSuperiorCierre.Size = new Size(1150, 35);
            hudSuperiorCierre.TabIndex = 12;
            // 
            // ktButton1
            // 
            ktButton1.BackColor = Color.Transparent;
            ktButton1.Background = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            ktButton1.Border = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            ktButton1.BorderEdges.BottomLeft = false;
            ktButton1.BorderEdges.BottomRight = false;
            ktButton1.BorderEdges.TopLeft = false;
            ktButton1.BorderEdges.TopRight = false;
            ktButton1.BorderMargin = new Padding(0);
            ktButton1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            ktButton1.BorderWidth = 2F;
            ktButton1.Cursor = Cursors.Default;
            ktButton1.Dock = DockStyle.Right;
            ktButton1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ktButton1.ForeColor = Color.FromArgb(204, 255, 246);
            ktButton1.Foreground = KimTools.WinForms.KtColor.Empty;
            ktButton1.Icon = "tabler.arrow_badge_down";
            ktButton1.IconColor = new KimTools.WinForms.KtColor(Color.FromArgb(173, 151, 98), null, null);
            ktButton1.IconSize = 26;
            ktButton1.IconStroke = 1D;
            ktButton1.ImageAlign = ContentAlignment.MiddleCenter;
            ktButton1.Location = new Point(973, 0);
            ktButton1.Margin = new Padding(4);
            ktButton1.Name = "ktButton1";
            ktButton1.Padding = new Padding(8, 0, 8, 0);
            ktButton1.Pattern.Style = KimTools.WinForms.KtPatternStyle.Default;
            ktButton1.Size = new Size(59, 35);
            ktButton1.TabIndex = 4;
            ktButton1.UseVisualStyleBackColor = false;
            ktButton1.Click += ktButton1_Click;
            // 
            // ktButton2
            // 
            ktButton2.BackColor = Color.Transparent;
            ktButton2.Background = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            ktButton2.Border = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            ktButton2.BorderEdges.BottomLeft = false;
            ktButton2.BorderEdges.BottomRight = false;
            ktButton2.BorderEdges.TopLeft = false;
            ktButton2.BorderEdges.TopRight = false;
            ktButton2.BorderMargin = new Padding(0);
            ktButton2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            ktButton2.BorderWidth = 2F;
            ktButton2.Cursor = Cursors.Default;
            ktButton2.Dock = DockStyle.Right;
            ktButton2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ktButton2.ForeColor = Color.FromArgb(204, 255, 246);
            ktButton2.Foreground = KimTools.WinForms.KtColor.Empty;
            ktButton2.Icon = "tabler.square";
            ktButton2.IconColor = new KimTools.WinForms.KtColor(Color.FromArgb(173, 151, 98), null, null);
            ktButton2.IconSize = 18;
            ktButton2.IconStroke = 1D;
            ktButton2.ImageAlign = ContentAlignment.MiddleCenter;
            ktButton2.Location = new Point(1032, 0);
            ktButton2.Margin = new Padding(4);
            ktButton2.Name = "ktButton2";
            ktButton2.Padding = new Padding(8, 0, 8, 0);
            ktButton2.Pattern.Style = KimTools.WinForms.KtPatternStyle.Default;
            ktButton2.Size = new Size(59, 35);
            ktButton2.TabIndex = 2;
            ktButton2.UseVisualStyleBackColor = false;
            ktButton2.Click += ktButton2_Click;
            // 
            // ktButton3
            // 
            ktButton3.BackColor = Color.Transparent;
            ktButton3.Background = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            ktButton3.Border = (KimTools.WinForms.KtBrushNone)KimTools.WinForms.KtBrush.None;
            ktButton3.BorderEdges.BottomLeft = false;
            ktButton3.BorderEdges.BottomRight = false;
            ktButton3.BorderEdges.TopLeft = false;
            ktButton3.BorderEdges.TopRight = false;
            ktButton3.BorderMargin = new Padding(0);
            ktButton3.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            ktButton3.BorderWidth = 2F;
            ktButton3.Cursor = Cursors.Default;
            ktButton3.Dock = DockStyle.Right;
            ktButton3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ktButton3.ForeColor = Color.FromArgb(204, 255, 246);
            ktButton3.Foreground = KimTools.WinForms.KtColor.Empty;
            ktButton3.Icon = "tabler.x";
            ktButton3.IconColor = new KimTools.WinForms.KtColor(Color.FromArgb(240, 10, 5), null, null);
            ktButton3.IconSize = 24;
            ktButton3.IconStroke = 1D;
            ktButton3.ImageAlign = ContentAlignment.MiddleCenter;
            ktButton3.Location = new Point(1091, 0);
            ktButton3.Margin = new Padding(4);
            ktButton3.Name = "ktButton3";
            ktButton3.Padding = new Padding(8, 0, 8, 0);
            ktButton3.Pattern.Style = KimTools.WinForms.KtPatternStyle.Default;
            ktButton3.Size = new Size(59, 35);
            ktButton3.TabIndex = 3;
            ktButton3.UseVisualStyleBackColor = false;
            ktButton3.Click += ktButton3_Click;
            // 
            // FormCrearPedido
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Background = new KimTools.WinForms.KtBrushSolid(new KimTools.WinForms.KtColor(Color.FromArgb(173, 151, 98), null, null));
            ClientSize = new Size(1490, 900);
            Controls.Add(hudSuperiorCierre);
            Controls.Add(PagePedidoSucursal);
            Controls.Add(hudLateral);
            ForeColor = Color.FromArgb(34, 29, 17);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormCrearPedido";
            Text = "FormCrearPedido";
            hudLateral.ResumeLayout(false);
            ContenedorPanel.ResumeLayout(false);
            ktPanel5.ResumeLayout(false);
            fechaIng.ResumeLayout(false);
            ktPanel10.ResumeLayout(false);
            ktPanel11.ResumeLayout(false);
            ktPanel3.ResumeLayout(false);
            ktPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ktPictureBox2).EndInit();
            PagePedidoSucursal.ResumeLayout(false);
            CrearPedido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tablaGPedido).EndInit();
            hudSuperiorCierre.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private KimTools.WinForms.KtPanel hudLateral;
        private KimTools.WinForms.KtRadioButton SeguimientoPedidosPage;
        private KimTools.WinForms.KtRadioButton GenerarPedidosPage;
        private KimTools.WinForms.KtDivider ktDivider1;
        private KimTools.WinForms.KtPanel ktPanel4;
        private KimTools.WinForms.KtPictureBox ktPictureBox2;
        private KimTools.WinForms.KtPages PagePedidoSucursal;
        private TabPage CrearPedido;
        private KimTools.WinForms.KtTable tablaGPedido;
        private KimTools.WinForms.KtPanel ktPanel2;
        private KimTools.WinForms.KtPanel ktPanel3;
        private KimTools.WinForms.KtButton btnSalirPedidosSucursal;
        private KimTools.WinForms.KtButton btnEnviarPedido;
        private KimTools.WinForms.KtPanel hudSuperiorCierre;
        private KimTools.WinForms.KtButton ktButton1;
        private KimTools.WinForms.KtButton ktButton2;
        private KimTools.WinForms.KtButton ktButton3;
        private KimTools.WinForms.KtPanel ContenedorPanel;
        private KimTools.WinForms.KtPanel ktPanel5;
        private KimTools.WinForms.KtPanel fechaIng;
        private KimTools.WinForms.KtDate fechaEstimada;
        private KimTools.WinForms.KtPanel ktPanel10;
        private KimTools.WinForms.KtPanel ktPanel11;
        private KimTools.WinForms.KtLabel ktLabel1;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Camara;
        private DataGridViewTextBoxColumn Disponible;
        private DataGridViewTextBoxColumn StockActual;
        private DataGridViewTextBoxColumn IdCap;
        private DataGridViewTextBoxColumn IdReceta;
        private DataGridViewTextBoxColumn CantidadSolicitada;
    }
}
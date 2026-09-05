using Alemana.DTOs;
using KimTools;
using KimTools.WinForms;
using MenuDesk.Services;
using System;
using System.Windows.Forms;

namespace MenuDesk
{
    public partial class MenuPPal : KtWindow
    {

        private readonly ApiClient _apiClient = new ApiClient();

        public MenuPPal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void ktButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void ktButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = this.WindowState == FormWindowState.Maximized
            ? FormWindowState.Normal
            : FormWindowState.Maximized;
        }
        private void ktButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        


    }
}

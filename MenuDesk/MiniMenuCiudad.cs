using System;
using KimTools.WinForms;
using Alemana.DTOs;
using Alemana.API;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;


namespace MenuDesk
{
    public partial class MiniMenuCiudad : KtWindow
    {


        public MiniMenuCiudad()
        {
            InitializeComponent();
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

            this.Visible = false; //con close y dispose se produce excepción de un componente que quiere usar thread abort

        }


    }
}

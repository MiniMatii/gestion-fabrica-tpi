using System;
using System.Windows.Forms;

namespace MenuDesk
{
    public partial class MenuPPal : Form
    {
        public MenuPPal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void botonSolicitudes_Click(object sender, EventArgs e)
        {
            try
            {
                FormMateriap wnMp = new FormMateriap();

                wnMp.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir la ventana:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                OperariosPage ventanaOperarios = new OperariosPage();
                ventanaOperarios.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir la ventana:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
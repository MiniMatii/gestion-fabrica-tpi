using Alemana.DTOs;
using KimTools.WinForms;
using MenuDesk.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuDesk
{
    public partial class FormMPMini : KtWindow
    {
        private readonly ApiClient _apiClient = new ApiClient();

        public FormMPMini()
        {
            InitializeComponent();
        }

        private async void acceptMP_Click(object sender, EventArgs e)
        {
            await cargarMP();

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async Task cargarMP()
        {
            try
            {
                if (textMiniMP.Text != null && Convert.ToString(selectUnitMP.SelectedItem) != null)
                {
                    string endpoint = "materiap";
                    var nMP = new MateriapDTO();
                    nMP.Nombre = textMiniMP.Text;
                    nMP.Unidad = Convert.ToString(selectUnitMP.SelectedItem);
                    await _apiClient.PostAsync(endpoint, nMP);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la materia prima: {ex.Message}", "Error de Alta", MessageBoxButtons.OK);
            }

        }

        private async void FormMPMini_Load(object sender, EventArgs e)
        {
            selectUnitMP.Items.Add("Kilogramo (kg)");
            selectUnitMP.Items.Add("Gramo (g)");
            selectUnitMP.Items.Add("Litro (L)");
            selectUnitMP.Items.Add("Mililitro (ml)");
            selectUnitMP.Items.Add("Unidad (u)");
            await CargarMps();
        }


        private void pageEliminarMP_Click(object sender, EventArgs e)
        {
            pagesMP.Page = bajaMP;
        }

        private void pageAltaMp_Click(object sender, EventArgs e)
        {
            pagesMP.Page = altaMP;
        }

        private async Task CargarMps()
        {
            try
            {
                string endpoint = "materiap";
                var listaDatos = await _apiClient.ObtenerListaAsync<MateriapDTO>(endpoint);

                if (listaDatos != null)
                {
                    ktTablaMPs.DataSource = listaDatos;

                    ktTablaMPs.Columns["IdMateriaP"].HeaderText = "Codigo";
                    ktTablaMPs.Columns["Nombre"].HeaderText = "Nombre";
                    ktTablaMPs.Columns["Unidad"].HeaderText = "Unidad";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la tabla materia prima: {ex.Message}", "Error de Carga", MessageBoxButtons.OK);
            }
        }

        private async void eliminarMPbutton_Click(object sender, EventArgs e)
        {
            try
            {
                var idMp = Convert.ToInt32(ktTablaMPs.CurrentRow.Cells["IdMateriaP"].Value);

                bool eliminado = await _apiClient.DeleteAsync($"materiap/{idMp}");
                if (eliminado)
                {
                    MessageBox.Show("Materia eliminada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                }
                else 
                { 
                    MessageBox.Show("No se pudo eliminar la materia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Error al eliminar la materia prima: {ex.Message}", "Error de Baja", MessageBoxButtons.OK);

            }
        }

    }
}

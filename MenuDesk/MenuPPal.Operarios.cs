using Alemana.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuDesk
{
    partial class MenuPPal
    {

        private void OperariosPage_CheckedChanged(object sender, EventArgs e)
        {
            panelLotes.Visible =false;
            panelOperarios.Visible = !(panelOperarios.Visible);
            panelOperarios.Enabled = !(panelOperarios.Enabled);
        }

        private async void abrirMenuOperarios_Click(object sender, EventArgs e) 
        {
            await CargarCapacidadesEnGrilla();
            await CargarOperariosEnGrilla();
        }

        private void AltaOperario_Click(object sender, EventArgs e)
        {
            navBarOperarios.SelectedTab = altaLotesPage;
        }

        private void EditarOperario_Click(object sender, EventArgs e)
        {
            navBarOperarios.SelectedTab = modificarLotesPage;
        }

        private void EliminarOperario_Click(object sender, EventArgs e)
        {
            navBarOperarios.SelectedTab = eliminarOperarioPage;
        }

        private async void buttonGuardarOperario_Click(object sender, EventArgs e)
        {
            try
            {
                string endpoint = "operario";
                if (ktTablaCapacidades.SelectedCells != null)
                {
                    var caps = new CapacidadDTO();
                    caps.IdCap = Convert.ToInt32(ktTablaCapacidades.CurrentRow.Cells["IdCap"].Value);
                    caps.DescCapacidad = ktTablaCapacidades.CurrentRow.Cells["DescCapacidad"].Value.ToString();
                    caps.NomCapacidad = ktTablaCapacidades.CurrentRow.Cells["NomCapacidad"].Value.ToString();

                    OperariosDTO n_Op = new OperariosDTO();
                    n_Op.Nombre = nombreOpText.Text;
                    n_Op.Apellido = apellidoOpText.Text;
                    n_Op.IdCaps.Add(caps);
                    n_Op.Disponibilidad = 1;
                    await _apiClient.PostAsync(endpoint, n_Op);

                    //if () 
                    //{
                    //    MessageBox.Show("Operario guardado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con el servidor: \n{ex.Message}\n ", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonBorrarOperario_Click(object sender, EventArgs e)
        {
            try
            {
                int idEliminar = Convert.ToInt32(ktTablaOperarios.CurrentRow.Cells["IdOperario"].Value);

                bool eliminado = await _apiClient.DeleteAsync($"operario/{idEliminar}");

                if (eliminado)
                    MessageBox.Show("Operario eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("No se pudo eliminar el operario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            } catch (Exception ex) 
            {
                MessageBox.Show($"Error al eliminar el operario: {ex.Message} ", "Error de Eliminación", MessageBoxButtons.OK);
            } 
        }


        private async void actCambiosOperario_Click(object sender, EventArgs e)
        {
            await CargarOperariosEnGrilla();
        }
        private async Task CargarCapacidadesEnGrilla() 
        {
            try
            {
                string endpoint = "capacidad";

                var listaDatos = await _apiClient.ObtenerListaAsync<CapacidadDTO>(endpoint);

                if (listaDatos != null)
                {
                    ktTablaCapacidades.DataSource = listaDatos;
                    ktTablaCapacidades.Columns["IdCap"].HeaderText = "IdCap";
                    ktTablaCapacidades.Columns["DescCapacidad"].HeaderText = "Descripcion";
                    ktTablaCapacidades.Columns["NomCapacidad"].HeaderText = "Capacidad";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CargarOperariosEnGrilla()
        {
            string endpoint = "operario";
            var listado = await _apiClient.ObtenerListaAsync<OperariosDTO>(endpoint);

            if (listado != null)
            {
                ktTablaOperarios.DataSource = listado;
                ktTablaOperarios.Columns["IdOperario"].HeaderText = "IdOp";
                ktTablaOperarios.Columns["NombreOp"].HeaderText = "Nombre";
                ktTablaOperarios.Columns["ApellidoOp"].HeaderText = "Apellido";
                ktTablaOperarios.Columns["Disponibilidad"].HeaderText = "Estado";
            }
        }
    }
}

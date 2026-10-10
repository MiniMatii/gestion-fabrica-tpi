using Alemana.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MenuDesk
{
    public partial class MenuPPal
    {
        private void SucursalesPage_CheckedChanged(object sender, EventArgs e)
        {
            panelLotes.Visible = false;
            panelOperarios.Visible = false;
            panelSucursales.Visible = !(panelSucursales.Visible);
            panelSucursales.Enabled = !(panelSucursales.Enabled);
        }

        private async void abrirMenuSucursales_Click(object sender, EventArgs e)
        {
            await CargarSucursalesEnGrilla();
            await CargarTablaEmpleadosAsync();
        }

        private void AltaSucursales_Click(object sender, EventArgs e)
        {
            navBarSucursales.SelectedTab = altaSucursalesPage;
        }

        private void EditarSucursales_Click(object sender, EventArgs e)
        {
            navBarSucursales.SelectedTab = modificarSucursalPage;
        }

        private void EliminarSucursal_Click(object sender, EventArgs e)
        {
            navBarSucursales.SelectedTab = eliminarSucursalPage;
        }

        private async Task CargarSucursalesEnGrilla()
        {
            try
            {
                string endpoint = "sucursales";

                var listaDatos = await _apiClient.ObtenerListaAsync<SucursalesDTO>(endpoint);

                if (listaDatos != null)
                {
                    ktTablaSucursales.AutoGenerateColumns = false;
                    ktTablaSucursales.DataSource = listaDatos;
                    ktTablaSucursales.Columns["IdSucursal"].HeaderText = "IdSucursal";
                    ktTablaSucursales.Columns["NombreSuc"].HeaderText = "NombreSuc";
                    ktTablaSucursales.Columns["CodPostal"].HeaderText = "CodPostal";

                    ktTablaSucursales.Columns["IdSucursal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    ktTablaSucursales.Columns["NombreSuc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    ktTablaSucursales.Columns["CodPostal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonGuardarSucursal_Click(object sender, EventArgs e)
        {
            try
            {
                string endpoint = "sucursales";

                if (string.IsNullOrWhiteSpace(nomSucursalText.Text) || string.IsNullOrWhiteSpace(codPostalText.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var nuevaSucursal = new SucursalesDTO
                {
                    NombreSuc = nomSucursalText.Text,
                    CodPostal = Convert.ToInt32(codPostalText.Text)
                };

                await _apiClient.PostAsync(endpoint, nuevaSucursal);

                MessageBox.Show("¡Sucursal guardada con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                nomSucursalText.Clear();
                codPostalText.Clear();

                await CargarSucursalesEnGrilla();
            }
            catch (FormatException)
            {
                MessageBox.Show("El Código Postal debe ser un número válido.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con el servidor: \n{ex.Message}\n ", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CargarTablaEmpleadosAsync()
        {
            try
            {
                string endpoint = "empleado";

                var listaEmpleados = await _apiClient.ObtenerListaAsync<EmpleadoDTO>(endpoint);

                if (listaEmpleados != null)
                {
                    sucktTable2.AutoGenerateColumns = false;
                    sucktTable2.DataSource = listaEmpleados;

                    if (ktTablaSucursales.Columns["IdEmpleado"] != null)
                        ktTablaSucursales.Columns["IdEmpleado"].HeaderText = "ID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los empleados: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonAsignarEmpleado_Click(object sender, EventArgs e)
        {
            try
            {
                if (sucktTable2.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor, seleccione un empleado de la tabla.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtNroSucursal.Text, out int idSucursal))
                {
                    MessageBox.Show("Por favor, ingrese un número de sucursal válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                List<int> idsEmpleados = new List<int>();
                foreach (DataGridViewRow fila in sucktTable2.SelectedRows)
                {
                    int idEmp = Convert.ToInt32(fila.Cells[0].Value);
                    idsEmpleados.Add(idEmp);
                }

                string endpoint = $"sucursales/{idSucursal}/empleados";

                await _apiClient.PostAsync(endpoint, idsEmpleados);

                MessageBox.Show("¡Empleado(s) asignado(s) a la sucursal con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await CargarTablaEmpleadosAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al asignar el empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void bottonEliminarSucursal_Click(object sender, EventArgs e)
        {
            try
            {
                if (ktTablaSucursales.CurrentRow == null)
                {
                    MessageBox.Show("Por favor, seleccione una sucursal de la lista antes de eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult confirmacion = MessageBox.Show(
                    "¿Está seguro que desea eliminar esta sucursal? Esta acción no se puede deshacer.",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    int idSucursal = Convert.ToInt32(ktTablaSucursales.CurrentRow.Cells["IdSucursal"].Value);
                    string endpoint = $"sucursales/{idSucursal}";

                    await _apiClient.DeleteAsync(endpoint);

                    MessageBox.Show("¡Sucursal eliminada con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    await CargarSucursalesEnGrilla();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar eliminar la sucursal: \n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
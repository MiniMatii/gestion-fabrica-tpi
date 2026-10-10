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

        private void AgregarEmpleado_Click(object sender, EventArgs e)
        {
            navBarSucursales.SelectedTab = agregarEmpleadoPage;
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

                    empktTable4.AutoGenerateColumns = false;
                    empktTable4.DataSource = listaEmpleados;

                    if (empktTable4.Columns["IdEmpleadodataGridViewTextBoxColumn20"] != null) empktTable4.Columns["IdEmpleadodataGridViewTextBoxColumn20"].DataPropertyName = "IdEmpleado";
                    if (empktTable4.Columns["nombreEmpdataGridViewTextBoxColumn21"] != null) empktTable4.Columns["nombreEmpdataGridViewTextBoxColumn21"].DataPropertyName = "Nombre";
                    if (empktTable4.Columns["ApellidoEmpdataGridViewTextBoxColumn22"] != null) empktTable4.Columns["ApellidoEmpdataGridViewTextBoxColumn22"].DataPropertyName = "Apellido";
                    if (empktTable4.Columns["Dni"] != null) empktTable4.Columns["Dni"].DataPropertyName = "Dni";
                    if (empktTable4.Columns["IdJefe"] != null) empktTable4.Columns["IdJefe"].DataPropertyName = "IdJefe";
                    if (empktTable4.Columns["disponibilidadEmp"] != null) empktTable4.Columns["disponibilidadEmp"].DataPropertyName = "Disponibilidad";
                    if (empktTable4.Columns["Motivo"] != null) empktTable4.Columns["Motivo"].DataPropertyName = "Motivo";

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

        private static string PedirMotivo(string mensaje, string titulo)
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 180,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = titulo,
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false
            };
            Label textLabel = new Label() { Left = 20, Top = 20, Width = 340, Text = mensaje };
            TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 340 };
            Button confirmation = new Button() { Text = "Aceptar", Left = 260, Width = 100, Top = 90, DialogResult = DialogResult.OK };

            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text.Trim() : string.Empty;
        }

        private async void guardarEmpktButton14_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nombreEmpText.Text) ||
                    string.IsNullOrWhiteSpace(apellidoEmpText.Text) ||
                    string.IsNullOrWhiteSpace(dniEmpText.Text))
                {
                    MessageBox.Show("Por favor, complete Nombre, Apellido y DNI.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int? idJefe = null;
                if (!string.IsNullOrWhiteSpace(idJefeEmpText.Text))
                {
                    if (int.TryParse(idJefeEmpText.Text, out int parsedJefe))
                    {
                        idJefe = parsedJefe;
                    }
                    else
                    {
                        MessageBox.Show("El ID del Jefe debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                var nuevoEmpleado = new EmpleadoDTO
                {
                    Nombre = nombreEmpText.Text,
                    Apellido = apellidoEmpText.Text,
                    Dni = dniEmpText.Text,
                    IdJefe = idJefe,
                    IdSucursal = 1,
                    Disponibilidad = 1,
                    Motivo = null
                };

                string endpoint = "empleado";
                await _apiClient.PostAsync(endpoint, nuevoEmpleado);

                MessageBox.Show("¡Empleado guardado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                nombreEmpText.Clear();
                apellidoEmpText.Clear();
                dniEmpText.Clear();
                idJefeEmpText.Clear();

                await CargarTablaEmpleadosAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar el empleado: \n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void darBajaEmpktButton16_Click(object sender, EventArgs e)
        {
            try
            {
                if (empktTable4.CurrentRow == null)
                {
                    MessageBox.Show("Por favor, seleccione un empleado de la tabla.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idEmpleado = Convert.ToInt32(empktTable4.CurrentRow.Cells["IdEmpleadodataGridViewTextBoxColumn20"].Value);
                sbyte disponibilidadActual = Convert.ToSByte(empktTable4.CurrentRow.Cells["disponibilidadEmp"].Value);

                bool esBaja = (disponibilidadActual == 1);
                string accionTexto = esBaja ? "baja" : "alta";

                string motivo = PedirMotivo($"Ingrese el motivo para dar de {accionTexto} al empleado:", $"Confirmar {accionTexto.ToUpper()}");

                if (string.IsNullOrWhiteSpace(motivo))
                {
                    MessageBox.Show("La operación fue cancelada. El motivo es obligatorio.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var empleadoActualizado = new EmpleadoDTO
                {
                    IdEmpleado = idEmpleado,
                    Motivo = motivo,
                    Disponibilidad = (sbyte)(esBaja ? 0 : 1)
                };

                if (esBaja)
                {
                    string endpoint = $"empleado/baja/{idEmpleado}";
                    await _apiClient.PutAsync(endpoint, empleadoActualizado);
                }
                else
                {
                    string endpoint = $"empleado/{idEmpleado}";
                    await _apiClient.PutAsync(endpoint, empleadoActualizado);
                }

                MessageBox.Show($"¡Empleado dado de {accionTexto} con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await CargarTablaEmpleadosAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar la solicitud: \n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void eliminarEmpktButton15_Click(object sender, EventArgs e)
        {
            try
            {
                if (empktTable4.CurrentRow == null)
                {
                    MessageBox.Show("Por favor, seleccione un empleado de la tabla antes de eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult confirmacion = MessageBox.Show(
                    "¿Está seguro que desea eliminar este empleado de forma definitiva? Esta acción no se puede deshacer.",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    int idEmpleado = Convert.ToInt32(empktTable4.CurrentRow.Cells["IdEmpleadodataGridViewTextBoxColumn20"].Value);
                    string endpoint = $"empleado/{idEmpleado}";

                    await _apiClient.DeleteAsync(endpoint);

                    MessageBox.Show("¡Empleado eliminado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    await CargarTablaEmpleadosAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar eliminar el empleado: \n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
using Alemana.DTOs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuDesk
{

    public partial class MenuPPal
    {
        private void LotesPage_CheckedChanged(object sender, EventArgs e)
        {

            panelOperarios.Visible = false;
            panelLotes.Visible = !(panelLotes.Visible);
            panelLotes.Enabled = !(panelLotes.Enabled);


        }

        private async void abrirMenuLote_Click(object sender, EventArgs e)
        {

            await GenerarMateriasPrimas();
            await CargarDatosEnGrillaAsync();
            await CargarDatosLotesAsync();
        }

        private void sNavModLote(object sender, EventArgs e)
        {
            navBarLotes.SelectedTab = modificarLotesPage;

        }

        private void sNavAltaLote(object sender, EventArgs e)
        {
            navBarLotes.SelectedTab = altaLotesPage;
        }

        private void sNavEliminarLote(object sender, EventArgs e)
        {
            navBarLotes.SelectedTab = eliminarLotesPage;
        }

        private async Task CargarDatosEnGrillaAsync()
        {
            try
            {
                string endpoint = "proveedores";

                var listaDatos = await _apiClient.ObtenerListaAsync<ProveedorDTO>(endpoint);

                if (listaDatos != null)
                {
                    ktTablaProveedoresLotes.DataSource = listaDatos;
                    ktTablaProveedoresLotes.Columns["IdProveedor"].HeaderText = "IdProveedor";
                    ktTablaProveedoresLotes.Columns["razonSocial"].HeaderText = "RazonSocial";
                    ktTablaProveedoresLotes.Columns["Cuit"].HeaderText = "CUIT";
                    ktTablaProveedoresLotes.Columns["Nombre"].HeaderText = "Nombre";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CargarDatosLotesAsync()
        {
            try
            {
                string endpoint = "lotes";

                var listaDatos = await _apiClient.ObtenerListaAsync<ListadoLotesFullDTO>($"{endpoint}/full");

                if (listaDatos != null)
                {
                    ktTablaLotes.AutoGenerateColumns = false;
                    ktTablaLotesEliminar.AutoGenerateColumns = false;
                    ktTablaLotes.DataSource = listaDatos;
                    ktTablaLotesEliminar.DataSource = listaDatos;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task GenerarMateriasPrimas()
        {
            string endpoint = "materiap";

            var listadoMP = await _apiClient.ObtenerListaAsync<MateriapDTO>(endpoint);

            if (listadoMP != null)
            {
                SelectMP.DisplayMember = "Nombre";
                SelectMP.ValueMember = "IdMateriaP";

                SelectUnidad.DisplayMember = "Unidad";
                SelectUnidad.ValueMember = "Unidad";
                
                SelectUnidad.DataSource = listadoMP.DistinctBy(u => u.Unidad).ToList();
                SelectMP.DataSource = listadoMP;


            }
        }

        private async void buttonGuardarLote_Click(object sender, EventArgs e)
        {
            try
            {
                var filaProveedor = ktTablaProveedoresLotes.CurrentRow;
                if (filaProveedor == null)
                {
                    MessageBox.Show("Seleccioná un proveedor de la tabla.", "Lotes");
                    return;
                }

                if (SelectMP.SelectedValue == null)
                {
                    MessageBox.Show("Seleccioná una materia prima.", "Lotes");
                    return;
                }

                if (!decimal.TryParse(cantidadMateriaPrima.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal cantidad)
                    || Math.Round(cantidad, 2) <= 0)
                {
                    MessageBox.Show("Ingresá una cantidad mayor a cero.", "Lotes");
                    return;
                }

                if (!DateTime.TryParse(fechaVencimiento.Text, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime fechaVen))
                {
                    MessageBox.Show("Ingresá una fecha de vencimiento válida.", "Lotes");
                    return;
                }

                if (fechaVen.Date < fechaIngreso.Value.Date)
                {
                    MessageBox.Show("La fecha de vencimiento no puede ser anterior a la de ingreso.", "Lotes");
                    return;
                }

                var nuevoLote = new LoteDTO
                {
                    FechaIngreso = fechaIngreso.Value,
                    FechaVencimiento = fechaVen,
                    IdProveedor = Convert.ToInt32(filaProveedor.Cells["IdProveedor"].Value),
                    IdMateriaP = Convert.ToInt32(SelectMP.SelectedValue),
                    CantidadLote = Math.Round(cantidad, 2),
                    EstadoLote = 1
                };

                bool ok = await _apiClient.PostAsync("lotes", nuevoLote);

                if (ok)
                    MessageBox.Show("Lote guardado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("No se pudo guardar el lote.", "Lotes");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con el servidor: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ktTablaLotes_SelectionChanged(object sender, EventArgs e)
        {
            var fila = ktTablaLotes.CurrentRow;
            if (fila == null) return;

            valorCantCambio.Text = fila.Cells["CantidadLote"].Value?.ToString();
            valorFechaVCambiada.Text = fila.Cells["FechaDeVencimiento"].Value?.ToString();
        }

        private async void guardarCambiosLote_Click(object sender, EventArgs e)
        {
            try
            {
                var modLote = ktTablaLotes.CurrentRow;
                if (modLote == null)
                {
                    MessageBox.Show("Seleccioná un lote de la tabla.", "Lotes");
                    return;
                }

                if (!decimal.TryParse(valorCantCambio.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal cantidad)
                    || cantidad < 0)
                {
                    MessageBox.Show("Ingresá una cantidad válida (cero o mayor).", "Lotes");
                    return;
                }

                if (!DateTime.TryParse(valorFechaVCambiada.Text, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime fechaVen))
                {
                    MessageBox.Show("Ingresá una fecha de vencimiento válida.", "Lotes");
                    return;
                }

                var fechaIng = Convert.ToDateTime(modLote.Cells["FechaDeIngreso"].Value);
                if (fechaVen.Date < fechaIng.Date)
                {
                    MessageBox.Show("La fecha de vencimiento no puede ser anterior a la de ingreso.", "Lotes");
                    return;
                }

                var loteDto = new LoteDTO
                {
                    CantidadLote = Math.Round(cantidad, 2),
                    FechaVencimiento = fechaVen,
                    FechaIngreso = fechaIng,
                    IdLote = Convert.ToInt32(modLote.Cells["IdLote"].Value),
                    IdMateriaP = Convert.ToInt32(modLote.Cells["IdMateriaP"].Value),
                    IdProveedor = Convert.ToInt32(modLote.Cells["IdProv"].Value),
                    EstadoLote = Convert.ToSByte(modLote.Cells["estadoLote"].Value)
                };

                bool ok = await _apiClient.PatchAsync("lotes", loteDto);

                if (ok)
                    MessageBox.Show("Cambios guardados con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("No se pudieron guardar los cambios.", "Lotes");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al ejecutar el guardado de las modificaciones en lotes: {ex.Message}", "Error de Guardado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void deshabilitarLote_Click(object sender, EventArgs e)
        {

        }

        private async void eliminarLote_Click(object sender, EventArgs e)
        {
            try
            {
                var fila = ktTablaLotesEliminar.CurrentRow;
                if (fila == null)
                {
                    MessageBox.Show("Seleccioná un lote de la tabla.", "Lotes");
                    return;
                }

                int idEliminar = Convert.ToInt32(ktTablaLotesEliminar.CurrentRow.Cells["IdLoteE"].Value);
                bool eliminado = await _apiClient.DeleteAsync($"lotes/{idEliminar}");
                
                if (eliminado)
                    MessageBox.Show("Lote eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("No se pudo eliminar el lote.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Error al eliminar el lote: {ex.Message}", "Error de Eliminación", MessageBoxButtons.OK);
            }
        }

        private async void actCambiosLote_Click(object sender, EventArgs e)
        {
            await CargarDatosLotesAsync();
        }

        private void proveedorButton_Click(object sender, EventArgs e)
        {
            var miniFormAltaProveedor = new FormProvMini();
            miniFormAltaProveedor.StartPosition = FormStartPosition.CenterScreen;
            miniFormAltaProveedor.FormBorderStyle = FormBorderStyle.None;

            var pPantalla = proveedorButton.PointToScreen(new Point(0, proveedorButton.Height));
            miniFormAltaProveedor.Location = pPantalla;

            miniFormAltaProveedor.Deactivate += (s, args) => miniFormAltaProveedor.Close();

            miniFormAltaProveedor.Show(this);

        }

        private void materiapButton_Click(object sender, EventArgs e)
        {

            var miniFormMP = new FormMPMini();
            miniFormMP.StartPosition = FormStartPosition.CenterScreen;
            miniFormMP.FormBorderStyle = FormBorderStyle.None;

            var pPantalla = proveedorButton.PointToScreen(new Point(0, proveedorButton.Height));
            miniFormMP.Location = pPantalla;

            miniFormMP.Deactivate += (s, args) => miniFormMP.Close();

            miniFormMP.Show(this);


        }

    }

}

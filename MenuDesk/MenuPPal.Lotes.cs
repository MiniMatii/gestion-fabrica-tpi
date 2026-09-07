using Alemana.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuDesk
{
    //SECCION LOTES
    public partial class MenuPPal
    {
        private void LotesPage_CheckedChanged(object sender, EventArgs e)
        {
            //voidPanel.Visible = !(voidPanel.Visible);
            panelOperarios.Visible = false;
            panelLotes.Visible = !(panelLotes.Visible);
            panelLotes.Enabled = !(panelLotes.Enabled);
            //ConfigurarScrollbar();

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

                var listaDatos = await _apiClient.ObtenerListaAsync<LoteDTO>(endpoint);

                if (listaDatos != null)
                {

                    ktTablaLotes.DataSource = listaDatos;
                    ktTablaLotesEliminar.DataSource = listaDatos;


                    ktTablaLotes.Columns["IdLote"].HeaderText = "IdLote";
                    ktTablaLotes.Columns["IdProv"].HeaderText = "IdProveedor";
                    ktTablaLotes.Columns["IdMateriaP"].HeaderText = "IdMateriaP";
                    ktTablaLotes.Columns["EstadoLote"].HeaderText = "EstadoLote";
                    ktTablaLotes.Columns["FechaDeIngreso"].HeaderText = "FechaIngreso";
                    ktTablaLotes.Columns["FechaDeVencimiento"].HeaderText = "FechaVencimiento";
                    ktTablaLotes.Columns["CantidadLote"].HeaderText = "CantidadLote";

                    ktTablaLotes.Columns["IdLote"].HeaderText = "IdLoteE";
                    ktTablaLotes.Columns["IdProv"].HeaderText = "IdProveedorE";
                    ktTablaLotes.Columns["IdMateriaP"].HeaderText = "IdMateriaPE";
                    ktTablaLotes.Columns["EstadoLote"].HeaderText = "EstadoLoteE";
                    ktTablaLotes.Columns["FechaDeIngreso"].HeaderText = "FechaIngresoE";
                    ktTablaLotes.Columns["FechaDeVencimiento"].HeaderText = "FechaVencimientoE";
                    ktTablaLotes.Columns["CantidadLote"].HeaderText = "CantidadLoteE";
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
                
                SelectUnidad.DataSource = listadoMP;
                SelectMP.DataSource = listadoMP;


            }
        }

        private async void buttonGuardarLote_Click(object sender, EventArgs e)
        {
            try
            {
                var nuevoLote = new LoteDTO();
                nuevoLote.FechaIngreso = fechaIngreso.Value;
                nuevoLote.FechaVencimiento = DateTime.Parse(fechaVencimiento.Text);

                if (ktTablaProveedoresLotes.CurrentRow != null)
                {
                    nuevoLote.IdProveedor = Convert.ToInt32(ktTablaProveedoresLotes.CurrentRow.Cells["IdProveedor"].Value);
                }

                nuevoLote.IdMateriaP = Convert.ToInt32(SelectMP.SelectedValue); 
                nuevoLote.CantidadLote = int.Parse(cantidadMateriaPrima.Text);
                nuevoLote.EstadoLote = 1;


                await _apiClient.PostAsync("lotes", nuevoLote);

                MessageBox.Show("Lote guardado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con el servidor: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //private void ConfigurarScrollbar()
        //{



        //    //int alturaContenido = altaLoteSubPage.Controls
        //    //    .OfType<Control>()
        //    //    .Sum(c => c.Height);
        //    //int alturaVisible = altaLoteSubPage.ClientSize.Height;

        //    //ktScrollbar1.Minimum = 0;
        //    //ktScrollbar1.Maximum = Math.Max(0, alturaContenido - alturaVisible);
        //    //ktScrollbar1.LargeChange = alturaVisible;
        //    //ktScrollbar1.SmallChange = 40;
        //    //ktScrollbar1.Value = 0;
        //}

        //private void ktScrollbar1_Scroll(object sender, KimTools.WinForms.KtScrollbar.ScrollEventArgs e)
        //{
        //    altaLoteSubPage.AutoScrollPosition = new Point(0, e.Value);
        //}

        private void ktTablaLotes_SelectionChanged(object sender, EventArgs e)
        {
            valorCantCambio.Text = ktTablaLotes.CurrentRow.Cells["CantidadLote"].Value.ToString();
            valorFechaVCambiada.Text = ktTablaLotes.CurrentRow.Cells["FechaDeVencimiento"].Value.ToString();
              
        }

        private async void guardarCambiosLote_Click(object sender, EventArgs e)
        {
            try
            {
                var modLote = ktTablaLotes.CurrentRow;
                if (modLote != null)
                {
                    var loteDto = new LoteDTO();

                    if (valorCantCambio != null)
                    {
                        loteDto.CantidadLote = Convert.ToDecimal(valorCantCambio.Text);
                    }

                    if (valorFechaVCambiada != null) 
                    {
                        loteDto.FechaVencimiento = DateTime.Parse(valorFechaVCambiada.Text);
                    }
                    loteDto.IdLote = Convert.ToInt32(modLote.Cells["IdLote"].Value);
                    loteDto.IdMateriaP = Convert.ToInt32(modLote.Cells["IdMateriaP"].Value);
                    loteDto.IdProveedor = Convert.ToInt32(modLote.Cells["IdProv"].Value);
                    loteDto.EstadoLote = Convert.ToSByte(modLote.Cells["estadoLote"].Value);
                    loteDto.FechaIngreso = Convert.ToDateTime(modLote.Cells["FechaDeIngreso"].Value);
                    await _apiClient.PatchAsync("lotes", loteDto);

                    MessageBox.Show("Cambios de guardado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

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
    }
}

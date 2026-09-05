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
            voidPanel.Visible = !(voidPanel.Visible);
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

        private async void sNavModLote(object sender, EventArgs e)
        {
            navBar.SelectedTab = modificarLotesPage;

        }

        private async void sNavAltaLote(object sender, EventArgs e)
        {
            navBar.SelectedTab = altaLotesPage;
        }

        private async void sNavEliminarLote(object sender, EventArgs e)
        {
            navBar.SelectedTab = eliminarLotesPage;
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

                    ktTablaLotes.Columns["IdLote"].HeaderText = "IdLote";
                    ktTablaLotes.Columns["IdProv"].HeaderText = "IdProveedor";
                    ktTablaLotes.Columns["IdMateriaP"].HeaderText = "IdMateriaP";
                    ktTablaLotes.Columns["EstadoLote"].HeaderText = "EstadoLote";
                    ktTablaLotes.Columns["FechaDeIngreso"].HeaderText = "FechaIngreso";
                    ktTablaLotes.Columns["FechaDeVencimiento"].HeaderText = "FechaVencimiento";
                    ktTablaLotes.Columns["CantidadLote"].HeaderText = "CantidadLote";

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

            var listadoMP = await _apiClient.ObtenerListaAsync<MateriaPrimaDTO>(endpoint);

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

                nuevoLote.IdMateriaP = Convert.ToInt32(SelectMP.SelectedValue); ;
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



    }
}

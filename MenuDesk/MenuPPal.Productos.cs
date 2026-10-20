using Alemana.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KimTools;
using KimTools.WinForms;

namespace MenuDesk
{
    partial class MenuPPal

    {
        private void ProductosPage_CheckedChanged(object sender, EventArgs e)
        {
            panelLotes.Visible = false;
            panelOperarios.Visible = false;
            panelSucursales.Visible = false;
            panelProductos.Visible = !(panelProductos.Visible);
            panelProductos.Enabled = !(panelProductos.Enabled);
        }

        private async void cargarTablasProd_Click(object sender, EventArgs e)
        {
            try
            {
                await ListarRecetas();
                await CargarProductosEnGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un problema al conectar con la API de productos: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void altaProductoButton_Click(object sender, EventArgs e)
        {
            navBarProductos.SelectedTab = altaProductoPage;

        }

        private void ModificarProducto_Click(object sender, EventArgs e)
        {
            navBarProductos.SelectedTab = modificarProductoPage;
        }

        private void EliminarProducto_Click(object sender, EventArgs e)
        {
            navBarProductos.SelectedTab = eliminarProductoPage;
        }

        private void buttonAgregarReceta_Click(object sender, EventArgs e)
        {
            var miniMenuReceta = new MiniMenuReceta();
            miniMenuReceta.StartPosition = FormStartPosition.CenterScreen;
            miniMenuReceta.FormBorderStyle = FormBorderStyle.None;

            var pPantalla = proveedorButton.PointToScreen(new Point(0, proveedorButton.Height));
            miniMenuReceta.Location = pPantalla;

            miniMenuReceta.Deactivate += (s, args) => miniMenuReceta.Close();

            miniMenuReceta.Show(this);

        }

        //NUEVO prod guardar
        private async void GuardarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                ProductoDTO n_Prod = new ProductoDTO();
                var rta = new RecetaProductoDTO();
                n_Prod.Nombre = textBoxNomAP.Text;
                n_Prod.Camara = checkBoxCamAP.Checked;
                n_Prod.Disponible = checkBoxDispAP.Checked;
                n_Prod.StockActual = Convert.ToInt32(textBoxStockAP.Text);
                n_Prod.IdReceta = Convert.ToInt32(selectorRAP.SelectedValue);
                await _apiClient.PostAsync("producto", n_Prod);
                MessageBox.Show("Producto guardado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //limpio los campos porque sino queda todo cargado
                textBoxNomAP.Clear();
                checkBoxCamAP.Checked = false;
                checkBoxDispAP.Checked = false;
                textBoxStockAP.Clear();
                selectorRAP.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con el servidor: \n{ex.Message}\n ", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //selectores de receta
        private async Task ListarRecetas()
        {
            string endpoint = "Recetas";

            var listadoRecetas = await _apiClient.ObtenerListaAsync<RecetaProductoDTO>(endpoint);

            if (listadoRecetas != null)
            {
                selectorRAP.DisplayMember = "Descripcion";
                selectorRAP.ValueMember = "IdReceta";
                selectorRMProd.DisplayMember = "Descripcion";
                selectorRMProd.ValueMember = "IdReceta";

                selectorRAP.DataSource = listadoRecetas; //de alta
                selectorRMProd.DataSource = listadoRecetas; //de modificar

            }
        }
        //las tablas de modificar y eliminar prod
        private async Task CargarProductosEnGrilla()
        {
            string endpoint = "producto";
            var listado = await _apiClient.ObtenerListaAsync<ProductoDTO>(endpoint);
            //prueba porque no me trae los nombres!1!1!
            /*MessageBox.Show(listado[0].Nombre);
            foreach (var producto in listado)
            {
                Console.WriteLine($"Nombre: {producto.Nombre}");
            }
            */
            if (listado != null)
            {
                tablaMProd.DataSource = listado;
                tablaEP.DataSource = listado;

            }
        }
        //que me traiga los datos actuales del producto al seleccionarlo del datagrid 
        private void modifProductosTabla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var fila = tablaMProd.Rows[e.RowIndex];

            textBoxNomMP.Text = fila.Cells["nombrePM"].Value?.ToString();
            checkBoxCamMP.Checked = Convert.ToBoolean(fila.Cells["camaraPM"].Value);
            checkBoxDispMP.Checked = Convert.ToBoolean(fila.Cells["disponiblePM"].Value);
            textBoxStockMP.Text = fila.Cells["stockPM"].Value?.ToString();
            selectorRMProd.SelectedValue = Convert.ToInt32(fila.Cells["idRecetaPM"].Value);
            
        }
        //MODIFICAR prod guardar
        private async void GuardarCambiosProd_Click(object sender, EventArgs e)
        {
            try
            {
                string endpoint = "producto";

                var prodM = tablaMProd.CurrentRow;

                if (prodM != null)
                {
                    var prod = new ProductoDTO();

                    prod.IdProducto = Convert.ToInt32(prodM.Cells["idProductoM"].Value);
                    prod.Nombre = textBoxNomMP.Text;
                    prod.Camara = checkBoxCamMP.Checked;
                    prod.Disponible = checkBoxDispMP.Checked;
                    prod.IdReceta = Convert.ToInt32(selectorRMProd.SelectedValue);
                    //prueba porque no me cambia el estado de disponible
                    /* MessageBox.Show($"Cámara: {camaraModifCheckBox.Checked}\n" + $"Disponible: {dispModifCheckBox.Checked}");*/
                    await _apiClient.PutAsync(endpoint, prod); 
                    MessageBox.Show("Cambios de guardado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxNomAP.Clear();
                    checkBoxCamAP.Checked = false;
                    checkBoxDispAP.Checked = false;
                    textBoxStockAP.Clear();
                    selectorRAP.SelectedIndex = -1;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al ejecutar el guardado de las modificaciones del producto: {ex.Message}", "Error de Guardado", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        //ELIMINAR prod 
        private async void confirmarEPbutton_Click(object sender, EventArgs e)
        {
            try
            {

                var elim = tablaEP.CurrentRow;
                if (elim != null)
                {
                    int idP = Convert.ToInt32(elim.Cells["idProductoE"].Value);
                    var eliminado = await _apiClient.DeleteAsync($"producto/{idP}");

                    if (eliminado)
                        MessageBox.Show("Producto eliminado", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("No se pudo eliminar el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el producto: {ex.Message}", "Error de eliminación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}

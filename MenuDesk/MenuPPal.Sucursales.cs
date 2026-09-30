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
        private async void abrirMenuSucursales_Click(object sender, EventArgs e) {
            await CargarSucursalesEnGrilla();
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

    }
}

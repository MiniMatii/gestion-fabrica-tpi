using Alemana.API;
using Alemana.DTOs;
using KimTools.WinForms;
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
    public partial class FormCrearPedido : KtWindow
    {
        private ApiClient _apiClient = null!;
        public FormCrearPedido()
        {
            InitializeComponent();
            AplicarEstiloTabla(tablaGPedido);
        }

        public FormCrearPedido(ApiClient api) : this()
        {
            _apiClient = api;
        }

        private void ktButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void ktButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = this.WindowState == FormWindowState.Maximized
            ? FormWindowState.Normal
            : FormWindowState.Maximized;
        }
        private void ktButton3_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(0);

        }


        public async Task CargarProductosPedidoEnGrilla()
        {
            try
            {
                string endpoint = "producto";

                var listadoProductos = await _apiClient.ObtenerListaAsync<ProductoDTO>(endpoint);
                tablaGPedido.DataSource = listadoProductos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con el servidor: \n{ex.Message}\n ", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }



        private async void GenerarPedidosPage_Click(object sender, EventArgs e)
        {
            await CargarProductosPedidoEnGrilla();
            PagePedidoSucursal.Visible = !(PagePedidoSucursal.Visible);
        }


        private static void AplicarEstiloTabla(params DataGridView[] tablas)
        {
            var verde = Color.FromArgb(0, 78, 65);
            var dorado = Color.FromArgb(173, 151, 98);


            foreach (var g in tablas)
            {
                if (g == null) continue;
                foreach (var estilo in new[] { g.DefaultCellStyle, g.AlternatingRowsDefaultCellStyle })
                {

                    estilo.BackColor = verde;
                    estilo.ForeColor = Color.White;
                    estilo.SelectionBackColor = dorado;
                    estilo.SelectionForeColor = Color.White;
                }


                g.ColumnHeadersDefaultCellStyle.BackColor = verde;
                g.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                g.ColumnHeadersDefaultCellStyle.SelectionBackColor = verde;
                g.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            }

        }

        private async void buttonGenerarPedido_Click(object sender, EventArgs e)   
        {
            try
            {

                if (_apiClient.Rol != "Empleado" || _apiClient.IdUsuario is not int idEmpleado)
                {
                    MessageBox.Show("Solo un empleado con sesión iniciada puede generar pedidos.");
                    return;
                }

                if (tablaGPedido.SelectedRows.Count == 0)
                {
                    MessageBox.Show("El pedido debe tener al menos un producto seleccionado.");
                    return;
                }

                tablaGPedido.EndEdit();

                var n_Ped = new SolicitudPedidoDTO
                {
                    FechaPedido = DateTime.Now,
                    EstadoPedido = "Pendiente",
                    FechaEstimada = fechaEstimada.Value,
                    IdEmpleado = idEmpleado
                };

                foreach (DataGridViewRow fila in tablaGPedido.Rows)
                {
                    if (fila.IsNewRow) continue;

                    string textoCantidad = Convert.ToString(fila.Cells["CantidadSolicitada"].Value) ?? "";

                    if (string.IsNullOrWhiteSpace(textoCantidad)) continue;

                    string nombre = Convert.ToString(fila.Cells["Nombre"].Value) ?? "";

                    if (!int.TryParse(Convert.ToString(fila.Cells["Id"].Value), out int idProducto) || idProducto <= 0)
                    {
                        MessageBox.Show($"El producto \"{nombre}\" no tiene un id válido.");
                        return;
                    }

                    if (!int.TryParse(Convert.ToString(fila.Cells["CantidadSolicitada"].Value), out int cantidad) || cantidad <= 0)
                    {
                        MessageBox.Show($"Indicá una cantidad mayor a 0 para \"{nombre}\".");
                        return;
                    }

                    n_Ped.DetallePedidos.Add(new PedidoItemDTO
                    {
                        IdProducto = idProducto,
                        NombreProducto = nombre,
                        CantidadPedida = cantidad
                    });
                }


                bool ok = await _apiClient.PostAsync("pedidos", n_Ped);

                if (!ok)
                {
                    MessageBox.Show("No se pudo generar el pedido. Revisá la conexión o tu sesión.");
                    return;
                }

                MessageBox.Show("Pedido generado correctamente.");
  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el pedido: " + ex.Message);
            }
        }
    }
}

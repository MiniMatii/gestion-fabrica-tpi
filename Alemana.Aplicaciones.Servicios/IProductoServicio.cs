using Alemana.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alemana.DTOs;


namespace Alemana.Aplicaciones.Servicios
{
    public interface IProductoServicio
    {

        Task<ProductoDTO> AgregarProducto(ProductoDTO unProducto);
        Task<ProductoDTO> BajaProducto(int id);
        Task<bool> EliminarProducto(int id);
        Task<bool> ActualizarProducto(ProductoDTO unProducto);
        Task<List<ProductoDTO>> ObtenerTodos();
        Task<List<ProductoDTO>> ObtenerDisponibles();
        Task<ProductoDTO> ObtenerPorId(int id);
    }
}

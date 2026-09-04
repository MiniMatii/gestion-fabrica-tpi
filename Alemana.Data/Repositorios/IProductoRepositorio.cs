using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alemana.Dominio.Models;


namespace Alemana.Data.Repositorios
{
    public interface IProductoRepositorio
    {
        Task<Producto> AgregarProducto(Producto unProducto);
        Task<Producto> BajaProducto(int id);
        Task<bool> EliminarProducto(int id);
        Task<bool> ActualizarProducto(Producto unProducto);
        Task<Producto> ObtenerProductoPorId(int id);
        Task<List<Producto>> ObtenerTodos();
        Task<List<Producto>> ObtenerDisponibles();
    }
}

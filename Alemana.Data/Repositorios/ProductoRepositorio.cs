using Alemana.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alemana.Data.Repositorios
{
    public class ProductoRepositorio : IProductoRepositorio
    {

        private readonly DbAlemanaContext _DbA;
        public ProductoRepositorio(DbAlemanaContext DbA) 
        {
            _DbA = DbA;
        }


        public async Task<Producto> AgregarProducto(Producto unProducto) 
        {
            if (unProducto == null)
            {
                return null;
            }
            var recetaProd = await _DbA.Recetaproductos.FindAsync(unProducto.IdReceta);
            
            if (recetaProd == null)
            {
                return null;
            }

            unProducto.IdReceta = recetaProd.IdReceta;
            recetaProd.Producto = unProducto;
            _DbA.Productos.Add(unProducto);

            

            await _DbA.SaveChangesAsync();
            return unProducto;
        }
        public async Task<Producto> BajaProducto(int id) 
        {
            var prE = await _DbA.Productos.FindAsync(id);
            if (prE == null)
            {
                return null;
            }

            prE.Disponible = false;
            await _DbA.SaveChangesAsync();
            return prE;
        }
        public async Task<bool> EliminarProducto(int id) 
        {
            var prE = await _DbA.Productos.FindAsync(id);
            if (prE == null)
            {
                return false;
            }
            _DbA.Productos.Remove(prE);
            await _DbA.SaveChangesAsync();
            return true;
        }
        public async Task<bool> ActualizarProducto(Producto unProducto) 
        {
            var prE = await _DbA.Productos.FindAsync(unProducto.IdProducto);
            if (prE == null)
            {
                return false;
            }
            if (!string.IsNullOrWhiteSpace(unProducto.Nombre) && unProducto.Nombre != "string") 
            {
                prE.Nombre = unProducto.Nombre;
            }
            prE.Camara = unProducto.Camara;
            prE.Disponible = unProducto.Disponible;
            prE.IdReceta = unProducto.IdReceta;
            prE.StockActual = unProducto.StockActual;
            await _DbA.SaveChangesAsync();
            return true;
        }

        public async Task<Producto> ObtenerProductoPorId(int id) 
        {
            var prE = await _DbA.Productos.FindAsync(id);
            if (prE == null)
            {
                return null;
            }
            return prE;
        }

    }
}

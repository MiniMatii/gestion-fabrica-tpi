using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alemana.Dominio.Models;

namespace Alemana.Data.Repositorios
{
    public class ProductoRepositorio : IProductoRepositorio
    {
        private readonly DbAlemanaContext _DbA;

        public ProductoRepositorio(DbAlemanaContext dbA)
        {
            _DbA = dbA;
        }
        public async Task<Producto?> GetProducto(int idP)
        {
            return await _DbA.Productos.FindAsync(idP);
        }
    }
}

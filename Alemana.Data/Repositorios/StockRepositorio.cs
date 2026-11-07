using Alemana.Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace Alemana.Data.Repositorios
{
    public class StockRepositorio : IStockRepositorio
    {
        private readonly DbAlemanaContext _db;

        public StockRepositorio(DbAlemanaContext db)
        {
            _db = db;
        }

        public async Task<List<(int IdMateriaP, string Nombre, string Unidad, decimal CantidadNecesaria)>> ObtenerRequerimientosAsync(int idProducto)
        {
            var idReceta = await _db.Productos
                .AsNoTracking()
                .Where(p => p.IdProducto == idProducto)
                .Select(p => p.IdReceta)
                .FirstOrDefaultAsync();

            var filas = await (
                from mr in _db.MateriapReceta.AsNoTracking()
                join mp in _db.Materiaps.AsNoTracking() on mr.IdMateriaP equals mp.IdMateriaP
                where mr.IdReceta == idReceta
                select new { mr.IdMateriaP, mp.Nombre, mp.Unidad, mr.CantidadNecesaria }
            ).ToListAsync();

            return filas
                .Select(f => (f.IdMateriaP, f.Nombre, f.Unidad, f.CantidadNecesaria))
                .ToList();
        }

        public async Task<List<Lote>> ObtenerLotesDisponiblesAsync(int idMateriaP)
        {
            var hoy = DateTime.Today;

            return await _db.Lotes
                .Where(l => l.IdMateriaP == idMateriaP
                         && l.EstadoLote == 1
                         && l.CantidadLote > 0
                         && l.FechaVencimiento >= hoy)
                .OrderBy(l => l.FechaIngreso)      
                .ThenBy(l => l.IdLote)
                .ToListAsync();
        }

        public async Task<int> ObtenerStockProductoAsync(int idProducto)
        {
            var stock = await _db.Productos
                .AsNoTracking()
                .Where(p => p.IdProducto == idProducto)
                .Select(p => (int?)p.StockActual)
                .FirstOrDefaultAsync();

            return Math.Max(stock ?? 0, 0);
        }

        public async Task<Producto?> ObtenerProductoAsync(int idProducto)
        {
            return await _db.Productos.FirstOrDefaultAsync(p => p.IdProducto == idProducto);
        }
    }
}
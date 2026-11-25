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

        public async Task<List<(int IdProd, int Saldo)>> ObtenerOrdenesConSaldoAsync(int idProducto)
        {
            var ordenes = await _db.Ordenproduccions.AsNoTracking()
                .Where(o => o.IdProducto == idProducto && o.EstadoOrden == "Finalizada" && o.FechaReal != null)
                .OrderBy(o => o.FechaReal).ThenBy(o => o.IdProd)
                .Select(o => new { o.IdProd, o.CantidadAproducir })
                .ToListAsync();

            var asignado = await _db.DetalleDespachos.AsNoTracking()
                .Where(x => x.IdProdNavigation.IdProducto == idProducto)
                .GroupBy(x => x.IdProd)
                .Select(g => new { IdProd = g.Key, Cantidad = g.Sum(x => x.Cantidad) })
                .ToDictionaryAsync(x => x.IdProd, x => x.Cantidad);

            return ordenes
                .Select(o => (o.IdProd, Saldo: o.CantidadAproducir - (asignado.TryGetValue(o.IdProd, out var a) ? a : 0)))
                .Where(o => o.Saldo > 0)
                .ToList();
        }

        public async Task<Dictionary<int, decimal>> ObtenerReservadoPorOrdenesEnProcesoAsync()
        {
            var filas = await (
                from o in _db.Ordenproduccions.AsNoTracking()
                where o.EstadoOrden == "En Proceso"
                join p in _db.Productos.AsNoTracking() on o.IdProducto equals p.IdProducto
                join mr in _db.MateriapReceta.AsNoTracking() on p.IdReceta equals mr.IdReceta
                select new { mr.IdMateriaP, Cantidad = mr.CantidadNecesaria * o.CantidadAproducir }
            ).ToListAsync();

            return filas
                .GroupBy(f => f.IdMateriaP)
                .ToDictionary(g => g.Key, g => g.Sum(f => f.Cantidad));
        }
    }
}
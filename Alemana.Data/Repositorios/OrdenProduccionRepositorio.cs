using Alemana.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alemana.Data.Repositorios
{
    public class OrdenProduccionRepositorio : IOrdenProduccionRepositorio
    {
        private readonly DbAlemanaContext _db;

        public OrdenProduccionRepositorio(DbAlemanaContext db)
        {
            _db = db;
        }

        public async Task<List<Ordenproduccion>> ObtenerTodas()
        {
            return await _db.Ordenproduccions.AsNoTracking().ToListAsync();
        }

        public async Task<Ordenproduccion?> ObtenerPorId(int id)
        {
            return await _db.Ordenproduccions.FindAsync(id);
        }

        public async Task<Ordenproduccion> Agregar(Ordenproduccion entidad)
        {
            _db.Ordenproduccions.Add(entidad);
            await _db.SaveChangesAsync();
            return entidad;
        }

        public async Task<bool> Actualizar(Ordenproduccion entidad)
        {
            var existente = await _db.Ordenproduccions.FindAsync(entidad.IdProd);
            if (existente == null) return false;

            existente.EstadoPedido = entidad.EstadoPedido;
            existente.FechaEstimada = entidad.FechaEstimada;
            existente.FechaReal = entidad.FechaReal;
            existente.CantidadRequerida = entidad.CantidadRequerida;
            existente.IdProducto = entidad.IdProducto;
            existente.IdPedido = entidad.IdPedido;

            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var existente = await _db.Ordenproduccions.FindAsync(id);
            if (existente == null) return false;

            _db.Ordenproduccions.Remove(existente);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> TieneDependencias(int idProd)
        {
            return await _db.Consumolotes.AnyAsync(c => c.IdProd == idProd)
                || await _db.OrdAsigOps.AnyAsync(a => a.IdProd == idProd);
        }
    }
}

using Alemana.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alemana.Data.Repositorios
{
    public class OrdAsigOpRepositorio : IOrdAsigOpRepositorio
    {
        private readonly DbAlemanaContext _db;

        public OrdAsigOpRepositorio(DbAlemanaContext db)
        {
            _db = db;
        }

        public async Task<List<OrdAsigOp>> ObtenerTodas()
        {
            return await _db.OrdAsigOps.AsNoTracking().ToListAsync();
        }

        public async Task<List<OrdAsigOp>> ObtenerPorOrden(int idProd)
        {
            return await _db.OrdAsigOps
                .AsNoTracking()
                .Where(a => a.IdProd == idProd)
                .ToListAsync();
        }

        public async Task<OrdAsigOp?> ObtenerPorId(int idProd, int idOperario)
        {     
            return await _db.OrdAsigOps.FindAsync(idProd, idOperario);
        }

        public async Task<OrdAsigOp> Agregar(OrdAsigOp entidad)
        {
            _db.OrdAsigOps.Add(entidad);
            await _db.SaveChangesAsync();
            return entidad;
        }

        public async Task<bool> Actualizar(OrdAsigOp entidad)
        {
            var existente = await _db.OrdAsigOps.FindAsync(entidad.IdProd, entidad.IdOperario);
            if (existente == null) return false;

            existente.Cantidades = entidad.Cantidades;
            existente.FechaIni = entidad.FechaIni;
            existente.FechaFin = entidad.FechaFin;

            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int idProd, int idOperario)
        {
            var existente = await _db.OrdAsigOps.FindAsync(idProd, idOperario);
            if (existente == null) return false;

            _db.OrdAsigOps.Remove(existente);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<int> TotalAsignadoPorOrden(int idProd, int? excluirIdOperario = null)
        {
            var consulta = _db.OrdAsigOps.Where(a => a.IdProd == idProd);

            if (excluirIdOperario.HasValue)
                consulta = consulta.Where(a => a.IdOperario != excluirIdOperario.Value);

            return await consulta.SumAsync(a => (int?)a.Cantidades) ?? 0;
        }
    }
}

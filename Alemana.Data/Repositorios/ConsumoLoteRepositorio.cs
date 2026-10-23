using Alemana.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alemana.Data.Repositorios
{
    public class ConsumoLoteRepositorio : IConsumoLoteRepositorio
    {
        private readonly DbAlemanaContext _db;

        public ConsumoLoteRepositorio(DbAlemanaContext db)
        {
            _db = db;
        }

        public async Task<List<Consumolote>> ObtenerTodos()
        {
            return await _db.Consumolotes.AsNoTracking().ToListAsync();
        }

        public async Task<List<Consumolote>> ObtenerPorOrden(int idProd)
        {
            return await _db.Consumolotes
                .AsNoTracking()
                .Where(c => c.IdProd == idProd)
                .ToListAsync();
        }

        public async Task<Consumolote?> ObtenerPorId(int id)
        {
            return await _db.Consumolotes.FindAsync(id);
        }

        public async Task<Consumolote> Agregar(Consumolote entidad)
        {
            _db.Consumolotes.Add(entidad);
            await _db.SaveChangesAsync();
            return entidad;
        }

        public async Task<bool> Actualizar(Consumolote entidad)
        {
            var existente = await _db.Consumolotes.FindAsync(entidad.IdConsumo);
            if (existente == null) return false;

            existente.CantConsumida = entidad.CantConsumida;
            existente.IdProd = entidad.IdProd;
            existente.IdLote = entidad.IdLote;

            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var existente = await _db.Consumolotes.FindAsync(id);
            if (existente == null) return false;

            _db.Consumolotes.Remove(existente);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<decimal> TotalConsumidoPorLote(int idLote, int? excluirIdConsumo = null)
        {
            var consulta = _db.Consumolotes.Where(c => c.IdLote == idLote);

            if (excluirIdConsumo.HasValue)
                consulta = consulta.Where(c => c.IdConsumo != excluirIdConsumo.Value);

            return await consulta.SumAsync(c => (decimal?)c.CantConsumida) ?? 0m;
        }
    }
}

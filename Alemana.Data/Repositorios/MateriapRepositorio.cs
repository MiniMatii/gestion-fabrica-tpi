using Alemana.Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace Alemana.Data.Repositorios
{
    public class MateriapRepositorio : IMateriapRepositorio
    {
        private readonly DbAlemanaContext _DbA;

        public MateriapRepositorio(DbAlemanaContext DbA)
        {
            this._DbA = DbA;
        }

        public async Task<Materiap> AgregarMateriaPrima(Materiap materiaPrima)
        {
            if (materiaPrima == null)
            {
                return null;
            }

            await _DbA.Materiaps.AddAsync(materiaPrima);
            await _DbA.SaveChangesAsync();

            return materiaPrima;
        }

        public async Task<List<Materiap>> ObtenerTodos()
        {
            return await _DbA.Set<Materiap>().ToListAsync();
        }

        public async Task<Materiap> ObtenerPorId(int id)
        {
            return await _DbA.Set<Materiap>().FindAsync(id);
        }

        public async Task ModificarMateriaPrima(Materiap materiaPrima)
        {
            _DbA.Set<Materiap>().Update(materiaPrima);
            await _DbA.SaveChangesAsync();
        }
    }
}
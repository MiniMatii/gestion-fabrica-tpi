using Alemana.Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace Alemana.Data.Repositorios
{
    public class RecetaProductoRepositorio : IRecetaProductoRepositorio
    {
        private readonly DbAlemanaContext _DbA;

        public RecetaProductoRepositorio(DbAlemanaContext dbA)
        {
            _DbA = dbA;
        }

        public async Task AltaReceta(Recetaproducto nuevaReceta) 
        {

            await _DbA.Recetaproductos.AddAsync(nuevaReceta);

            await _DbA.SaveChangesAsync();

        }

        public async Task<Recetaproducto> ModificarReceta(Recetaproducto recetaM) 
        {
            var recetaExistente = await _DbA.Recetaproductos.FindAsync(recetaM.IdReceta);

            if (recetaExistente == null)
            {
                return recetaM;

            }
            if (!string.IsNullOrWhiteSpace(recetaM.Descripcion) && recetaM.Descripcion != "string")
            {
                recetaExistente.Descripcion = recetaM.Descripcion;
            }

            recetaExistente.Rinde = recetaM.Rinde;
            await _DbA.SaveChangesAsync();
            return recetaExistente;

        }

        public async Task<bool> EliminarReceta(int idR)
        {
            var receta = await _DbA.Recetaproductos.FindAsync(idR);

            if (receta == null)
            {
                return false;
            }

            _DbA.Recetaproductos.Remove(receta);

            await _DbA.SaveChangesAsync();

            return true;
        }
       
        public async Task<Recetaproducto?> GetRecetaproducto(int idReceta)
        {
            var rExistente = await _DbA.Recetaproductos.FindAsync(idReceta);
            return rExistente;
        }

        public async Task AgregarMateriaPrima(Recetaproducto recetaM)
        {
            _DbA.Update(recetaM);
            await _DbA.SaveChangesAsync();
        }

        public async Task<List<Recetaproducto>> ObtenerTodos()
        {
            return await _DbA.Recetaproductos
                .Include(r => r.MateriapReceta)
                .ToListAsync();
        }


        
    }
}

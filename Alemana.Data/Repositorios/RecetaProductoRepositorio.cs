using Alemana.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;
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

            public async Task<Recetaproducto> AltaReceta(Recetaproducto nuevaR)
            {
            if (nuevaR is null)
            {
                return null;
            }  
               await _DbA.Recetaproductos.AddAsync(nuevaR);

                await _DbA.SaveChangesAsync();

                return nuevaR;
            }

            public async Task<Recetaproducto> ModificarReceta(Recetaproducto recetaM)
            { 
            if (recetaM is null)
            {
                return null;
            }

            var recetaExistente = await _DbA.Recetaproductos
                .FindAsync(recetaM.IdReceta);

            if (recetaExistente is null)
            {
                return null;
            }

            recetaExistente.Descripcion = recetaM.Descripcion;

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
    }


   
}

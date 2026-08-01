using Alemana.Dominio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alemana.Data.Repositorios
{
    public class CapacidadesRepositorio : ICapacidadesRepositorio
    {
        private readonly DbAlemanaContext _DbA;

        public CapacidadesRepositorio(DbAlemanaContext DbA)
        {
            this._DbA = DbA;
        }


        public async Task<bool> AltaCapacidad(Capacidad unaCapa)
        {
            if (unaCapa == null)
            {
                return false;
            }

            await _DbA.Capacidads.AddAsync(unaCapa);
            await _DbA.SaveChangesAsync();
            return true;

        }
    }
}

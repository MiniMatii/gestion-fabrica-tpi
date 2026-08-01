using Alemana.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alemana.Data.Repositorios
{
    public class OperarioRepositorio : IOperarioRepositorio
    {
        private readonly DbAlemanaContext _DbA;

        public OperarioRepositorio(DbAlemanaContext DbA)
        {
            this._DbA = DbA;
        }

        public async Task<bool> AltaOperario(Operario iOp)
        {
            if (iOp == null)
            {
                return false;
            }

            await _DbA.Operarios.AddAsync(iOp);
            await _DbA.SaveChangesAsync();
            return true;
        }

        public async Task<bool> BajaOperario(int idOpe)
        {
            var OpeE = await _DbA.Operarios.FindAsync(idOpe);

            if (OpeE == null)
            {
                return false;
            }

            OpeE.Disponibilidad = 0;

            await _DbA.SaveChangesAsync();

            return true;
        }

        public async Task<bool> AsignarCapacidad(int idOperario, int idCapacidad) 
        {
            var opE = await _DbA.Operarios.FindAsync(idOperario);
            var capE = await _DbA.Capacidads.FindAsync(idCapacidad);

            if (capE == null) 
            {
                return false;
            }

            if (opE == null) 
            {
                return false;
            }

            opE.IdCaps.Add(capE);
            capE.IdOperarios.Add(opE);

            await _DbA.SaveChangesAsync();

            return true;
        }



    }
}

using Alemana.Dominio.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Operario> AltaOperario(Operario unOperario)
        {
            if (unOperario == null)
            {
                return null;
            }

            await _DbA.Operarios.AddAsync(unOperario);
            await _DbA.SaveChangesAsync();
            return unOperario;
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

        public async Task<List<int>> AsignarCapacidad(int idOperario, List<int> idCapacidad) 
        {
            var opE = await _DbA.Operarios.FindAsync(idOperario);
            var capE = await _DbA.Capacidads.Where(c => idCapacidad.Contains(c.IdCap)).ToListAsync();

            if (capE == null || opE == null) 
            {
                return null;
            }

            foreach (var cap in capE)
            {
                if (!opE.IdCaps.Contains(cap) && (!cap.IdOperarios.Contains(opE)))
                {
                    opE.IdCaps.Add(cap);
                    cap.IdOperarios.Add(opE);
                    
                }
            }
            
            await _DbA.SaveChangesAsync();

            return capE.Select(c => c.IdCap).ToList();
        }

        public async Task<Operario> ModificarOperario(int idOp)
        {
            var opE = await _DbA.Operarios.FindAsync(idOp);
            if (opE == null)
            {
                return null;
            }


            return opE;

        }


        public async Task GuardarCambios() 
        {
            await _DbA.SaveChangesAsync();
        }

    }
}

using Alemana.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alemana.Data.Repositorios
{
    public class LoteRepositorio : ILoteRepositorio
    {

        private readonly DbAlemanaContext _DbA;

        public LoteRepositorio(DbAlemanaContext DbA) 
        {
            this._DbA = DbA;
        }


        public async Task<Lote> AgregarLote(Lote iLote) 
        {
            if (iLote == null)
            {
                return null;
            }

            await _DbA.Lotes.AddAsync(iLote);
            await _DbA.SaveChangesAsync();
            return iLote;
        }


        public async Task<bool> BajaLote(int idLote) 
        {
           var loteE = await _DbA.Lotes.FindAsync(idLote);

            if (loteE == null) 
            {
                return false;
            }

            loteE.EstadoLote = 0;

            await _DbA.SaveChangesAsync();

            return true;
        }


    }
}

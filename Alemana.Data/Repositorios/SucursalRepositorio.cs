using Alemana.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Alemana.Data.Repositorios
{
    public class SucursalRepositorio : ISucursalRepositorio
    {
        private readonly DbAlemanaContext _DbA;

        public SucursalRepositorio(DbAlemanaContext DbA)
        {
            this._DbA = DbA;
        }


        public async Task<Sucursale> AgregarUnaSucursal(Sucursale unaSucu) 
        {
            if (unaSucu == null) 
            {
                return null;
            }

            var CiuE = await _DbA.Ciudades.FindAsync(unaSucu.CodPostal);

            if (CiuE == null)
            {
                return null;
            }

            await _DbA.Sucursales.AddAsync(unaSucu);
            await _DbA.SaveChangesAsync();

            return unaSucu;
        }

    }
}

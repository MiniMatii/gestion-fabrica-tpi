using Alemana.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alemana.Data.Repositorios
{
    public class ProveedoresRepositorio : IProveedoresRepositorio
    {
        private readonly DbAlemanaContext _DbA;

        public ProveedoresRepositorio(DbAlemanaContext DbA)
        {
            this._DbA = DbA;
        }


        public async Task<bool> AgregarProveedor(Proveedore prov) 
        {
            if (prov == null)
            {
                return false;
            }

            await _DbA.Proveedores.AddAsync(prov);
            await _DbA.SaveChangesAsync();

            return true;
        }





    }
}

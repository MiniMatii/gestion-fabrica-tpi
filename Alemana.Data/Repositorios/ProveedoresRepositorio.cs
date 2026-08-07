using Alemana.Dominio.Models;
using Microsoft.EntityFrameworkCore;
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


        public async Task<Proveedore> AgregarProveedor(Proveedore prov)
        {
            if (prov == null)
            {
                return null;
            }

            await _DbA.Proveedores.AddAsync(prov);
            await _DbA.SaveChangesAsync();

            return prov;
        }

        public async Task<List<Proveedore>> ObtenerTodos()
        {
            return await _DbA.Set<Proveedore>().ToListAsync();
        }

        public async Task<Proveedore> ObtenerPorId(int id)
        {
            return await _DbA.Set<Proveedore>().FindAsync(id);
        }

        public async Task ModificarProveedor(Proveedore proveedor)
        {
            _DbA.Set<Proveedore>().Update(proveedor);
            await _DbA.SaveChangesAsync();
        }
    } 
}

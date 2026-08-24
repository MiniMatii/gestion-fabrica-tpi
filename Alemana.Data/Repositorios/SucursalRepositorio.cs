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

        public async Task<bool> ModificarSucursal(Sucursale sucursal)
        {
            var sE = await _DbA.Sucursales.FindAsync(sucursal.IdSucursal);
            if (sE!= null)
            {
                sE.NombreSuc = sucursal.NombreSuc;
                sE.CodPostal= sucursal.CodPostal;
                await _DbA.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Sucursale>> ObtenerTodos()
        {
            return await _DbA.Sucursales.ToListAsync();
        }
        
        public async Task<Sucursale> AgregarEmpleados(int ids, List<int> ides)
        {
            var laS = await _DbA.Sucursales.FindAsync(ids);

            if (laS is not null)
            {
                foreach (int i in ides)
                {
                    var empleado = await _DbA.Empleados.FindAsync(i);

                    if (empleado is null)
                    {
                        throw new ArgumentException($"No existe el empleado con ID {i}.");
                    }

                    laS.Empleados.Add(empleado);
                }

                await _DbA.SaveChangesAsync();
            }

            return laS;
        }
    }
}

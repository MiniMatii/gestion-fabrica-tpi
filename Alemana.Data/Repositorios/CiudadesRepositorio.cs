using Alemana.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace Alemana.Data.Repositorios
{
    public class CiudadesRepositorio : ICiudadesRespositorio
    {
        private readonly DbAlemanaContext _DbA;

        public CiudadesRepositorio(DbAlemanaContext DbA)
        {
            this._DbA = DbA;
        }

        public async Task<Ciudade> AltaCiudad(Ciudade nuevaciudad)
        {
            if (nuevaciudad == null)
            {
                return null;
            }
            await _DbA.Ciudades.AddAsync(nuevaciudad); //como aparece en el dbset
            await _DbA.SaveChangesAsync();
            return nuevaciudad;
        }

        public async Task<List<Sucursale>> AgregarSucursal(int idCiudad, List<int> idSucursal)
        {
            var laCiudad = await _DbA.Ciudades.FindAsync(idCiudad);
            var sucursales = await _DbA.Sucursales.Where(s => idSucursal.Contains(s.IdSucursal)).ToListAsync();
            if (laCiudad is null || sucursales is null)
            {
                return []; //o null? no sé
            }

            foreach (var s in sucursales)
            {
                if (!laCiudad.Sucursales.Contains(s)) //verifico que la ciudad no contenga esa sucursal en la lista
                {
                    laCiudad.Sucursales.Add(s);
                    //debería agregar la ciudad a la sucursal?
                }
            }
            await _DbA.SaveChangesAsync();

            return sucursales;
            //return sucursales.Select(s => s.IdSucursal).ToList(); no entendí por qué acá no pasamos la lista de sucursales directamente
        }
        public async Task<Ciudade> GetCiudad(int idC)
        {
            var laC = await _DbA.Ciudades.FindAsync(idC);

            if (laC is null)
            {
                return null;
            }
            return laC;

        }

    }
}

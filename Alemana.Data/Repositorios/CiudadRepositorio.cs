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
    public class CiudadRepositorio : ICiudadRespositorio
    {
        private readonly DbAlemanaContext _DbA;

        public CiudadRepositorio(DbAlemanaContext DbA)
        {
            this._DbA = DbA;
        }

        public async Task<Ciudade> AltaCiudad(Ciudade nuevaciudad)
        {
            if (nuevaciudad == null)
            {
                return null;
            }
            await _DbA.Ciudades.AddAsync(nuevaciudad); 
            await _DbA.SaveChangesAsync();
            return nuevaciudad;
        }

        public async Task<Ciudade> BuscarCiudad(int idC)
        {
            var laC = await _DbA.Ciudades.FindAsync(idC);

            if (laC is null)
            {
                return null;
            }
            return laC;

        }

        public async Task<List<Ciudade>> BuscarTodas()
        {
            return _DbA.Ciudades.ToList();
        }

        public async Task<bool> BorrarCiudad(int idC)
        {
            var ciudad = await _DbA.Ciudades.FindAsync(idC);
            if (ciudad == null)
            {
                return false;
            }

            _DbA.Ciudades.Remove(ciudad);
            await _DbA.SaveChangesAsync();
            return true;
        }


    }
}
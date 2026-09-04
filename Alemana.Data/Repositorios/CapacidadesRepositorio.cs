using Alemana.Dominio.Models;
using Microsoft.EntityFrameworkCore;
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


        public async Task<Capacidad> AltaCapacidad(Capacidad unaCapa)
        {
            if (unaCapa == null)
            {
                return null;
            }

            await _DbA.Capacidads.AddAsync(unaCapa);
            await _DbA.SaveChangesAsync();
            return unaCapa;
        }

        public async Task<bool> BorrarCapacidad(int idCap)
        {
            var capacidad = await _DbA.Capacidads.FindAsync(idCap);
            if (capacidad == null)
            {
                return false;
            }

            _DbA.Capacidads.Remove(capacidad);
            await _DbA.SaveChangesAsync();
            return true;
        }

        public async Task<List<Capacidad>> ObtenerTodos()
        {
            return await _DbA.Set<Capacidad>().ToListAsync();
        }

        public async Task<Capacidad> ObtenerPorId(int id)
        {
            var capacidad = await _DbA.Set<Capacidad>().FindAsync(id);

            if (capacidad == null)
            {
                return null;
            }

            return capacidad;
        }

    }
}

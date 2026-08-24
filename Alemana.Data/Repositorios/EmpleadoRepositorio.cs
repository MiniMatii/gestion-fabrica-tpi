using Alemana.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alemana.Data.Repositorios
{
    public class EmpleadoRepositorio : IEmpleadoRepositorio
    {
        private readonly DbAlemanaContext _DbA;

        public EmpleadoRepositorio(DbAlemanaContext DbA)
        {
            this._DbA = DbA;
        }

        public async Task<Empleado> AltaEmpleado(Empleado empleado)
        {
            if (empleado == null)
            {
                return null;
            }

            await _DbA.Set<Empleado>().AddAsync(empleado);
            await _DbA.SaveChangesAsync();
            return empleado;
        }

        public async Task<List<Empleado>> ObtenerTodos()
        {


            return await _DbA.Empleados.Where(e => e.Disponibilidad == true).ToListAsync();
            //return await _DbA.Set<Empleado>().Where(e => e.Disponibilidad == 1).ToListAsync();
        }

        public async Task<Empleado> ObtenerPorId(int id)
        {
            var empE = await _DbA.Set<Empleado>().FindAsync(id);
            if (empE == null)
            {
                return null;
            }
            return empE;
        }

        public async Task<Empleado> ModificarEmpleado(Empleado empleado)
        {
            _DbA.Set<Empleado>().Update(empleado);
            await _DbA.SaveChangesAsync();
            return empleado;
        }
        public async Task<bool> BajaEmpleado(int idEmpleado, string motivo)
        {
            var empE = await _DbA.Set<Empleado>().FindAsync(idEmpleado);

            if (empE == null)
            {
                return false;
            }

            empE.Disponibilidad = !(empE.Disponibilidad);
            empE.Motivo = motivo;

            await _DbA.SaveChangesAsync();

            return true;
        }
    }
}
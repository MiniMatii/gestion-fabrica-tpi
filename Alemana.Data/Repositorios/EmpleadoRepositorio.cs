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

        public async Task AgregarEmpleado(Empleado empleado)
        {
            await _DbA.Set<Empleado>().AddAsync(empleado);
            await _DbA.SaveChangesAsync();
        }

        public async Task<List<Empleado>> ObtenerTodos()
        {
            return await _DbA.Set<Empleado>().Where(e => e.Disponibilidad == 1).ToListAsync();
        }

        public async Task<Empleado> ObtenerPorId(int id)
        {
            return await _DbA.Set<Empleado>().FindAsync(id);
        }

        public async Task ModificarEmpleado(Empleado empleado)
        {
            _DbA.Set<Empleado>().Update(empleado);
            await _DbA.SaveChangesAsync();
        }
    }
}
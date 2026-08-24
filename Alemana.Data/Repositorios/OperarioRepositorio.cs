using Alemana.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alemana.Data.Repositorios
{
    public class OperarioRepositorio : IOperarioRepositorio
    {
        private readonly DbAlemanaContext _DbA;

        public OperarioRepositorio(DbAlemanaContext DbA)
        {
            this._DbA = DbA;
        }

        public async Task<Operario> ObtenerOperarioPorId(int idOp) 
        {
            var opE= await _DbA.Operarios.FindAsync(idOp);
            if (opE == null)
            {
                return null;
            }
            return opE;
        }

        public async Task<Operario> AltaOperario(Operario unOperario)
        {
            if (unOperario == null)
            {
                return null;
            }

            await _DbA.Operarios.AddAsync(unOperario);
            await _DbA.SaveChangesAsync();
            return unOperario;
        }

        public async Task<bool> BajaOperario(int idOpe)
        {
            var OpeE = await _DbA.Operarios.FindAsync(idOpe);

            if (OpeE == null)
            {
                return false;
            }

            OpeE.Disponibilidad = 0;

            await _DbA.SaveChangesAsync();

            return true;
        }

        public async Task<List<int>> AsignarCapacidad(int idOperario, List<int> idCapacidad) 
        {
            var opE = await _DbA.Operarios.FindAsync(idOperario);
            var capE = await _DbA.Capacidads.Where(c => idCapacidad.Contains(c.IdCap)).ToListAsync();

            if (capE == null || opE == null) 
            {
                return null;
            }

            foreach (var cap in capE)
            {
                if (!opE.IdCaps.Contains(cap) && (!cap.IdOperarios.Contains(opE)))
                {
                    opE.IdCaps.Add(cap);
                    cap.IdOperarios.Add(opE);
                    
                }
            }
            
            await _DbA.SaveChangesAsync();

            return capE.Select(c => c.IdCap).ToList();
        }
        public async Task<Operario> EliminarCapacidadOperario(int idOperario, int idCapacidad) 
        {
            var opE = await _DbA.Operarios.Include(o => o.IdCaps).FirstOrDefaultAsync(o => o.IdOperario == idOperario);
            var capE = await _DbA.Capacidads.FindAsync(idCapacidad);
            if(capE == null || opE == null) 
            {
                return null;
            }
            opE.IdCaps.Remove(capE);
            await _DbA.SaveChangesAsync();
            return opE;
        }

        public async Task<Operario> ModificarOperario(Operario unOperario)
        {
            var opE = await _DbA.Operarios.FindAsync(unOperario.IdOperario);
            if (opE == null)
            {
                return null;
            }
            if (!string.IsNullOrWhiteSpace(unOperario.Nombre) && unOperario.Nombre != "string") 
            { 
                opE.Nombre = unOperario.Nombre; 
            }
            if (!string.IsNullOrWhiteSpace(unOperario.Apellido) && unOperario.Apellido != "string")
            {
                opE.Apellido = unOperario.Apellido;
            }
            opE.Disponibilidad = unOperario.Disponibilidad;
            opE.IdCaps = unOperario.IdCaps;

            await _DbA.SaveChangesAsync();

            return opE;

        }

        public async Task<IEnumerable<Operario>> ObtenerTodos() 
        {
            return await _DbA.Operarios.ToListAsync();
        }

        public async Task<List<Capacidad>> EncontrarCapacidades(List<int> caps)
        {
            var capsList = await _DbA.Capacidads.Where(c => caps.Contains(c.IdCap)).ToListAsync();

            if (capsList == null)
            {
                return null;
            }
            return capsList;
        }
        public async Task GuardarCambios() 
        {
            await _DbA.SaveChangesAsync();
        }
        public async Task<List<Capacidad>> ObtenerCapacidadesAsignadas(int idOp)
        {
            var listado = await _DbA.Capacidads.Where(c => c.IdOperarios.Any(o => o.IdOperario == idOp)).ToListAsync();
            return listado;
        }

        public async Task<bool> EliminarOperario(int idOperario) 
        {
            var opE = await _DbA.Operarios.Include(o => o.IdCaps).FirstOrDefaultAsync(o => o.IdOperario == idOperario);

            if (opE == null) 
            {
                return false;
            }

            opE.IdCaps.Clear();
            _DbA.Operarios.Remove(opE);
            await _DbA.SaveChangesAsync();

            return true;
        }
    }
}

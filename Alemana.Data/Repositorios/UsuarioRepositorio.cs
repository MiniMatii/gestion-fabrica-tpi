using Alemana.Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace Alemana.Data.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly DbAlemanaContext _DbA;

        public UsuarioRepositorio(DbAlemanaContext DbA)
        {
            this._DbA = DbA;
        }

        public async Task<Usuario> ObtenerPorNombreUsuario(string nombreUsuario)
        {
            // Retorna la entidad pura de base de datos
            return await _DbA.Usuarios.FirstOrDefaultAsync(u => u.NombreUsuario == nombreUsuario);
        }


        public async Task<bool> ExisteNombreAsync(string nombreUsuario) 
        {
            return await _DbA.Usuarios.AnyAsync(u => u.NombreUsuario == nombreUsuario);

        }

        public async Task<bool> ExisteEmpleadoAsync(int idEmpleado) 
        {
            return await _DbA.Empleados.AnyAsync(e => e.IdEmpleado == idEmpleado);
        }


        public async Task<bool> ExisteOperarioAsync(int idOperario)
        {
            return await _DbA.Operarios.AnyAsync(o => o.IdOperario == idOperario);

        }

        public async Task<Usuario> AddAsync(Usuario usuario)
        {
            _DbA.Usuarios.Add(usuario);
            await _DbA.SaveChangesAsync();
            return usuario;
        }

    }
}
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
    }
}
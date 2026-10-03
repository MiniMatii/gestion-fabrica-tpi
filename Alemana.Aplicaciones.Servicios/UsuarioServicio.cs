using Alemana.Data.Repositorios;
using BCrypt.Net;
using Alemana.DTOs;
namespace Alemana.Aplicaciones.Servicios
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioServicio(IUsuarioRepositorio usuarioRepo)
        {
            _usuarioRepositorio = usuarioRepo;
        }

        public async Task<UsuarioDTO> Validar(string nombreUsuario, string claveIngresada)
        {
            var usuarioDb = await _usuarioRepositorio.ObtenerPorNombreUsuario(nombreUsuario);

            if (usuarioDb == null)
            {
                return null; 
            }

            bool passwordValida = BCrypt.Net.BCrypt.Verify(claveIngresada, usuarioDb.ClaveHash);
            
            if (!passwordValida)
            {
                return null;
            }

            string rolAsignado = usuarioDb.IdEmpleado != null ? "Empleado" : "Operario";
            
            return new UsuarioDTO
            {
                Nombre = usuarioDb.NombreUsuario,
                Rol = rolAsignado
            };

        }
    }
}
using Alemana.Data.Repositorios;
using Alemana.Dominio.Models;
using Alemana.DTOs;
using BCrypt.Net;
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
                Rol = rolAsignado,
                IdEmpleado = usuarioDb.IdEmpleado,
                IdOperario = usuarioDb.IdOperario
            };

        }

        public async Task<int> RegistrarAsync(LoginDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Usuario))
                throw new ArgumentException("El nombre de usuario es obligatorio.");

            if (string.IsNullOrWhiteSpace(dto.Clave) || dto.Clave.Length < 6)
                throw new ArgumentException("La contraseña debe tener al menos 6 caracteres.");

            if (dto.IdEmpleado.HasValue == dto.IdOperario.HasValue)
                throw new ArgumentException("Indicá un IdEmpleado o un IdOperario (uno solo).");

            if (await _usuarioRepositorio.ExisteNombreAsync(dto.Usuario))
                throw new InvalidOperationException("Ya existe un usuario con ese nombre.");

            if (dto.IdEmpleado.HasValue && !await _usuarioRepositorio.ExisteEmpleadoAsync(dto.IdEmpleado.Value))
                throw new ArgumentException("El empleado indicado no existe.");

            if (dto.IdOperario.HasValue && !await _usuarioRepositorio.ExisteOperarioAsync(dto.IdOperario.Value))
                throw new ArgumentException("El operario indicado no existe.");

            var usuario = new Usuario
            {
                NombreUsuario = dto.Usuario.Trim(),
                ClaveHash = BCrypt.Net.BCrypt.HashPassword(dto.Clave, 12),
                IdEmpleado = dto.IdEmpleado,
                IdOperario = dto.IdOperario
            };

            var creado = await _usuarioRepositorio.AddAsync(usuario);
            return creado.IdUsuario;
        }

    }
}
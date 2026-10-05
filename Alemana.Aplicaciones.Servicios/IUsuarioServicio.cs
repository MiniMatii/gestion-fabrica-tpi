using Alemana.DTOs;

namespace Alemana.Aplicaciones.Servicios
{
    public interface IUsuarioServicio
    {
        Task<UsuarioDTO> Validar(string nombreUsuario, string clave);
        Task<int> RegistrarAsync(LoginDTO dto);
    }
}

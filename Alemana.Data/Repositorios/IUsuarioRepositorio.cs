using Alemana.Dominio.Models;


namespace Alemana.Data.Repositorios
{
    public interface IUsuarioRepositorio
    {

        Task<Usuario> ObtenerPorNombreUsuario(string nombreUsuario);
    }
}

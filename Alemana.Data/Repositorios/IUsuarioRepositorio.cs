using Alemana.Dominio.Models;


namespace Alemana.Data.Repositorios
{
    public interface IUsuarioRepositorio
    {

        Task<Usuario> ObtenerPorNombreUsuario(string nombreUsuario);


        Task<bool> ExisteNombreAsync(string nombreUsuario);
        Task<bool> ExisteEmpleadoAsync(int idEmpleado);
        Task<bool> ExisteOperarioAsync(int idOperario);
        Task<Usuario> AddAsync(Usuario usuario);



    }
}

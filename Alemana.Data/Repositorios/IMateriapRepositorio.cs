using Alemana.Dominio.Models;

namespace Alemana.Data.Repositorios
{
    public interface IMateriapRepositorio
    {
        Task<Materiap> AgregarMateriaPrima(Materiap materiaPrima);
        Task<List<Materiap>> ObtenerTodos();
        Task<Materiap> ObtenerPorId(int id);
        Task ModificarMateriaPrima(Materiap materiaPrima);
    }
}
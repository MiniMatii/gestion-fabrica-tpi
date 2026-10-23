using Alemana.Dominio.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alemana.Data.Repositorios
{
    public interface IConsumoLoteRepositorio
    {
        Task<List<Consumolote>> ObtenerTodos();
        Task<List<Consumolote>> ObtenerPorOrden(int idProd);
        Task<Consumolote?> ObtenerPorId(int id);
        Task<Consumolote> Agregar(Consumolote entidad);
        Task<bool> Actualizar(Consumolote entidad);
        Task<bool> Eliminar(int id);
        Task<decimal> TotalConsumidoPorLote(int idLote, int? excluirIdConsumo = null);
    }
}

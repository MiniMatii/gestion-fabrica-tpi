using Alemana.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alemana.Aplicaciones.Servicios
{
    public interface IConsumoLoteServicio
    {
        Task<List<ConsumoLoteDTO>> ObtenerTodos();
        Task<List<ConsumoLoteDTO>?> ObtenerPorOrden(int idProd);
        Task<ConsumoLoteDTO?> ObtenerPorId(int id);
        Task<ConsumoLoteDTO> Agregar(ConsumoLoteDTO dto);
        Task<bool> Actualizar(ConsumoLoteDTO dto);
        Task<bool> Eliminar(int id);
    }
}

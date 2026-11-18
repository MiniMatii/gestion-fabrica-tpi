using Alemana.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alemana.Aplicaciones.Servicios
{
    public interface IOrdenProduccionServicio
    {
        Task<List<OrdenProduccionDTO>> ObtenerTodas();
        Task<OrdenProduccionDTO?> ObtenerPorId(int id);
        Task<OrdenProduccionDTO> Agregar(OrdenProduccionDTO dto);
        Task<bool> Actualizar(OrdenProduccionDTO dto);
        Task<bool> Eliminar(int id);
        Task<List<OrdenProduccionDTO>> ObtenerProduccionAsync();
        Task<CalculoProduccionDTO> CalcularAsync(CalcularProduccionDTO dto);
        Task<List<OperarioOpcionDTO>?> ObtenerOperariosCapacesAsync(int idProd);
        Task<(ResultadoConfirmacion Resultado, string? Mensaje)> ConfirmarAsync(int idProd, int idOperario);
        Task<(ResultadoConfirmacion Resultado, string? Mensaje)> FinalizarAsync(int idProd);
    }
}

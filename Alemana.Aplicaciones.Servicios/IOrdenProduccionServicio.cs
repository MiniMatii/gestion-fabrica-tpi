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
    }
}

using Alemana.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alemana.Aplicaciones.Servicios
{
    public interface IOrdAsigOpServicio
    {
        Task<List<OrdAsigOpDTO>> ObtenerTodas();
        Task<List<OrdAsigOpDTO>?> ObtenerPorOrden(int idProd); 
        Task<OrdAsigOpDTO?> ObtenerPorId(int idProd, int idOperario);
        Task<OrdAsigOpDTO> Agregar(OrdAsigOpDTO dto);
        Task<bool> Actualizar(OrdAsigOpDTO dto);
        Task<bool> Eliminar(int idProd, int idOperario);
    }
}

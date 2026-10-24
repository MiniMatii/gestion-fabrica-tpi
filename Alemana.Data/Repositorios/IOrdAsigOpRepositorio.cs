using Alemana.Dominio.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alemana.Data.Repositorios
{
    public interface IOrdAsigOpRepositorio
    {
        Task<List<OrdAsigOp>> ObtenerTodas();
        Task<List<OrdAsigOp>> ObtenerPorOrden(int idProd);
        Task<OrdAsigOp?> ObtenerPorId(int idProd, int idOperario);
        Task<OrdAsigOp> Agregar(OrdAsigOp entidad);
        Task<bool> Actualizar(OrdAsigOp entidad);
        Task<bool> Eliminar(int idProd, int idOperario);
        Task<int> TotalAsignadoPorOrden(int idProd, int? excluirIdOperario = null);
    }
}

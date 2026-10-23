using Alemana.Dominio.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alemana.Data.Repositorios
{
    public interface IOrdenProduccionRepositorio
    {
        Task<List<Ordenproduccion>> ObtenerTodas();
        Task<Ordenproduccion?> ObtenerPorId(int id);
        Task<Ordenproduccion> Agregar(Ordenproduccion entidad);
        Task<bool> Actualizar(Ordenproduccion entidad);
        Task<bool> Eliminar(int id);

        Task<bool> TieneDependencias(int idProd);
    }
}

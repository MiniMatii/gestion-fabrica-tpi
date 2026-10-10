using Alemana.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alemana.Aplicaciones.Servicios
{
    public interface ISucursalServicio
    {
        Task<SucursalesDTO> AgregarUnaSucursal(SucursalesDTO dto);
        Task<bool> ModificarSucursal(SucursalesDTO dto);
        Task<IEnumerable<SucursalesDTO>> ObtenerTodos();
        Task<SucursalesDTO> ObtenerPorId(int id);
        Task<SucursalesDTO> AgregarEmpleados(int idS, List<int> idE);
        Task<bool> EliminarSucursal(int id);
    }
}
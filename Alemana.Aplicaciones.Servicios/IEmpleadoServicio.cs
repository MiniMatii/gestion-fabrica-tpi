using Alemana.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alemana.Aplicaciones.Servicios
{
    public interface IEmpleadoServicio
    {
        Task<EmpleadoDTO> AgregarEmpleado(EmpleadoDTO unEmpDTO);
        Task<List<EmpleadoDTO>> ObtenerTodos();
        Task<EmpleadoDTO> ObtenerPorId(int id);
        Task<EmpleadoDTO> ModificarEmpleado(EmpleadoDTO unEmpDTO);
        Task<bool> BajaEmpleado(EmpleadoDTO unEmpDTO);
    }
}
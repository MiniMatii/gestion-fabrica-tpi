using Alemana.Dominio.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alemana.Data.Repositorios
{
    public interface IEmpleadoRepositorio
    {
        Task<Empleado> AltaEmpleado(Empleado empleado);
        Task<List<Empleado>> ObtenerTodos();
        Task<Empleado> ObtenerPorId(int id);
        Task<Empleado> ModificarEmpleado(Empleado empleado);
        Task<bool> BajaEmpleado(int idEmpleado, string motivo);
    }
}
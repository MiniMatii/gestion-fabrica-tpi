using Alemana.Dominio.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alemana.Data.Repositorios
{
    public interface IEmpleadoRepositorio
    {
        Task AgregarEmpleado(Empleado empleado);
        Task<List<Empleado>> ObtenerTodos();
        Task<Empleado> ObtenerPorId(int id);
        Task ModificarEmpleado(Empleado empleado);
    }
}
using Alemana.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alemana.Data.Repositorios
{
    public interface ISucursalRepositorio
    {

        Task<Sucursale> AgregarUnaSucursal(Sucursale sucursal);
        Task<bool> ModificarSucursal(Sucursale sucursal);

        Task <IEnumerable<Sucursale>> ObtenerTodos();

        Task<Sucursale> AgregarEmpleados(int idS, List<int> idE);

        //listar los empleados de una sucursal?
    }
}

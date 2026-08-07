using Alemana.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alemana.Data.Repositorios
{
    public interface IProveedoresRepositorio
    {
        Task<Proveedore> AgregarProveedor(Proveedore unProveedor);
        Task<List<Proveedore>> ObtenerTodos();
        Task<Proveedore> ObtenerPorId(int id);
        Task ModificarProveedor(Proveedore proveedor);

    }
}

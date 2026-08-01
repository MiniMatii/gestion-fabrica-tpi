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
        Task<bool> AgregarProveedor(Proveedore unProveedor);
        //Task<bool> BajaProveedor(int id);



    }
}

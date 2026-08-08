using Alemana.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alemana.Data.Repositorios
{
    public interface ICiudadesRespositorio
    {
        Task<Ciudade> AltaCiudad(Ciudade unaCiudad);
        // Task<List<int>> AgregarSucursal(int idCiudad, List<int> idSucursal);  //por qué devuelvo lista de id?
        Task<List<Sucursale>> AgregarSucursal(int idCiudad, List<int> idSucursal);
        Task<Ciudade> GetCiudad(int idC);

        //baja ciudad ?
    }
}

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
        Task<List<int>> AgregarSucursal(int idCiudad, List<int> idSucursal);

        //baja ciudad ?
    }
}

using Alemana.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alemana.DTOs;

namespace Alemana.Aplicaciones.Servicios
{
    public interface ICiudadServicio
    {
        Task<CiudadesDTO> AltaCiudad(CiudadesDTO nuevaCiudad);
        //Task<CiudadesDTO> AgregarSucursal(int idCiudad, List<int> idSucursal); 

        Task<CiudadesDTO> BuscarCiudad(int idC);

        Task<List<CiudadesDTO>> BuscarTodas();
    }
}

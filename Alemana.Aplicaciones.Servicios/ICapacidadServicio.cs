using Alemana.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alemana.DTOs;


namespace Alemana.Aplicaciones.Servicios
{
    public interface ICapacidadServicio
    {

        Task<CapacidadDTO> AltaCapacidad(CapacidadDTO unaCapa);
        Task<bool> BorrarCapacidad(int idCap);
    }
}

using Alemana.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alemana.Aplicaciones.Servicios
{
    public interface ISucursalServicio
    {

        Task<SucursalesDTO> AgregarUnaSucursal(SucursalesDTO dto);

    }
}

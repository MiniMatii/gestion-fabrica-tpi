using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alemana.DTOs
{
    public class SucursalesDTO
    {
      
            public int IdSucursal { get; set; }

            public string NombreSuc { get; set; } = null!;

            public int CodPostal { get; set; }

            public virtual ICollection<EmpleadoDTO> Empleados { get; set; } = new List<EmpleadoDTO>();
        }
    
}

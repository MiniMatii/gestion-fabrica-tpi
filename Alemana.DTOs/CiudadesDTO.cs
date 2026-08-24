using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alemana.DTOs
{
    public class CiudadesDTO
    {
        public int CodPostal { get; set; }

        public string NombreCiudad { get; set; } = null!;

        public virtual ICollection<SucursalesDTO> Sucursales { get; set; } = new List<SucursalesDTO>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alemana.DTOs
{
    public class OperariosDTO
    {
        public int IdOperario { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public sbyte Disponibilidad { get; set; }
        
        public List<CapacidadDTO> IdCaps { get; set; } = new List<CapacidadDTO>();
    }
}

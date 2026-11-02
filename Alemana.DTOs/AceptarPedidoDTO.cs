using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alemana.DTOs
{
    public class AceptarPedidoDTO
    {
        public List<AsignacionItemDTO> Asignaciones { get; set; } = new List<AsignacionItemDTO>();
    }
}

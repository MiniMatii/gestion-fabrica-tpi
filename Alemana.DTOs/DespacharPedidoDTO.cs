using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alemana.DTOs
{
    public class DespacharPedidoDTO
    {
        public int IdEmpleado { get; set; }
        public List<DespachoItemDTO> Items { get; set; } = new();
    }
}

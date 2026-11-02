using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alemana.DTOs
{
    public class ProduccionPedidoDTO
    {
        public int IdPedido { get; set; }
        public DateTime? FechaPedido { get; set; }
        public DateTime? FechaEstimada { get; set; }
        public List<OrdenProduccionDTO> Ordenes { get; set; } = new();

    }
}

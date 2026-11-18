using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alemana.DTOs
{
    public class ResultadoPedidoDTO
    {
        public int IdPedido { get; set; }
        public string EstadoPedido { get; set; } = "";
        public List<ItemPedidoDespachoDTO> Items { get; set; } = new();
    }
}

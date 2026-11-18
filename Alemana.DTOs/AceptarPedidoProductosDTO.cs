using System.Collections.Generic;

namespace Alemana.DTOs
{
    public class AceptarPedidoProductosDTO
    {
        public List<AceptacionItemDTO> Items { get; set; } = new List<AceptacionItemDTO>();
    }
}

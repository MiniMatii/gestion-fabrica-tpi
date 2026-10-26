

namespace Alemana.DTOs
{
    public class PedidoResumenDTO
    {
        public int IdPedido { get; set; }
        public DateTime FechaPedido { get; set; }

    }

    public class PedidoDetalleDTO
    {
        public int Id { get; set; }
        public DateTime FechaIngreso { get; set; }
        public System.Collections.Generic.List<PedidoItemDTO> Items { get; set; }
            = new System.Collections.Generic.List<PedidoItemDTO>();
    }

    public class PedidoItemDTO
    {
        public string Producto { get; set; }
        public int Cantidad { get; set; }
    }


}

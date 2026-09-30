namespace Alemana.DTOs
{
    public class SolicitudPedidoDTO
    {
        public int IdPedido { get; set; }
        public DateTime FechaPedido { get; set; }
        public string EstadoPedido { get; set; } = null!;
        public DateTime? FechaEstimada { get; set; }
        public DateTime? FechaReal { get; set; }
        public int IdEmpleado { get; set; }

        public List<DetallePedidoDTO> DetallePedidos { get; set; } = new List<DetallePedidoDTO>();
    }
}
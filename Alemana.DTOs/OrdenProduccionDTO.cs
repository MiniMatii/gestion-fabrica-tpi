using System;

namespace Alemana.DTOs
{
    public class OrdenProduccionDTO
    {
        public int IdProd { get; set; }
        public DateTime FechaPedido { get; set; }
        public string EstadoPedido { get; set; }
        public DateTime? FechaEstimada { get; set; }
        public DateTime? FechaReal { get; set; }
        public int CantidadRequerida { get; set; }
        public int IdProducto { get; set; }
        public int? IdPedido { get; set; }
        public string? NombreProducto { get; set; }
        public int? IdOperario { get; set; }
        public string? NombreOperario { get; set; }
    }
}
using System.Collections.Generic;

namespace Alemana.DTOs
{
    public class ResultadoAceptacionPedidoDTO
    {
        public int IdPedido { get; set; }
        public string EstadoPedido { get; set; } = string.Empty;

        /// <summary>Productos aceptados que no alcanzó el stock y deben generar una producción.</summary>
        public List<ProductoPendienteProduccionDTO> PendientesProduccion { get; set; } = new List<ProductoPendienteProduccionDTO>();
    }
}

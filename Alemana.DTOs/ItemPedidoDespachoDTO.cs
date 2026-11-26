using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alemana.DTOs
{
    public class ItemPedidoDespachoDTO
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; } = "";
        public int CantidadSolicitada { get; set; }
        public int CantidadAceptada { get; set; }
        public int CantidadDespachada { get; set; }
        public int PendienteDespachar => CantidadAceptada - CantidadDespachada;
        public int PendienteAceptar => CantidadSolicitada - CantidadAceptada;
        public int StockDisponible { get; set; }
        /// <summary>Unidades que salen cada vez que se hace la receta del producto.</summary>
        public int Rinde { get; set; }
    }
}

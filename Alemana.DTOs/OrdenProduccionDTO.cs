using System;

namespace Alemana.DTOs
{
    public class OrdenProduccionDTO
    {
        public int IdProd { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string EstadoOrden { get; set; }
        public DateTime? FechaEstimada { get; set; }
        public DateTime? FechaReal { get; set; }
        /// <summary>Veces que se hace la receta. Las unidades que entran al stock son CantidadAproducir * Rinde.</summary>
        public int CantidadAproducir { get; set; }
        /// <summary>Unidades que salen cada vez que se hace la receta (solo lectura, lo completa la API).</summary>
        public int Rinde { get; set; }
        public int UnidadesAProducir => CantidadAproducir * Rinde;
        public int IdProducto { get; set; }

        public string? NombreProducto { get; set; }
        public int? IdOperario { get; set; }
        public string? NombreOperario { get; set; }




    }
}
using System;
namespace Alemana.DTOs
{
    public class ProductoPendienteProduccionDTO
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; } = string.Empty;
        /// <summary>Unidades que faltan.</summary>
        public int CantidadAProducir { get; set; }
        /// <summary>Unidades que salen cada vez que se hace la receta.</summary>
        public int Rinde { get; set; }
        /// <summary>Veces que hay que hacer la receta para cubrir lo que falta.</summary>
        public int Tandas => (int)Math.Ceiling(CantidadAProducir / (double)Math.Max(Rinde, 1));
    }
}

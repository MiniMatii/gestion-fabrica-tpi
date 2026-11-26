using System.Collections.Generic;

namespace Alemana.DTOs
{
    public class CalculoProduccionDTO
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; } = string.Empty;
        /// <summary>Veces que se hará la receta.</summary>
        public int Cantidad { get; set; }
        /// <summary>Unidades que salen cada vez que se hace la receta.</summary>
        public int Rinde { get; set; }
        public int UnidadesResultantes => Cantidad * Rinde;
        public bool Suficiente { get; set; }
        public List<MateriaPrimaRequeridaDTO> MateriasPrimas { get; set; } = new List<MateriaPrimaRequeridaDTO>();
    }
}

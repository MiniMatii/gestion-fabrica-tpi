using System.Collections.Generic;

namespace Alemana.DTOs
{
    public class CalculoProduccionDTO
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public bool Suficiente { get; set; }
        public List<MateriaPrimaRequeridaDTO> MateriasPrimas { get; set; } = new List<MateriaPrimaRequeridaDTO>();
    }
}

namespace Alemana.DTOs
{
    public class MateriaPrimaRequeridaDTO
    {
        public int IdMateriaP { get; set; }
        public string NombreMateriaP { get; set; } = string.Empty;
        public string Unidad { get; set; } = string.Empty;
        public decimal CantidadNecesaria { get; set; }
        public decimal StockDisponible { get; set; }
        public bool Suficiente { get; set; }
    }
}

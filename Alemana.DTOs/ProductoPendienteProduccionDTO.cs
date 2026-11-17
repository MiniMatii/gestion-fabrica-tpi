namespace Alemana.DTOs
{
    public class ProductoPendienteProduccionDTO
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; } = string.Empty;
        public int CantidadAProducir { get; set; }
    }
}

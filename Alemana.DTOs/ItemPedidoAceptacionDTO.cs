namespace Alemana.DTOs
{
    public class ItemPedidoAceptacionDTO
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; } = string.Empty;
        public int CantidadPedida { get; set; }
        public int StockDisponible { get; set; }
    }
}

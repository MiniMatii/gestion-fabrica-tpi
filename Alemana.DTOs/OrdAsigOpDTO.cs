namespace Alemana.DTOs
{
    public class OrdAsigOpDTO
    {
        public int IdProd { get; set; } 
        public int IdOperario { get; set; }
        public int Cantidades { get; set; }
        public DateTime FechaIni { get; set; }
        public DateTime? FechaFin { get; set; }
    }
}

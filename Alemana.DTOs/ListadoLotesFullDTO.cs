using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alemana.DTOs
{
    public class ListadoLotesFullDTO
    {
        public int IdLote { get; set; }
        public string NombreProveedor { get; set; }
        public string NombreMateriaPrima { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public sbyte? EstadoLote { get; set; }
        public decimal CantidadLote { get; set; }
    }
}

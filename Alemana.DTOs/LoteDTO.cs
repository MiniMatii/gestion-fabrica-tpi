using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alemana.DTOs
{
    public class LoteDTO
    {
        public int IdLote { get; set; }

        public DateTime FechaIngreso { get; set; }

        public DateTime FechaVencimiento { get; set; }

        public decimal CantidadLote { get; set; }

        public int IdProveedor { get; set; }

        public int IdMateriaP { get; set; }

        public sbyte? EstadoLote { get; set; }


    }
}

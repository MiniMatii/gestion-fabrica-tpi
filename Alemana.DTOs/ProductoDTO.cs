using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alemana.DTOs
{
    public class ProductoDTO
    {

        public int IdProducto { get; set; }

        public string Nombre { get; set; } = null!;

        public bool Camara { get; set; }

        public bool? Disponible { get; set; }

        public int IdReceta { get; set; }

        public int StockActual { get; set; }
        //faltan las colecciones que no sé si van 

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alemana.DTOs
{
    public class ItemAsignableDTO           
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public List<OperarioOpcionDTO> Operarios { get; set; } = new List<OperarioOpcionDTO>();
    }
}

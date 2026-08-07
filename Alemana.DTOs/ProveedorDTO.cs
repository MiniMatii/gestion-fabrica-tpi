using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alemana.DTOs
{
    public class ProveedorDTO
    {
        public int IdProveedor { get; set; }

        public string RazonSocial { get; set; } = null!;

        public string Cuit { get; set; } = null!;

        public string Nombre { get; set; } = null!;
    }
}

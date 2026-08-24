using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alemana.DTOs
{
    public class EmpleadoDTO
    {
        public int IdEmpleado { get; set; }

        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public string Dni { get; set; } = null!;

        public int IdSucursal { get; set; }

        public int? IdJefe { get; set; }

        public bool Disponibilidad { get; set; }

        public string? Motivo { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alemana.Dominio.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; } = null!;
        public string ClaveHash { get; set; } = null!;

        public int? IdEmpleado { get; set; }
        public Empleado? Empleado { get; set; }

        public int? IdOperario { get; set; }
        public Operario? Operario { get; set; }
    }
}

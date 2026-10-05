using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alemana.DTOs
{
    public class LoginDTO
    {
        public string Usuario { get; set; }= "";
        public string Clave { get; set; }=  "" ;


        public int? IdEmpleado { get; set; }
        public int? IdOperario { get; set; }
    }
}

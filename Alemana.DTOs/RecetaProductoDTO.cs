using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alemana.DTOs
{
    public class RecetaProductoDTO
    {
        public int IdReceta { get; set; }

        public string Descripcion { get; set; } = null!;

        public virtual ICollection<MateriapRecetaDTO> MateriapReceta { get; set; } = new List<MateriapRecetaDTO>(); //tengo dudas sobre esto
         
       
    }
}

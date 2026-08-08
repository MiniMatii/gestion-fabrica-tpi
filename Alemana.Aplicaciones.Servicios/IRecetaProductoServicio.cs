using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alemana.DTOs;

namespace Alemana.Aplicaciones.Servicios
{
    internal interface IRecetaProductoServicio
    {
        Task<RecetaProductoDTO> AltaReceta(RecetaProductoDTO nuevaRdto)
        { 
        }
    }
}

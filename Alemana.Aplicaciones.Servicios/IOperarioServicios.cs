using Alemana.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alemana.DTOs;

namespace Alemana.Aplicaciones.Servicios
{
    public interface IOperarioServicios
    {
        Task<OperariosDTO> AltaOperario(OperariosDTO unOperario);
        Task<bool> BajaOperario(int idOperario);
        Task<OperariosDTO> ModificarOperario(int idOperario);
        Task<OperariosDTO> AsignarCapacidad(int idOperario, List<int> caps);
        
    }
}

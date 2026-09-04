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
        Task<bool> ModificarOperario(OperariosDTO unOperario);
        Task<OperariosDTO> AsignarCapacidad(int idOperario, List<int> caps);
        Task<IEnumerable<OperariosDTO>> ObtenerTodos();
        Task<List<CapacidadDTO>> EncontrarCapacidades(List<int> idCapacidades);
        Task<bool> EliminarOperario(int idOperario);
        Task<OperariosDTO> EliminarCapacidadOperario(int idOperario, int idCapacidad);


    }
}

using Alemana.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alemana.DTOs;

namespace Alemana.Aplicaciones.Servicios
{
    public interface ILoteServicio
    {

        Task<LoteDTO> AgregarLote(LoteDTO unLoteDTO);
        Task<LoteDTO> BajaLote(int id);
        Task<bool> EliminarLote(int id);
        Task<List<LoteDTO>> ObtenerTodos();
    }
}

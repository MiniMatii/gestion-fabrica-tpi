using Alemana.Dominio.Models;
using Alemana.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alemana.Aplicaciones.Servicios
{
    public interface IRecetaProductoServicio
    {
        Task<RecetaProductoDTO> AltaReceta(RecetaProductoDTO nuevaR);
        Task<RecetaProductoDTO> ModificarReceta(RecetaProductoDTO recetaM);
        Task<bool> EliminarReceta(int idRecta);

        Task<bool> AgregarMateriaPrima(int idR, List<MateriapRecetaDTO> masmps);
        Task<List<RecetaProductoDTO>> ObtenerTodos();
        Task<RecetaProductoDTO> ObtenerPorId(int id);


    }
}

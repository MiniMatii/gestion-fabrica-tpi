using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alemana.Dominio.Models;

namespace Alemana.Data.Repositorios
{
    public interface IRecetaProductoRepositorio
    {
        Task AltaReceta(Recetaproducto nuevaR); 
        Task<Recetaproducto> ModificarReceta(Recetaproducto recetaM);
        Task<bool> EliminarReceta(int idRecta);
        Task<Recetaproducto?> GetRecetaproducto(int idReceta);
        Task AgregarMateriaPrima(Recetaproducto recetaM); 
        Task<List<Recetaproducto>> ObtenerTodos();

    }
}

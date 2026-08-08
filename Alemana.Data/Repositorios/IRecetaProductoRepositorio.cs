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
        Task<Recetaproducto> AltaReceta(Recetaproducto nuevaR);
        Task<Recetaproducto> ModificarReceta(Recetaproducto recetaM);
        Task<bool> EliminarReceta(int idRecta);
        
        //Task<> AgregarMateriaPrima();
    }
}

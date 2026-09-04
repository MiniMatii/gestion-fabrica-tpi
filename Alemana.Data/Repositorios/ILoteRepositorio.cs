using Alemana.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alemana.Data.Repositorios
{
    public interface ILoteRepositorio
    {
        Task<Lote> AgregarLote(Lote unLote);
        Task<Lote> BajaLote(int id);
        Task<bool> EliminarLote(int id);
        Task<List<Lote>> ObtenerTodos();
        Task<Lote> ObtenerPorId(int id);
    }
}

using Alemana.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alemana.Data.Repositorios
{
    public interface IOperarioRepositorio
    {
        Task<Operario> AltaOperario(Operario unOpe);
        Task<bool> BajaOperario(int id);
        Task<List<int>> AsignarCapacidad(int idOpe, List<int> idCap);
        Task<Operario> ModificarOperario(Operario unOperario);
        //Task<Operario> CambiarCapacidades(int idOperario);

        Task<List<Capacidad>> EncontrarCapacidades(List<int> iCapacidades);

        Task<IEnumerable<Operario>> ObtenerTodos();
        Task<List<Capacidad>> ObtenerCapacidadesAsignadas(int idOp);

        Task<Operario> ObtenerOperarioPorId(int idOperario);
        Task GuardarCambios();
        Task<bool> EliminarOperario(int idOperario);
    }
}

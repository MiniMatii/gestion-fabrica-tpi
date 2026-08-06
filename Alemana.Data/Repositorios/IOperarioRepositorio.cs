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
        Task<Operario> ModificarOperario(int idOpe);
        //Task<Operario> CambiarCapacidades(int idOperario);

        Task GuardarCambios();
    }
}

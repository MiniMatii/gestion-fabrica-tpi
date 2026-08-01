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
        Task<bool> AltaOperario(Operario unOpe);
        Task<bool> BajaOperario(int id);
        Task<bool> AsignarCapacidad(int idOpe, int idCap);


    }
}

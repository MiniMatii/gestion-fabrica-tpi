using Alemana.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alemana.Data.Repositorios
{
    public interface ICapacidadesRepositorio
    {

        Task<bool> AltaCapacidad(Capacidad unaCapa);


    }
}

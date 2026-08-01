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
        Task<bool> AgregarLote(Lote unLote);
        Task<bool> BajaLote(int id);

    }
}

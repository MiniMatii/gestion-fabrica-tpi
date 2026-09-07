using Alemana.Data.Repositorios;
using Alemana.Dominio.Models;
using Alemana.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alemana.Aplicaciones.Servicios
{
    public class CapacidadServicio : ICapacidadServicio
    {

        private readonly ICapacidadesRepositorio capacidadesRepositorio;

        public CapacidadServicio(ICapacidadesRepositorio capRepo)
        {
            capacidadesRepositorio = capRepo;
        }


        public async Task<CapacidadDTO> AltaCapacidad(CapacidadDTO unaCap)
        {
            var capacidad = new Capacidad();
            capacidad.DescCapacidad = unaCap.DescCapacidad;
            capacidad.NomCapacidad = unaCap.NomCapacidad;

            await capacidadesRepositorio.AltaCapacidad(capacidad);


            unaCap.IdCap = capacidad.IdCap;

            return unaCap;
        }


        public async Task<bool> BorrarCapacidad(int idCap)
        {
            return await capacidadesRepositorio.BorrarCapacidad(idCap);
        }

        public async Task<List<CapacidadDTO>> ObtenerTodos()
        {
            var capacidades = await capacidadesRepositorio.ObtentenerCapacidades();
            return capacidades.Select(c => new CapacidadDTO
            {
                IdCap = c.IdCap,
                DescCapacidad = c.DescCapacidad,
                NomCapacidad = c.NomCapacidad,
            }).ToList();


        }
    }
}

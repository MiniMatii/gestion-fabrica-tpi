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
    public class OperariosServicio : IOperarioServicios
    {

        private readonly IOperarioRepositorio operarioRepositorio;

        public OperariosServicio(IOperarioRepositorio opRepo)
        {
            operarioRepositorio = opRepo;
        }


        public async Task<OperariosDTO> AltaOperario(OperariosDTO unOperario) 
        {
            var operario = new Operario();
            operario.Nombre = unOperario.Nombre;
            operario.Apellido = unOperario.Apellido;
            operario.Disponibilidad = unOperario.Disponibilidad;
            
            await operarioRepositorio.AltaOperario(operario);

            unOperario.IdOperario = operario.IdOperario;

            return unOperario;



        }
        public async Task<bool> BajaOperario(int idOperario) 
        {
            return await operarioRepositorio.BajaOperario(idOperario);


        }
        public async Task<OperariosDTO> ModificarOperario(int idOperario)
        {
            var opE = await operarioRepositorio.ModificarOperario(idOperario);

            if (opE == null)
            {
                return null;
            }

            return new OperariosDTO
            {
                IdOperario = opE.IdOperario,
                Nombre = opE.Nombre,
                Apellido = opE.Apellido,
                Disponibilidad = opE.Disponibilidad,
                IdCaps = opE.IdCaps.Select(c => new CapacidadDTO
                {
                    IdCap = c.IdCap,
                    DescCapacidad = c.DescCapacidad,
                    NomCapacidad = c.NomCapacidad
                }).ToList()
            };
        }
        public async Task<OperariosDTO> AsignarCapacidad(int idOperario, List<int> caps) 
        {
            var opE = await operarioRepositorio.ModificarOperario(idOperario);

            if (opE == null)
            {
                return null;
            }
            var capsE = await operarioRepositorio.AsignarCapacidad(opE.IdOperario, caps);
            opE.IdCaps = capsE.Select(c => new Capacidad { IdCap = c }).ToList();

            return new OperariosDTO
            {
                IdOperario = opE.IdOperario,
                Nombre = opE.Nombre,
                Apellido = opE.Apellido,
                Disponibilidad = opE.Disponibilidad,
                IdCaps = opE.IdCaps.Select(c => new CapacidadDTO
                {
                    IdCap = c.IdCap,
                    DescCapacidad = c.DescCapacidad,
                    NomCapacidad = c.NomCapacidad
                }).ToList()
            };

        }


    }
}

using Alemana.Data.Repositorios;
using Alemana.Dominio.Models;
using Alemana.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
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

            var idsResultantes = new List<int>();
            idsResultantes = unOperario.IdCaps.Select(dto => dto.IdCap).ToList();

            operario.IdCaps = await operarioRepositorio.EncontrarCapacidades(idsResultantes);


            await operarioRepositorio.AltaOperario(operario);
            // PENDIENTE PODER DAR DE ALTA Y AGREGAR CAPACIDADES AL OPERARIO EN LA MISMA TRANSACCION
            //unOperario.IdOperario = operario.IdOperario; 
            //var caps = await AsignarCapacidad(operario.IdOperario, unOperario.IdCaps);

            return unOperario;



        }
        public async Task<bool> BajaOperario(int idOperario)
        {
            return await operarioRepositorio.BajaOperario(idOperario);


        }
        public async Task<bool> ModificarOperario(OperariosDTO unOperario)
        {
            var opEncontrado = await operarioRepositorio.ObtenerOperarioPorId(unOperario.IdOperario);

            if (opEncontrado == null)
            {
                return false;
            }

            var ope = new Operario
            {
                IdOperario = unOperario.IdOperario,
                Nombre = unOperario.Nombre,
                Apellido = unOperario.Apellido,
                Disponibilidad = unOperario.Disponibilidad,
                IdCaps = await operarioRepositorio.EncontrarCapacidades(opEncontrado.IdCaps.Select(c => c.IdCap).ToList())
            };
            await operarioRepositorio.ModificarOperario(ope);

            return true;
        }
        public async Task<List<CapacidadDTO>> EncontrarCapacidades(List<int> idCaps)
        {
            var resultado = await operarioRepositorio.EncontrarCapacidades(idCaps);

            var resultadoDTO = resultado
                .Select(c => new CapacidadDTO
                {
                    IdCap = c.IdCap,
                    DescCapacidad = c.DescCapacidad,
                    NomCapacidad = c.NomCapacidad
                })
                .ToList();

            return resultadoDTO;
        }
        public async Task<OperariosDTO> AsignarCapacidad(int idOperario, List<int> caps)
        {
            var opE = await operarioRepositorio.ObtenerOperarioPorId(idOperario);

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
                    NomCapacidad = c.NomCapacidad,
                    DescCapacidad = c.DescCapacidad
                }).ToList()
            };

        }
        public async Task<IEnumerable<OperariosDTO>> ObtenerTodos()
        {
            var operarios = await operarioRepositorio.ObtenerTodos();

            var lista = new List<OperariosDTO>();

            foreach (var op in operarios)
            {
                var caps = await operarioRepositorio.ObtenerCapacidadesAsignadas(op.IdOperario);

                lista.Add(new OperariosDTO
                {
                    IdOperario = op.IdOperario,
                    Nombre = op.Nombre,
                    Apellido = op.Apellido,
                    Disponibilidad = op.Disponibilidad,
                    IdCaps = caps.Select(c => new CapacidadDTO
                    {
                        IdCap = c.IdCap,
                        NomCapacidad = c.NomCapacidad,
                        DescCapacidad = c.DescCapacidad
                    }).ToList()
                });
            }

            return lista;
        }
        public async Task<bool> EliminarOperario(int idOperario) 
        {
            var opEncontrado = await operarioRepositorio.ObtenerOperarioPorId(idOperario);
            if (opEncontrado == null)
            {
                return false;
            }
            return await operarioRepositorio.EliminarOperario(idOperario);
        }

        public async Task<OperariosDTO> EliminarCapacidadOperario(int idOperario, int idCapacidad)
        {
            var opE = await operarioRepositorio.ObtenerOperarioPorId(idOperario);
            if (opE == null)
            {
                return null;
            }
            var opActualizado = await operarioRepositorio.EliminarCapacidadOperario(idOperario, idCapacidad);
            return new OperariosDTO
            {
                IdOperario = opActualizado.IdOperario,
                Nombre = opActualizado.Nombre,
                Apellido = opActualizado.Apellido,
                Disponibilidad = opActualizado.Disponibilidad,
                IdCaps = opActualizado.IdCaps.Select(c => new CapacidadDTO
                {
                    IdCap = c.IdCap,
                    NomCapacidad = c.NomCapacidad,
                    DescCapacidad = c.DescCapacidad
                }).ToList()
            };
        }
    }
}

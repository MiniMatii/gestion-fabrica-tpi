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
    public class SucursalServicio : ISucursalServicio
    {
        private readonly ISucursalRepositorio sucursalRepositorio;

        public SucursalServicio(ISucursalRepositorio sucuRepo)
        {
            sucursalRepositorio = sucuRepo;
        }


        public async Task<SucursalesDTO> AgregarUnaSucursal(SucursalesDTO dto) 
        {
            var sucE = new Sucursale
            {
                NombreSuc = dto.NombreSuc,
                CodPostal = dto.CodPostal
            };

            var sucRta = await sucursalRepositorio.AgregarUnaSucursal(sucE);

            dto.IdSucursal = sucRta.IdSucursal;

            return dto;
        }

        public async Task<bool> ModificarSucursal(SucursalesDTO dto)
        {
            if (dto is null)
            {
                throw new ArgumentNullException(nameof(dto));
            }
            var S = new Sucursale {NombreSuc = dto.NombreSuc,CodPostal = dto.CodPostal};
            return await sucursalRepositorio.ModificarSucursal(S);
        }

        public async Task<SucursalesDTO> ObtenerPorId(int id)
        {
            var s = await sucursalRepositorio.ObtenerPorId(id);

            if (s == null) return null;

            return new SucursalesDTO
            {
                IdSucursal = s.IdSucursal,
                NombreSuc = s.NombreSuc,
                CodPostal = s.CodPostal,
                Empleados = s.Empleados != null
                    ? s.Empleados.Select(e => new EmpleadoDTO
                    {
                        IdEmpleado = e.IdEmpleado,
                        Nombre = e.Nombre,
                        Apellido = e.Apellido
                    }).ToList()
                    : new List<EmpleadoDTO>()
            };
        }

        public async Task<IEnumerable<SucursalesDTO>> ObtenerTodos()
        {
            var sucursales= await sucursalRepositorio.ObtenerTodos();
            return sucursales.Select(s => new SucursalesDTO
            {   
                IdSucursal= s.IdSucursal,
                NombreSuc= s.NombreSuc,
                CodPostal= s.CodPostal
            }).ToList();
        }
    
        public async Task<SucursalesDTO> AgregarEmpleados(int idS, List<int> idE)
        {
            //si vuelve null del repo es pq no lo encontró
            var sucuActualizada = await sucursalRepositorio.AgregarEmpleados(idS, idE);
            if (sucuActualizada is not null)
            {
            
                return new SucursalesDTO
                {
                    IdSucursal = sucuActualizada.IdSucursal,
                    NombreSuc = sucuActualizada.NombreSuc,
                    CodPostal = sucuActualizada.CodPostal,
                    Empleados = sucuActualizada.Empleados.Select(e => new EmpleadoDTO 
                    { IdEmpleado = e.IdEmpleado, 
                      Nombre= e.Nombre,
                      Apellido = e.Apellido   //no le paso todos los datos de empleado
                    }).ToList()
                };

            }
            return null;
        }
    }
}

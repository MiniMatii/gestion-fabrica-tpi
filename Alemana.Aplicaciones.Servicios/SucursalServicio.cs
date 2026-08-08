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


    }
}

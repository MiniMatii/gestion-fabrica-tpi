using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alemana.Data.Repositorios;
using Alemana.Dominio.Models;
using Alemana.DTOs;
namespace Alemana.Aplicaciones.Servicios
{
    public class CiudadServicio : ICiudadServicio
    {
        private readonly ICiudadesRespositorio ciudadRepositorio;

        public CiudadServicio(ICiudadesRespositorio ciudadRep)
        {
            this.ciudadRepositorio = ciudadRep;
        }

        public async Task<CiudadesDTO> AltaCiudad(CiudadesDTO nuevaCiudad)
        {
            var nCiudad = new Ciudade();
            nCiudad.NombreCiudad = nuevaCiudad.NombreCiudad;
            nCiudad.CodPostal = nuevaCiudad.CodPostal;
            //las sucursales se cargan ni bien se da de alta una ciudad? En der minimo 1 sucursal

            await ciudadRepositorio.AltaCiudad(nCiudad);
            return nuevaCiudad;
        }

        public async Task<CiudadesDTO> AgregarSucursal(int idC, List<int> idS)
        {
            var ciudad = await ciudadRepositorio.GetCiudad(idC);

            if(ciudad is null)
            {
                return null;
            }

            var lasSuc = await ciudadRepositorio.AgregarSucursal(idC, idS);

            return new CiudadesDTO
            {
                NombreCiudad = ciudad.NombreCiudad,
                CodPostal= ciudad.CodPostal,
                Sucursales = lasSuc.Select(s => new SucursalesDTO
                {
                    IdSucursal = s.IdSucursal,
                    NombreSuc = s.NombreSuc,
                    CodPostal = s.CodPostal

                }).ToList()

            };
        }

    }
}


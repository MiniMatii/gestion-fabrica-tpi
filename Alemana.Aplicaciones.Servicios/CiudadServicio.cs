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

            await ciudadRepositorio.AltaCiudad(nCiudad);
            return nuevaCiudad;
        }

        public async Task<CiudadesDTO> BuscarCiudad(int id) 
        {
            var laC = await ciudadRepositorio.BuscarCiudad(id);
            if(laC is not null)
            {
                return new CiudadesDTO {CodPostal= laC.CodPostal,
                NombreCiudad= laC.NombreCiudad
                };
            }
            return null;
        }

        public async Task<List<CiudadesDTO>> BuscarTodas()
        {
            var lasC = await ciudadRepositorio.BuscarTodas();

            return lasC.Select(c=> new CiudadesDTO 
            {
               CodPostal= c.CodPostal,
               NombreCiudad= c.NombreCiudad
            }).ToList();
        }
    }
}


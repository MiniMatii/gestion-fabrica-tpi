using Alemana.Data.Repositorios;
using Alemana.Dominio.Models;
using Alemana.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Alemana.Aplicaciones.Servicios
{
    public class LoteServicio : ILoteServicio
    {
        private readonly ILoteRepositorio loteRepositorio;

        public LoteServicio(ILoteRepositorio loteRepo)
        {
            loteRepositorio = loteRepo;
        }

        public async Task<LoteDTO> AgregarLote(LoteDTO unLoteDTO) 
        {
            var fechaIngreso = DateTime.Now;
            Lote nLote = new Lote
            {
                
                FechaIngreso = fechaIngreso,
                FechaVencimiento = unLoteDTO.FechaVencimiento,
                CantidadLote = unLoteDTO.CantidadLote,
                IdProveedor = unLoteDTO.IdProveedor,
                IdMateriaP = unLoteDTO.IdMateriaP,
                EstadoLote = 1
            };

            await loteRepositorio.AgregarLote(nLote);

            unLoteDTO.IdLote = nLote.IdLote;


            return unLoteDTO;
        }

        //public async Task<bool> BajaLote(int codLote) 
        //{
        //    return await true;
        //}

    }
}

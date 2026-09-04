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

        public async Task<LoteDTO> BajaLote(int codLote)
        {
            var loteE = await loteRepositorio.BajaLote(codLote);

            if (loteE == null)
            {
                return null;
            }

            var loteEDTO = new LoteDTO();
            loteEDTO.IdLote = loteE.IdLote;
            loteEDTO.IdProveedor = loteE.IdProveedor;
            loteEDTO.IdMateriaP = loteE.IdMateriaP;
            loteEDTO.EstadoLote = loteE.EstadoLote;

            return loteEDTO;
        }

        public async Task<bool> EliminarLote(int codLote)
        {
            var result = await loteRepositorio.EliminarLote(codLote);

            if (result)
            {
                return result;
            }

            return result;
        }


        public async Task<List<LoteDTO>> ObtenerTodos()
        {
            var lotes = await loteRepositorio.ObtenerTodos();

            // Transformamos la lista de entidades a una lista de DTOs
            return lotes.Select(l => new LoteDTO
            {
                IdLote = l.IdLote,
                FechaIngreso = l.FechaIngreso,
                FechaVencimiento = l.FechaVencimiento,
                CantidadLote = l.CantidadLote,
                IdProveedor = l.IdProveedor,
                IdMateriaP = l.IdMateriaP,
                EstadoLote = l.EstadoLote
            }).ToList();
        }
    }
}

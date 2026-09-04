using Alemana.Data.Repositorios;
using Alemana.Dominio.Models;
using Alemana.DTOs;
using System.Collections.Generic;

namespace Alemana.Aplicaciones.Servicios
{
    public class RecetaProductoServicio : IRecetaProductoServicio
    {
        private readonly IRecetaProductoRepositorio _recetaRepositorio;
      
      
        public RecetaProductoServicio(
            IRecetaProductoRepositorio recetaRepositorio
        )   
        {
            _recetaRepositorio = recetaRepositorio; 
           
        }

       public async Task<RecetaProductoDTO> AltaReceta(RecetaProductoDTO nuevaRdto) 
        {
            if (nuevaRdto is null)
            {
                throw new ArgumentException("La receta no puede ser null.");
            }
            var rp = new Recetaproducto();
            rp.Descripcion = nuevaRdto.Descripcion;
            rp.MateriapReceta = nuevaRdto.MateriapReceta.Select(mp => new MateriapRecetum { IdMateriaP = mp.IdMateriaP, CantidadNecesaria= mp.CantidadNecesaria}).ToList();
            await _recetaRepositorio.AltaReceta(rp);
            nuevaRdto.IdReceta = rp.IdReceta;
            return nuevaRdto;
        }
        public async Task<RecetaProductoDTO> ModificarReceta(RecetaProductoDTO recetaMdto) 
        {
            if (recetaMdto is null)
            {
                throw new ArgumentException("La receta no puede ser null.");
            }
            if (string.IsNullOrWhiteSpace(recetaMdto.Descripcion))
            {
                throw new ArgumentException("La descripción de la receta no puede estar vacía");
            }
            var recetaM = new Recetaproducto {
               IdReceta = recetaMdto.IdReceta,
              Descripcion = recetaMdto.Descripcion };

            if (await _recetaRepositorio.ModificarReceta(recetaM) is null)
            {
                return null;
            }
            else return recetaMdto;
        }

        public async Task<bool> EliminarReceta(int idReceta) 
        {
            return await _recetaRepositorio.EliminarReceta(idReceta);   

        }


        public async Task<List<RecetaProductoDTO>> ObtenerTodos()
        {
            var recetas = await _recetaRepositorio.ObtenerTodos();

            return recetas.Select(r => new RecetaProductoDTO
            {
                IdReceta = r.IdReceta,
                Descripcion = r.Descripcion,
                MateriapReceta = r.MateriapReceta?.Select(mp => new MateriapRecetaDTO
                {
                    IdMateriaP = mp.IdMateriaP,
                    CantidadNecesaria = mp.CantidadNecesaria
                }).ToList() ?? new List<MateriapRecetaDTO>()
            }).ToList();
        }

        public async Task<RecetaProductoDTO> ObtenerPorId(int id)
        {
            var r = await _recetaRepositorio.GetRecetaproducto(id);

            if (r == null) return null;

            return new RecetaProductoDTO
            {
                IdReceta = r.IdReceta,
                Descripcion = r.Descripcion,
                MateriapReceta = r.MateriapReceta?.Select(mp => new MateriapRecetaDTO
                {
                    IdMateriaP = mp.IdMateriaP,
                    CantidadNecesaria = mp.CantidadNecesaria
                }).ToList() ?? new List<MateriapRecetaDTO>()
            };
        }
        public async Task<bool> AgregarMateriaPrima(int idR, List<MateriapRecetaDTO> masmps) //no sé si es lo más óptimo que entre esto o directamente el dto de receta
        {
            var laR = await _recetaRepositorio.GetRecetaproducto(idR);
            if(laR is not null)
            {
                foreach (var mp in masmps)
                {
                    laR.MateriapReceta.Add(new MateriapRecetum
                    {
                        IdMateriaP = mp.IdMateriaP,
                        CantidadNecesaria = mp.CantidadNecesaria
                    });
                }
                await _recetaRepositorio.AgregarMateriaPrima(laR);
                return true;

            }
            return false;
        }


    }
}

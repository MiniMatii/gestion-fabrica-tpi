using Alemana.Data.Repositorios;
using Alemana.Dominio.Models;
using Alemana.DTOs;

namespace Alemana.Aplicaciones.Servicios
{
    public class RecetaProductoServicio : IRecetaProductoServicio
    {
        private readonly IRecetaProductoRepositorio _recetaRepositorio;
        private readonly IProductoRepositorio _productoRepositorio;
        private readonly IMateriaPRepositorio _materiaPRepositorio;

        public RecetaProductoServicio(
            IRecetaProductoRepositorio recetaRepositorio,
            IProductoRepositorio productoRepositorio,
            IMateriaPRepositorio materiaPRepositorio)   
        {
            _recetaRepositorio = recetaRepositorio;
            _productoRepositorio = productoRepositorio;
            _materiaPRepositorio = materiaPRepositorio;
        }

        public async Task<RecetaProductoDTO?> AltaReceta(RecetaProductoDTO dto)
        {
            var producto = await _productoRepositorio
                .GetProducto(dto.Producto.idProducto);  //tengo que hacer el getProducto en el repo de producto

            if (producto == null)
            {
                return null;
            }

            // Crear la entidad Recetaproducto
            var receta = new Recetaproducto
            {
                Descripcion = dto.Descripcion,
                Producto = producto
            };

            // Crear las relaciones con las materias primas
            foreach (var mpDTO in dto.MateriasPrimas)
            {
                var materiaPrima = await _materiaPRepositorio
                    .BuscarMateriaPrima(mpDTO.IdMateriaP);

                if (materiaPrima == null)
                {
                    return null;
                }

                receta.MateriapReceta.Add(new MateriapRecetum
                {
                    IdMateriaP = materiaPrima.IdMateriaP,
                    CantidadNecesaria = mpDTO.CantidadNecesaria
                });
            }

            // Mandar la entidad completa al repositorio
            var recetaGuardada = await _recetaRepositorio
                .AltaReceta(receta);

            // Convertir entidad → DTO
            return new RecetaProductoDTO
            {
                IdReceta = recetaGuardada.IdReceta,
                IdProducto = producto.IdProducto,
                Descripcion = recetaGuardada.Descripcion,

                MateriasPrimas = recetaGuardada.MateriapReceta
                    .Select(mp => new MateriaPrimaRecetaDTO
                    {
                        IdMateriaP = mp.IdMateriaP,
                        CantidadNecesaria = mp.CantidadNecesaria
                    })
                    .ToList()
            };
        }
    }
}

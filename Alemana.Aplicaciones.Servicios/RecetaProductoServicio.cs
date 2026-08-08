using Alemana.Data.Repositorios;
using Alemana.Dominio.Models;
using Alemana.DTOs;

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

        //public async Task<RecetaProductoDTO?> AltaReceta(RecetaProductoDTO dto)
        //{
        //    var producto = await _productoRepositorio  //tendría que poner un repo de producto(?
        //        .GetProducto(dto.Producto.IdProducto);  //tengo que definir el getProducto en el repo de producto

        //    //me mareé con la coleccíón de MateriapRecetum, no sé qué debería entrar desde el endpoint. Solo el dto de receta?
        //    }
        //}
    }
}

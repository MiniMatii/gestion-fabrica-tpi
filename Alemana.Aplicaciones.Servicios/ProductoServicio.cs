using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alemana.Data.Repositorios;
using Alemana.DTOs;
using Alemana.Dominio.Models;

namespace Alemana.Aplicaciones.Servicios
{
    public class ProductoServicio : IProductoServicio
    {
        private readonly IProductoRepositorio _productoRepositorio;

        public ProductoServicio(IProductoRepositorio productoRepositorio)
        {
            _productoRepositorio = productoRepositorio;
        }

        public async Task<ProductoDTO> AgregarProducto(ProductoDTO dto) 
        {
            var prodDTO = new Producto()
            {
                Nombre = dto.Nombre,
                Camara = dto.Camara,
                Disponible = dto.Disponible,
                IdReceta = dto.IdReceta,
                StockActual = dto.StockActual
            };

            var prod = await _productoRepositorio.AgregarProducto(prodDTO);

            dto.IdProducto = prod.IdProducto;

            return dto;
        }

        public async Task<ProductoDTO> BajaProducto(int id) 
        {
            var prod = await _productoRepositorio.BajaProducto(id);
            var prodDTO = new ProductoDTO 
            {
                IdProducto = prod.IdProducto,
                Nombre = prod.Nombre,
                Camara = prod.Camara,
                Disponible = prod.Disponible,
                IdReceta = prod.IdReceta,
                StockActual = prod.StockActual
            };

            return prodDTO;
        }

        public async Task<bool> EliminarProducto(int id) 
        {
            return await _productoRepositorio.EliminarProducto(id);
        }

        public async Task<bool> ActualizarProducto(ProductoDTO dto) 
        {
            var prodE = await _productoRepositorio.ObtenerProductoPorId(dto.IdProducto);

            if (prodE == null)
            {
                return false;
            }

            prodE.Nombre = dto.Nombre;
            prodE.Camara = dto.Camara;

            var result = await _productoRepositorio.ActualizarProducto(prodE);

            return result;

        }
    }
}

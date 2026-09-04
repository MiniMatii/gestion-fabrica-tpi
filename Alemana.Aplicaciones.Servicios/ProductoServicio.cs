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

        public async Task<List<ProductoDTO>> ObtenerTodos()
        {
            var productos = await _productoRepositorio.ObtenerTodos();

            return productos.Select(p => new ProductoDTO
            {
                IdProducto = p.IdProducto,
                Nombre = p.Nombre,
                Camara = p.Camara,
                Disponible = p.Disponible,
                IdReceta = p.IdReceta,
                StockActual = p.StockActual
            }).ToList();
        }

        public async Task<List<ProductoDTO>> ObtenerDisponibles()
        {
            var productos = await _productoRepositorio.ObtenerDisponibles();

            return productos.Select(p => new ProductoDTO
            {
                IdProducto = p.IdProducto,
                Nombre = p.Nombre,
                Camara = p.Camara,
                Disponible = p.Disponible,
                IdReceta = p.IdReceta,
                StockActual = p.StockActual
            }).ToList();
        }

        public async Task<ProductoDTO> ObtenerPorId(int id)
        {
            var prod = await _productoRepositorio.ObtenerProductoPorId(id);

            if (prod == null) return null;

            return new ProductoDTO
            {
                IdProducto = prod.IdProducto,
                Nombre = prod.Nombre,
                Camara = prod.Camara,
                Disponible = prod.Disponible,
                IdReceta = prod.IdReceta,
                StockActual = prod.StockActual
            };
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

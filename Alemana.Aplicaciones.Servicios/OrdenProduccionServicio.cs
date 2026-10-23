using Alemana.Data.Repositorios;
using Alemana.Dominio.Models;
using Alemana.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alemana.Aplicaciones.Servicios
{
    public class OrdenProduccionServicio : IOrdenProduccionServicio
    {
        private const string EstadoInicial = "Pendiente";
        private const int LongitudMaximaEstado = 50;

        private readonly IOrdenProduccionRepositorio _repo;
        private readonly IProductoRepositorio _productoRepo;
        private readonly ISolicitudPedidoRepositorio _pedidoRepo;
        private readonly IOrdAsigOpRepositorio _asignacionRepo;

        public OrdenProduccionServicio(
            IOrdenProduccionRepositorio repo,
            IProductoRepositorio productoRepo,
            ISolicitudPedidoRepositorio pedidoRepo,
            IOrdAsigOpRepositorio asignacionRepo)
        {
            _repo = repo;
            _productoRepo = productoRepo;
            _pedidoRepo = pedidoRepo;
            _asignacionRepo = asignacionRepo;
        }

        public async Task<List<OrdenProduccionDTO>> ObtenerTodas()
        {
            var lista = await _repo.ObtenerTodas();
            return lista.Select(ADto).ToList();
        }

        public async Task<OrdenProduccionDTO?> ObtenerPorId(int id)
        {
            var o = await _repo.ObtenerPorId(id);
            return o == null ? null : ADto(o);
        }

        public async Task<OrdenProduccionDTO> Agregar(OrdenProduccionDTO dto)
        {
            if (dto == null)
                throw new ArgumentException("La orden de producción no puede ser nula.");

            var fechaPedido = DateTime.Now;
            var idPedido = NormalizarIdPedido(dto.IdPedido);

            await ValidarAsync(dto.CantidadRequerida, dto.IdProducto, idPedido,
                               fechaPedido, dto.FechaEstimada, null);

            var entidad = new Ordenproduccion
            {
                FechaPedido = fechaPedido,
                EstadoPedido = EstadoInicial,
                FechaEstimada = dto.FechaEstimada,
                FechaReal = null,
                CantidadRequerida = dto.CantidadRequerida,
                IdProducto = dto.IdProducto,
                IdPedido = idPedido
            };

            var nueva = await _repo.Agregar(entidad);
            return ADto(nueva);
        }

        public async Task<bool> Actualizar(OrdenProduccionDTO dto)
        {
            if (dto == null)
                throw new ArgumentException("La orden de producción no puede ser nula.");

            var existente = await _repo.ObtenerPorId(dto.IdProd);
            if (existente == null) return false;

            if (string.IsNullOrWhiteSpace(dto.EstadoPedido))
                throw new ArgumentException("El estado de la orden es obligatorio.");

            var estado = dto.EstadoPedido.Trim();
            if (estado.Length > LongitudMaximaEstado)
                throw new ArgumentException($"El estado no puede superar los {LongitudMaximaEstado} caracteres.");

            var idPedido = NormalizarIdPedido(dto.IdPedido);

            await ValidarAsync(dto.CantidadRequerida, dto.IdProducto, idPedido,
                               existente.FechaPedido, dto.FechaEstimada, dto.FechaReal);

            var asignado = await _asignacionRepo.TotalAsignadoPorOrden(existente.IdProd);
            if (dto.CantidadRequerida < asignado)
                throw new ArgumentException(
                    $"La cantidad requerida no puede ser menor a la ya asignada a operarios ({asignado}).");

            var entidad = new Ordenproduccion
            {
                IdProd = existente.IdProd,
                FechaPedido = existente.FechaPedido,
                EstadoPedido = estado,
                FechaEstimada = dto.FechaEstimada,
                FechaReal = dto.FechaReal,
                CantidadRequerida = dto.CantidadRequerida,
                IdProducto = dto.IdProducto,
                IdPedido = idPedido
            };

            return await _repo.Actualizar(entidad);
        }

        public async Task<bool> Eliminar(int id)
        {
            var existente = await _repo.ObtenerPorId(id);
            if (existente == null) return false;

            if (await _repo.TieneDependencias(id))
                throw new InvalidOperationException(
                    "No se puede eliminar la orden: tiene consumos de lote u operarios asignados.");

            return await _repo.Eliminar(id);
        }

        private static int? NormalizarIdPedido(int? idPedido)
        {
            return idPedido is > 0 ? idPedido : null;
        }

        private async Task ValidarAsync(
            int cantidadRequerida,
            int idProducto,
            int? idPedido,
            DateTime fechaPedido,
            DateTime? fechaEstimada,
            DateTime? fechaReal)
        {
            if (cantidadRequerida <= 0)
                throw new ArgumentException("La cantidad requerida debe ser mayor a cero.");

            var producto = await _productoRepo.ObtenerProductoPorId(idProducto);
            if (producto == null)
                throw new ArgumentException($"El producto {idProducto} no existe.");

            if (idPedido.HasValue)
            {
                var pedido = await _pedidoRepo.ObtenerPorId(idPedido.Value);
                if (pedido == null)
                    throw new ArgumentException($"La solicitud de pedido {idPedido.Value} no existe.");
            }

            if (fechaEstimada.HasValue && fechaEstimada.Value.Date < fechaPedido.Date)
                throw new ArgumentException("La fecha estimada no puede ser anterior a la fecha del pedido.");

            if (fechaReal.HasValue && fechaReal.Value.Date < fechaPedido.Date)
                throw new ArgumentException("La fecha real no puede ser anterior a la fecha del pedido.");
        }

        private static OrdenProduccionDTO ADto(Ordenproduccion o)
        {
            return new OrdenProduccionDTO
            {
                IdProd = o.IdProd,
                FechaPedido = o.FechaPedido,
                EstadoPedido = o.EstadoPedido,
                FechaEstimada = o.FechaEstimada,
                FechaReal = o.FechaReal,
                CantidadRequerida = o.CantidadRequerida,
                IdProducto = o.IdProducto,
                IdPedido = o.IdPedido
            };
        }
    }
}

using Alemana.Data.Repositorios;
using Alemana.Dominio.Models;
using Alemana.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alemana.Aplicaciones.Servicios
{
    public class SolicitudPedidoServicio : ISolicitudPedidoServicio
    {
        private readonly ISolicitudPedidoRepositorio _pedidoRepositorio;

        public SolicitudPedidoServicio(ISolicitudPedidoRepositorio pedidoRepositorio)
        {
            _pedidoRepositorio = pedidoRepositorio;
        }

        public async Task<SolicitudPedidoDTO> AltaPedido(SolicitudPedidoDTO dto)
        {
            if (dto == null) throw new ArgumentException("El pedido no puede ser nulo.");

            var pedido = new Solicitudpedido
            {
                FechaPedido = DateTime.Now,
                EstadoPedido = "Pendiente",
                FechaEstimada = dto.FechaEstimada,
                IdEmpleado = dto.IdEmpleado,
                DetallePedidos = dto.DetallePedidos.Select(d => new DetallePedido
                {
                    IdProducto = d.IdProducto,
                    CantidadesProductos = d.CantidadesProductos
                }).ToList()
            };

            await _pedidoRepositorio.AltaPedido(pedido);

            dto.IdPedido = pedido.IdPedido;
            dto.EstadoPedido = pedido.EstadoPedido;
            return dto;
        }

        public async Task<List<SolicitudPedidoDTO>> ObtenerTodos()
        {
            var pedidos = await _pedidoRepositorio.ObtenerTodos();

            return pedidos.Select(p => new SolicitudPedidoDTO
            {
                IdPedido = p.IdPedido,
                FechaPedido = p.FechaPedido,
                EstadoPedido = p.EstadoPedido,
                FechaEstimada = p.FechaEstimada,
                FechaReal = p.FechaReal,
                IdEmpleado = p.IdEmpleado,
                DetallePedidos = p.DetallePedidos.Select(d => new DetallePedidoDTO
                {
                    IdProducto = d.IdProducto,
                    CantidadesProductos = d.CantidadesProductos
                }).ToList()
            }).ToList();
        }

        public async Task<SolicitudPedidoDTO> ObtenerPorId(int id)
        {
            var p = await _pedidoRepositorio.ObtenerPorId(id);
            if (p == null) return null;

            return new SolicitudPedidoDTO
            {
                IdPedido = p.IdPedido,
                FechaPedido = p.FechaPedido,
                EstadoPedido = p.EstadoPedido,
                FechaEstimada = p.FechaEstimada,
                FechaReal = p.FechaReal,
                IdEmpleado = p.IdEmpleado,
                DetallePedidos = p.DetallePedidos.Select(d => new DetallePedidoDTO
                {
                    IdProducto = d.IdProducto,
                    CantidadesProductos = d.CantidadesProductos
                }).ToList()
            };
        }

        public async Task<bool> EliminarPedido(int id)
        {
            return await _pedidoRepositorio.EliminarPedido(id);
        }
    }
}

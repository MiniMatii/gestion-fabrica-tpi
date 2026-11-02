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
        private readonly IOperarioRepositorio _operariosRepositorio;
        private readonly IOrdenProduccionRepositorio _ordenesRepositorio;

        public SolicitudPedidoServicio(ISolicitudPedidoRepositorio pedidoRepositorio, IOperarioRepositorio operariosRepositorio, IOrdenProduccionRepositorio ordenesRepositorio)
        {
            _pedidoRepositorio = pedidoRepositorio;
            _operariosRepositorio = operariosRepositorio;
            _ordenesRepositorio = ordenesRepositorio;
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
                    CantidadesProductos = d.CantidadPedida
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
                DetallePedidos = p.DetallePedidos.Select(d => new PedidoItemDTO
                {
                    IdProducto = d.IdProducto,
                    CantidadPedida = d.CantidadesProductos
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
                DetallePedidos = p.DetallePedidos.Select(d => new PedidoItemDTO
                {
                    IdProducto = d.IdProducto,
                    CantidadPedida = d.CantidadesProductos
                }).ToList()
            };
        }

        public async Task<bool> EliminarPedido(int id)
        {
            return await _pedidoRepositorio.EliminarPedido(id);
        }

        public async Task<List<PedidoItemDTO>> ObtenerProductosDePedidoAsync(int idPedido)
        {
            var detalles = await _pedidoRepositorio.ObtenerDetallePedido(idPedido);

            return detalles.Select(d => new PedidoItemDTO
            {
                IdProducto = d.IdProducto,
                NombreProducto = d.IdProductoNavigation?.Nombre ?? "(sin nombre)",
                CantidadPedida = d.CantidadesProductos
            }).ToList();
        }

        public async Task<List<PedidoResumenDTO>> ObtenerPendientesAsync()
        {
            var pedidos = await _pedidoRepositorio.ObtenerPendientes();
            return pedidos.Select(p => new PedidoResumenDTO
            {
                IdPedido = p.IdPedido,
                FechaPedido = p.FechaPedido
            }).ToList();
        }

        public async Task<List<PedidoResumenDTO>> ObtenerPendientesDesdeAsync(int ultimoId)
        {
            var pedidos = await _pedidoRepositorio.ObtenerPendientesDesde(ultimoId);
            return pedidos.Select(p => new PedidoResumenDTO
            {
                IdPedido = p.IdPedido,
                FechaPedido = p.FechaPedido
            }).ToList();
        }

        public async Task<List<ItemAsignableDTO>?> ObtenerItemsAsignablesAsync(int idPedido)
        {
            var pedido = await _pedidoRepositorio.ObtenerPorId(idPedido);
            if (pedido == null) return null;

            var detalle = await _pedidoRepositorio.ObtenerDetallePedido(idPedido);
            var items = new List<ItemAsignableDTO>();

            // secuencial a propósito: un DbContext no admite consultas en paralelo
            foreach (var d in detalle)
            {
                var capaces = await _operariosRepositorio.ObtenerCapacesAsync(d.IdProducto);

                items.Add(new ItemAsignableDTO
                {
                    IdProducto = d.IdProducto,
                    NombreProducto = d.IdProductoNavigation?.Nombre ?? "",
                    Cantidad = d.CantidadesProductos,
                    Operarios = capaces.Select(o => new OperarioOpcionDTO
                    {
                        IdOperario = o.IdOperario,
                        NombreCompleto = $"{o.Nombre} {o.Apellido}".Trim()
                    }).ToList()
                });
            }

            return items;
        }

        public async Task<(ResultadoAceptacion Resultado, string? Mensaje)> AceptarPedidoAsync(int idPedido, AceptarPedidoDTO dto)
        {
            var pedido = await _pedidoRepositorio.ObtenerPorId(idPedido);
            if (pedido == null)
                return (ResultadoAceptacion.NoExiste, null);

            if (pedido.EstadoPedido != "Pendiente")
                return (ResultadoAceptacion.NoPendiente, "El pedido ya no está pendiente.");

            var asignaciones = dto?.Asignaciones ?? new List<AsignacionItemDTO>();
            var ahora = DateTime.Now;

            foreach (var det in pedido.DetallePedidos)
            {
                var orden = new Ordenproduccion
                {
                    IdPedido = pedido.IdPedido,
                    IdProducto = det.IdProducto,
                    CantidadRequerida = det.CantidadesProductos,
                    FechaPedido = pedido.FechaPedido,
                    FechaEstimada = pedido.FechaEstimada,
                    EstadoPedido = "Sin asignar"
                };

                var idOperario = asignaciones
                    .FirstOrDefault(a => a.IdProducto == det.IdProducto)?.IdOperario;

                if (idOperario.HasValue)
                {
                    var capaces = await _operariosRepositorio.ObtenerCapacesAsync(det.IdProducto);
                    if (!capaces.Any(o => o.IdOperario == idOperario.Value))
                        return (ResultadoAceptacion.AsignacionInvalida,
                            $"El operario {idOperario.Value} no puede producir el producto {det.IdProducto}.");

                    orden.EstadoPedido = "Asignada";
                    orden.OrdAsigOps.Add(new OrdAsigOp
                    {
                        IdOperario = idOperario.Value,
                        Cantidades = det.CantidadesProductos,
                        FechaIni = ahora
                    });
                }

                _ordenesRepositorio.Agregar(orden);
            }

            pedido.EstadoPedido = "Aceptado";
            return (ResultadoAceptacion.Ok, null);
        }
    }
}

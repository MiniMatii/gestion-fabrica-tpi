using Alemana.Data.Repositorios;
using Alemana.Dominio.Models;
using Alemana.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alemana.Aplicaciones.Servicios
{
    /// <summary>
    /// Pedidos de sucursal. El responsable acepta cantidades por producto: lo que hay en stock se despacha
    /// y lo que falta queda pendiente de producción.
    /// </summary>
    public class SolicitudPedidoServicio : ISolicitudPedidoServicio
    {
        public const string EstadoPendiente = "Pendiente";
        public const string EstadoEnProduccion = "En produccion";
        public const string EstadoDespachado = "Despachado";

        private readonly IStockRepositorio _stock;
        private readonly ISolicitudPedidoRepositorio _pedidoRepositorio;

        public SolicitudPedidoServicio(ISolicitudPedidoRepositorio pedidoRepositorio, IStockRepositorio stock)
        {
            _pedidoRepositorio = pedidoRepositorio;
            _stock = stock;
        }

        public async Task<SolicitudPedidoDTO> AltaPedido(SolicitudPedidoDTO dto)
        {
            if (dto == null) throw new ArgumentException("El pedido no puede ser nulo.");

            var pedido = new Solicitudpedido
            {
                FechaPedido = DateTime.Now,
                EstadoPedido = EstadoPendiente,
                FechaEstimada = dto.FechaEstimada,
                IdEmpleado = dto.IdEmpleado,
                DetallePedidos = dto.DetallePedidos.Select(d => new DetallePedido
                {
                    IdProducto = d.IdProducto,
                    CantidadesProductos = d.CantidadPedida,
                    CantidadAceptada = 0,
                    CantidadDespachada = 0
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

        /// <summary>Productos del pedido con la cantidad pedida y el stock actual, para armar el menú de aceptación.</summary>
        public async Task<List<ItemPedidoAceptacionDTO>?> ObtenerItemsAceptacionAsync(int idPedido)
        {
            var pedido = await _pedidoRepositorio.ObtenerPorId(idPedido);
            if (pedido == null) return null;

            var detalle = await _pedidoRepositorio.ObtenerDetallePedido(idPedido);
            var items = new List<ItemPedidoAceptacionDTO>();

            foreach (var d in detalle)
            {
                var stock = await _stock.ObtenerStockProductoAsync(d.IdProducto);
                items.Add(new ItemPedidoAceptacionDTO
                {
                    IdProducto = d.IdProducto,
                    NombreProducto = d.IdProductoNavigation?.Nombre ?? "",
                    CantidadPedida = d.CantidadesProductos,
                    StockDisponible = stock
                });
            }

            return items;
        }

        /// <summary>
        /// Acepta una cantidad por producto. Lo que hay en stock se despacha; lo que falta queda
        /// pendiente de producción y se informa para que el usuario pueda generarla.
        /// </summary>
        public async Task<(ResultadoAceptarPedido Resultado, string? Mensaje, ResultadoAceptacionPedidoDTO? Datos)> AceptarPedidoAsync(int idPedido, AceptarPedidoProductosDTO dto)
        {
            var pedido = await _pedidoRepositorio.ObtenerPorId(idPedido);
            if (pedido == null)
                return (ResultadoAceptarPedido.NoExiste, null, null);

            if (pedido.EstadoPedido != EstadoPendiente)
                return (ResultadoAceptarPedido.NoPendiente, "El pedido ya fue aceptado.", null);

            // Un mismo producto puede venir repetido: se suman sus cantidades
            var aceptadas = (dto?.Items ?? new List<AceptacionItemDTO>())
                .GroupBy(i => i.IdProducto)
                .ToDictionary(g => g.Key, g => g.Sum(i => i.CantidadAceptada));

            // 1) Validar todo antes de modificar nada
            foreach (var (idProducto, cantidad) in aceptadas)
            {
                if (cantidad < 0)
                    return (ResultadoAceptarPedido.CantidadInvalida,
                        $"La cantidad aceptada del producto {idProducto} no puede ser negativa.", null);

                if (!pedido.DetallePedidos.Any(d => d.IdProducto == idProducto))
                    return (ResultadoAceptarPedido.ProductoInvalido,
                        $"El producto {idProducto} no pertenece al pedido.", null);
            }

            foreach (var d in pedido.DetallePedidos)
            {
                var aceptada = aceptadas.TryGetValue(d.IdProducto, out var v) ? v : 0;
                if (aceptada > d.CantidadesProductos)
                    return (ResultadoAceptarPedido.CantidadInvalida,
                        $"No se puede aceptar más de lo pedido del producto {d.IdProducto} ({d.CantidadesProductos}).", null);
            }

            // 2) Aplicar: lo que hay en stock se despacha, el resto queda pendiente de producción
            foreach (var d in pedido.DetallePedidos)
            {
                var aceptada = aceptadas.TryGetValue(d.IdProducto, out var v) ? v : 0;
                d.CantidadAceptada = aceptada;
                d.CantidadDespachada = await DescontarStockAsync(d.IdProducto, aceptada);
            }

            pedido.EstadoPedido = pedido.DetallePedidos.Any(d => d.CantidadAceptada > d.CantidadDespachada)
                ? EstadoEnProduccion
                : EstadoDespachado;
            if (pedido.EstadoPedido == EstadoDespachado)
                pedido.FechaReal = DateTime.Now;

            await _pedidoRepositorio.GuardarCambiosAsync();
            return (ResultadoAceptarPedido.Ok, null, await ArmarResultadoAsync(pedido));
        }

        /// <summary>Despacha lo pendiente de producción que ya haya en stock (cuando la producción terminó).</summary>
        public async Task<(ResultadoAceptarPedido Resultado, string? Mensaje, ResultadoAceptacionPedidoDTO? Datos)> DespacharPendientesAsync(int idPedido)
        {
            var pedido = await _pedidoRepositorio.ObtenerPorId(idPedido);
            if (pedido == null)
                return (ResultadoAceptarPedido.NoExiste, null, null);

            if (pedido.EstadoPedido != EstadoEnProduccion)
                return (ResultadoAceptarPedido.NoPendiente, "El pedido no tiene productos pendientes de producción.", null);

            foreach (var d in pedido.DetallePedidos.Where(d => d.CantidadAceptada > d.CantidadDespachada).ToList())
            {
                d.CantidadDespachada += await DescontarStockAsync(d.IdProducto, d.CantidadAceptada - d.CantidadDespachada);
            }

            pedido.EstadoPedido = pedido.DetallePedidos.Any(d => d.CantidadAceptada > d.CantidadDespachada)
                ? EstadoEnProduccion
                : EstadoDespachado;
            if (pedido.EstadoPedido == EstadoDespachado)
                pedido.FechaReal = DateTime.Now;

            await _pedidoRepositorio.GuardarCambiosAsync();
            return (ResultadoAceptarPedido.Ok, null, await ArmarResultadoAsync(pedido));
        }

        /// <summary>Descuenta del stock hasta lo solicitado y devuelve cuánto se pudo despachar.</summary>
        private async Task<int> DescontarStockAsync(int idProducto, int solicitado)
        {
            if (solicitado <= 0) return 0;

            var producto = await _stock.ObtenerProductoAsync(idProducto);
            if (producto == null) return 0;

            int enStock = Math.Max((int?)producto.StockActual ?? 0, 0);
            int despachado = Math.Min(enStock, solicitado);

            if (despachado > 0)
                producto.StockActual = enStock - despachado;

            return despachado;
        }

        /// <summary>Lista de productos que todavía necesitan producción.</summary>
        private async Task<ResultadoAceptacionPedidoDTO> ArmarResultadoAsync(Solicitudpedido pedido)
        {
            var resultado = new ResultadoAceptacionPedidoDTO
            {
                IdPedido = pedido.IdPedido,
                EstadoPedido = pedido.EstadoPedido
            };

            foreach (var d in pedido.DetallePedidos.Where(d => d.CantidadAceptada > d.CantidadDespachada))
            {
                var producto = await _stock.ObtenerProductoAsync(d.IdProducto);
                resultado.PendientesProduccion.Add(new ProductoPendienteProduccionDTO
                {
                    IdProducto = d.IdProducto,
                    NombreProducto = producto?.Nombre ?? "",
                    CantidadAProducir = d.CantidadAceptada - d.CantidadDespachada
                });
            }

            return resultado;
        }
    }
}

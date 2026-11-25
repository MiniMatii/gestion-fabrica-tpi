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
        public const string EstadoAceptado = "Aceptado";
        public const string EstadoParcial = "Parcial";
        public const string EstadoCompletado = "Completado";

        private readonly IStockRepositorio _stock;
        private readonly ISolicitudPedidoRepositorio _pedidoRepositorio;

        public SolicitudPedidoServicio(ISolicitudPedidoRepositorio pedidoRepositorio, IStockRepositorio stock)
        {
            _pedidoRepositorio = pedidoRepositorio;
            _stock = stock;
        }


        private static string CalcularEstado(Solicitudpedido p)
        {
            if (p.DetallePedidos.All(d => d.CantidadDespachada >= d.CantidadSolicitada)) return EstadoCompletado;
            if (p.DetallePedidos.Any(d => d.CantidadDespachada > 0)) return EstadoParcial;
            if (p.DetallePedidos.Any(d => d.CantidadAceptada > 0)) return EstadoAceptado;
            return EstadoPendiente;
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
                    CantidadSolicitada = d.CantidadPedida
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
                    CantidadPedida = d.CantidadSolicitada
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
                    CantidadPedida = d.CantidadSolicitada
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
                CantidadPedida = d.CantidadSolicitada
            }).ToList();
        }

        public async Task<List<PedidoResumenDTO>> ObtenerPendientesAsync()
        {
            var pedidos = await _pedidoRepositorio.ObtenerPendientes();
            return pedidos.Select(p => new PedidoResumenDTO
            {
                IdPedido = p.IdPedido,
                FechaPedido = p.FechaPedido,
                EstadoPedido = p.EstadoPedido
            }).ToList();
        }

        public async Task<List<PedidoResumenDTO>> ObtenerPendientesDesdeAsync(int ultimoId)
        {
            var pedidos = await _pedidoRepositorio.ObtenerPendientesDesde(ultimoId);
            return pedidos.Select(p => new PedidoResumenDTO
            {
                IdPedido = p.IdPedido,
                FechaPedido = p.FechaPedido,
                EstadoPedido = p.EstadoPedido
            }).ToList();
        }


        private async Task<List<ItemPedidoDespachoDTO>> ArmarItemsAsync(Solicitudpedido pedido)
        {
            var items = new List<ItemPedidoDespachoDTO>();
            foreach (var d in pedido.DetallePedidos)
            {
                var producto = await _stock.ObtenerProductoAsync(d.IdProducto);
                items.Add(new ItemPedidoDespachoDTO
                {
                    IdProducto = d.IdProducto,
                    NombreProducto = producto?.Nombre ?? "",
                    CantidadSolicitada = d.CantidadSolicitada,
                    CantidadAceptada = d.CantidadAceptada,
                    CantidadDespachada = d.CantidadDespachada,
                    StockDisponible = producto?.StockActual ?? 0
                });
            }
            return items;
        }

        public async Task<List<ItemPedidoDespachoDTO>?> ObtenerItemsAsync(int idPedido)
        {
            var pedido = await _pedidoRepositorio.ObtenerPorId(idPedido);
            return pedido == null ? null : await ArmarItemsAsync(pedido);
        }

        private async Task<ResultadoPedidoDTO> ArmarResultadoAsync(Solicitudpedido p) =>
            new() { IdPedido = p.IdPedido, EstadoPedido = p.EstadoPedido, Items = await ArmarItemsAsync(p) };


        public async Task<(ResultadoPedido, string?, ResultadoPedidoDTO?)> AceptarAsync(int idPedido, AceptarPedidoProductosDTO dto)
        {
            var pedido = await _pedidoRepositorio.ObtenerPorId(idPedido);
            if (pedido == null) return (ResultadoPedido.NoExiste, null, null);
            if (pedido.EstadoPedido == EstadoCompletado)
                return (ResultadoPedido.YaCompletado, "El pedido ya fue despachado por completo.", null);

            var nuevas = (dto?.Items ?? new()).GroupBy(i => i.IdProducto)
                                              .ToDictionary(g => g.Key, g => g.Sum(i => i.CantidadAceptada));

            // 1) validar
            foreach (var (idProducto, total) in nuevas)
            {
                var d = pedido.DetallePedidos.FirstOrDefault(x => x.IdProducto == idProducto);
                if (d == null)
                    return (ResultadoPedido.ProductoInvalido, $"El producto {idProducto} no pertenece al pedido.", null);
                if (total < d.CantidadDespachada || total > d.CantidadSolicitada)
                    return (ResultadoPedido.CantidadInvalida,
                        $"Producto {idProducto}: la cantidad aceptada debe estar entre {d.CantidadDespachada} (ya despachado) y {d.CantidadSolicitada} (solicitado).", null);

                var stock = await _stock.ObtenerStockProductoAsync(idProducto);
                if (total - d.CantidadDespachada > stock)
                    return (ResultadoPedido.StockInsuficiente,
                        $"Producto {idProducto}: solo hay {stock} en stock para despachar.", null);
            }

            // 2) aplicar
            foreach (var (idProducto, total) in nuevas)
                pedido.DetallePedidos.First(x => x.IdProducto == idProducto).CantidadAceptada = total;

            pedido.EstadoPedido = CalcularEstado(pedido);
            await _pedidoRepositorio.GuardarCambiosAsync();
            return (ResultadoPedido.Ok, null, await ArmarResultadoAsync(pedido));
        }


        /// Envía lo aceptado: registra el Despacho, suma CantidadDespachada y descuenta stock.
        public async Task<(ResultadoPedido, string?, ResultadoPedidoDTO?)> DespacharAsync(int idPedido, DespacharPedidoDTO dto)
        {
            var pedido = await _pedidoRepositorio.ObtenerPorId(idPedido);
            if (pedido == null) return (ResultadoPedido.NoExiste, null, null);
            if (pedido.EstadoPedido == EstadoCompletado)
                return (ResultadoPedido.YaCompletado, "El pedido ya fue despachado por completo.", null);

            var lineas = (dto?.Items ?? new()).GroupBy(i => i.IdProducto)
                                              .ToDictionary(g => g.Key, g => g.Sum(i => i.Cantidad));
            if (lineas.Values.Any(c => c < 0))
                return (ResultadoPedido.CantidadInvalida, "Las cantidades no pueden ser negativas.", null);
            lineas = lineas.Where(kv => kv.Value > 0).ToDictionary(kv => kv.Key, kv => kv.Value);
            if (lineas.Count == 0)
                return (ResultadoPedido.CantidadInvalida, "Indicá al menos un producto con cantidad mayor a cero.", null);

            // 1) validar contra lo aceptado y el stock actual (el stock puede haber bajado desde la aceptación)
            var productos = new Dictionary<int, Producto>();
            foreach (var (idProducto, cantidad) in lineas)
            {
                var d = pedido.DetallePedidos.FirstOrDefault(x => x.IdProducto == idProducto);
                if (d == null)
                    return (ResultadoPedido.ProductoInvalido, $"El producto {idProducto} no pertenece al pedido.", null);

                var porDespachar = d.CantidadAceptada - d.CantidadDespachada;
                if (cantidad > porDespachar)
                    return (ResultadoPedido.CantidadInvalida,
                        $"Producto {idProducto}: solo hay {porDespachar} aceptados sin despachar.", null);

                var producto = await _stock.ObtenerProductoAsync(idProducto);
                if (producto == null || producto.StockActual < cantidad)
                    return (ResultadoPedido.StockInsuficiente,
                        $"Stock insuficiente del producto {idProducto} (hay {producto?.StockActual ?? 0}).", null);
                productos[idProducto] = producto;
            }

            // 2) aplicar (un único SaveChanges = una transacción)
            var despacho = new Despacho { FechaDespacho = DateTime.Now, IdEmpleado = dto!.IdEmpleado };
            foreach (var (idProducto, cantidad) in lineas)
            {
                // Cada línea del despacho apunta a la orden de producción de la que sale (FIFO por fechaReal);
                // el producto se deduce de la orden, no se guarda de nuevo.
                var restante = cantidad;
                foreach (var (idProd, saldo) in await _stock.ObtenerOrdenesConSaldoAsync(idProducto))
                {
                    if (restante <= 0) break;
                    var tomar = Math.Min(saldo, restante);
                    despacho.DetalleDespachos.Add(new DetalleDespacho { IdProd = idProd, Cantidad = tomar });
                    restante -= tomar;
                }

                if (restante > 0)
                    return (ResultadoPedido.StockInsuficiente,
                        $"Producto {idProducto}: faltan {restante} unidades producidas y finalizadas para despachar.", null);

                pedido.DetallePedidos.First(x => x.IdProducto == idProducto).CantidadDespachada += cantidad;
                productos[idProducto].StockActual -= cantidad;
            }
            pedido.Despachos.Add(despacho);

            pedido.EstadoPedido = CalcularEstado(pedido);
            if (pedido.EstadoPedido == EstadoCompletado) pedido.FechaReal = DateTime.Now;

            await _pedidoRepositorio.GuardarCambiosAsync();
            return (ResultadoPedido.Ok, null, await ArmarResultadoAsync(pedido));
        }

    }



}


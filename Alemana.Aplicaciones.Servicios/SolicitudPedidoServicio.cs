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
        private const string EstadoInicial = "Pendiente";
        private const string EstadoCubierto = "Cubierto";

        private readonly IStockRepositorio _stock;
        private readonly ISolicitudPedidoRepositorio _pedidoRepositorio;
        private readonly IOperarioRepositorio _operariosRepositorio;
        private readonly IOrdenProduccionRepositorio _ordenesRepositorio;

        public SolicitudPedidoServicio(ISolicitudPedidoRepositorio pedidoRepositorio, IOperarioRepositorio operariosRepositorio, IOrdenProduccionRepositorio ordenesRepositorio, IStockRepositorio stock)
        {
            _pedidoRepositorio = pedidoRepositorio;
            _operariosRepositorio = operariosRepositorio;
            _ordenesRepositorio = ordenesRepositorio;
            _stock = stock;
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
            if (pedido == null)
            {
                return null;
            }
            var detalle = await _pedidoRepositorio.ObtenerDetallePedido(idPedido);
            var items = new List<ItemAsignableDTO>();

            foreach (var d in detalle)
            {
                var stock = await _stock.ObtenerStockProductoAsync(d.IdProducto);
                var aProducir = Math.Max(d.CantidadesProductos - stock, 0);

                var capaces = aProducir > 0
                    ? await _operariosRepositorio.ObtenerCapacesAsync(d.IdProducto)
                    : new List<Operario>();

                items.Add(new ItemAsignableDTO
                {
                    IdProducto = d.IdProducto,
                    NombreProducto = d.IdProductoNavigation?.Nombre ?? "",
                    Cantidad = d.CantidadesProductos,
                    StockDisponible = stock,
                    CantidadAProducir = aProducir,
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
                var producto = await _stock.ObtenerProductoAsync(det.IdProducto);
                if (producto == null)
                    return (ResultadoAceptacion.AsignacionInvalida, $"El producto {det.IdProducto} no existe.");

                int enStock = Math.Max((int?)producto.StockActual ?? 0, 0);
                int deStock = Math.Min(enStock, det.CantidadesProductos);
                int aProducir = det.CantidadesProductos - deStock;

                producto.StockActual = enStock - deStock;   

                if (aProducir == 0)
                {
                    _ordenesRepositorio.AgregarOrden(new Ordenproduccion
                    {
                        IdPedido = pedido.IdPedido,
                        IdProducto = det.IdProducto,
                        CantidadRequerida = det.CantidadesProductos,
                        FechaPedido = pedido.FechaPedido,
                        FechaEstimada = pedido.FechaEstimada,
                        EstadoPedido = EstadoCubierto
                    });
                    continue;
                }

                var orden = new Ordenproduccion
                {
                    IdPedido = pedido.IdPedido,
                    IdProducto = det.IdProducto,
                    CantidadRequerida = aProducir,             
                    FechaPedido = pedido.FechaPedido,
                    FechaEstimada = pedido.FechaEstimada,
                    EstadoPedido = EstadoInicial
                };

                var idOperario = asignaciones
                    .FirstOrDefault(a => a.IdProducto == det.IdProducto)?.IdOperario;

                if (idOperario.HasValue)
                {
                    var capaces = await _operariosRepositorio.ObtenerCapacesAsync(det.IdProducto);
                    if (!capaces.Any(o => o.IdOperario == idOperario.Value))
                        return (ResultadoAceptacion.AsignacionInvalida,
                            $"El operario {idOperario.Value} no puede producir el producto {det.IdProducto}.");

                    orden.OrdAsigOps.Add(new OrdAsigOp
                    {
                        IdOperario = idOperario.Value,
                        Cantidades = aProducir,
                        FechaIni = ahora
                    });
                }

                var falta = await ConsumirInsumosAsync(orden, det.IdProducto, aProducir);
                if (falta != null)
                    return (ResultadoAceptacion.StockInsuficiente, falta);

                _ordenesRepositorio.AgregarOrden(orden);
            }

            pedido.EstadoPedido = "Aceptado";

            await _pedidoRepositorio.GuardarCambiosAsync();

            return (ResultadoAceptacion.Ok, null);
        }


        private async Task<string?> ConsumirInsumosAsync(Ordenproduccion orden, int idProducto, int cantidadProducto)
        {
            var requerimientos = await _stock.ObtenerRequerimientosAsync(idProducto);

            if (requerimientos.Count == 0)
                return $"El producto {idProducto} no tiene una receta con materias primas cargadas.";

            foreach (var (idMateriaP, nombre, unidad, necesariaPorUnidad) in requerimientos)
            {
                decimal pendiente = necesariaPorUnidad * cantidadProducto;

                var lotes = await _stock.ObtenerLotesDisponiblesAsync(idMateriaP);

                foreach (var lote in lotes)
                {
                    if (pendiente <= 0) break;


                    if (lote.CantidadLote <= 0) continue;

                    var usar = Math.Min(lote.CantidadLote, pendiente);

                    lote.CantidadLote -= usar;
                    if (lote.CantidadLote == 0) lote.EstadoLote = 0;    

                    orden.Consumolotes.Add(new Consumolote
                    {
                        IdLote = lote.IdLote,
                        CantConsumida = usar
                    });

                    pendiente -= usar;
                }

                if (pendiente > 0)
                    return $"Falta {pendiente:0.##} {unidad} de {nombre} para producir el producto {idProducto}.";
            }

            return null;
        }
    }
}

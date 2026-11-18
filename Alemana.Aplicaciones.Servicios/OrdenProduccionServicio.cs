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
    /// Órdenes de producción. No están vinculadas a pedidos: el usuario decide cuánto producir.
    /// </summary>
    public class OrdenProduccionServicio : IOrdenProduccionServicio
    {
        public const string EstadoPendiente = "Pendiente";
        public const string EstadoEnProceso = "En Proceso";
        private const int LongitudMaximaEstado = 50;

        private readonly IOrdenProduccionRepositorio _repo;
        private readonly IProductoRepositorio _productoRepo;
        private readonly IOrdAsigOpRepositorio _asignacionRepo;
        private readonly IStockRepositorio _stock;
        private readonly IOperarioRepositorio _operarios;

        public OrdenProduccionServicio(
            IOrdenProduccionRepositorio repo,
            IProductoRepositorio productoRepo,
            IOrdAsigOpRepositorio asignacionRepo,
            IStockRepositorio stock,
            IOperarioRepositorio operarios)
        {
            _repo = repo;
            _productoRepo = productoRepo;
            _asignacionRepo = asignacionRepo;
            _stock = stock;
            _operarios = operarios;
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

        /// <summary>Crea la orden en estado Pendiente. No consume insumos hasta confirmarla.</summary>
        public async Task<OrdenProduccionDTO> Agregar(OrdenProduccionDTO dto)
        {
            if (dto == null)
                throw new ArgumentException("La orden de producción no puede ser nula.");

            var fechaPedido = DateTime.Now;


            var entidad = new Ordenproduccion
            {
                FechaCreacion = fechaPedido,
                EstadoOrden = EstadoInicial,
                FechaEstimada = dto.FechaEstimada,
                FechaReal = null,
                CantidadAproducir = dto.CantidadAproducir,
                IdProducto = dto.IdProducto,

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

            if (string.IsNullOrWhiteSpace(dto.EstadoOrden))
                throw new ArgumentException("El estado de la orden es obligatorio.");

            var estado = dto.EstadoOrden.Trim();
            if (estado.Length > LongitudMaximaEstado)
                throw new ArgumentException($"El estado no puede superar los {LongitudMaximaEstado} caracteres.");

  

            var asignado = await _asignacionRepo.TotalAsignadoPorOrden(existente.IdProd);
            if (dto.CantidadAproducir < asignado)
                throw new ArgumentException(
                    $"La cantidad requerida no puede ser menor a la ya asignada a operarios ({asignado}).");

            var entidad = new Ordenproduccion
            {
                IdProd = existente.IdProd,
                FechaCreacion = existente.FechaCreacion,
                EstadoOrden = estado,
                FechaEstimada = dto.FechaEstimada,
                FechaReal = dto.FechaReal,
                CantidadAproducir = dto.CantidadAproducir,
                IdProducto = dto.IdProducto,

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

        /// <summary>Calcula la materia prima necesaria para producir una cantidad y si alcanza el stock.</summary>
        public async Task<CalculoProduccionDTO> CalcularAsync(CalcularProduccionDTO dto)
        {
            if (dto == null || dto.Cantidad <= 0)
                throw new ArgumentException("La cantidad a producir debe ser mayor a cero.");

            var producto = await _productoRepo.ObtenerProductoPorId(dto.IdProducto);
            if (producto == null)
                throw new ArgumentException($"El producto {dto.IdProducto} no existe.");

            var requerimientos = await _stock.ObtenerRequerimientosAsync(dto.IdProducto);
            if (requerimientos.Count == 0)
                throw new ArgumentException($"El producto {dto.IdProducto} no tiene una receta con materias primas cargadas.");

            var resultado = new CalculoProduccionDTO
            {
                IdProducto = producto.IdProducto,
                NombreProducto = producto.Nombre,
                Cantidad = dto.Cantidad,
                Suficiente = true
            };

            foreach (var (idMateriaP, nombre, unidad, necesariaPorUnidad) in requerimientos)
            {
                var necesaria = necesariaPorUnidad * dto.Cantidad;
                var lotes = await _stock.ObtenerLotesDisponiblesAsync(idMateriaP);
                var disponible = lotes.Sum(l => l.CantidadLote);
                var alcanza = disponible >= necesaria;

                if (!alcanza) resultado.Suficiente = false;

                resultado.MateriasPrimas.Add(new MateriaPrimaRequeridaDTO
                {
                    IdMateriaP = idMateriaP,
                    NombreMateriaP = nombre,
                    Unidad = unidad,
                    CantidadNecesaria = necesaria,
                    StockDisponible = disponible,
                    Suficiente = alcanza
                });
            }

            return resultado;
        }

        /// <summary>Operarios capaces de producir el producto de la orden.</summary>
        public async Task<List<OperarioOpcionDTO>?> ObtenerOperariosCapacesAsync(int idProd)
        {
            var orden = await _repo.ObtenerPorId(idProd);
            if (orden == null) return null;

            var capaces = await _operarios.ObtenerCapacesAsync(orden.IdProducto);

            return capaces.Select(o => new OperarioOpcionDTO
            {
                IdOperario = o.IdOperario,
                NombreCompleto = $"{o.Nombre} {o.Apellido}".Trim()
            }).ToList();
        }

        /// <summary>
        /// Confirma una orden pendiente: valida el operario, consume la materia prima,
        /// asigna el operario y pasa la orden a En Proceso.
        /// </summary>
        public async Task<(ResultadoConfirmacion Resultado, string? Mensaje)> ConfirmarAsync(int idProd, int idOperario)
        {
            var orden = await _repo.ObtenerPorId(idProd);
            if (orden == null)
                return (ResultadoConfirmacion.NoExiste, null);

            if (orden.EstadoPedido != EstadoPendiente)
                return (ResultadoConfirmacion.NoPendiente, "La orden ya fue confirmada.");

            var capaces = await _operarios.ObtenerCapacesAsync(orden.IdProducto);
            if (!capaces.Any(o => o.IdOperario == idOperario))
                return (ResultadoConfirmacion.OperarioNoCapaz,
                    $"El operario {idOperario} no puede producir el producto {orden.IdProducto}.");

            var falta = await ConsumirInsumosAsync(orden);
            if (falta != null)
                return (ResultadoConfirmacion.StockInsuficiente, falta);

            orden.OrdAsigOps.Add(new OrdAsigOp
            {
                IdOperario = idOperario,
                Cantidades = orden.CantidadRequerida,
                FechaIni = DateTime.Now
            });
            orden.EstadoPedido = EstadoEnProceso;

            await _repo.GuardarCambiosAsync();
            return (ResultadoConfirmacion.Ok, null);
        }

        /// <summary>Descuenta de los lotes la materia prima de la receta por la cantidad de la orden.</summary>
        private async Task<string?> ConsumirInsumosAsync(Ordenproduccion orden)
        {
            var requerimientos = await _stock.ObtenerRequerimientosAsync(orden.IdProducto);

            if (requerimientos.Count == 0)
                return $"El producto {orden.IdProducto} no tiene una receta con materias primas cargadas.";

            foreach (var (idMateriaP, nombre, unidad, necesariaPorUnidad) in requerimientos)
            {
                decimal pendiente = necesariaPorUnidad * orden.CantidadRequerida;
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
                    return $"Falta {pendiente:0.##} {unidad} de {nombre} para producir el producto {orden.IdProducto}.";
            }

            return null;
        }

        private async Task ValidarAsync(
            int cantidadRequerida,
            int idProducto,
            DateTime fechaPedido,
            DateTime? fechaEstimada,
            DateTime? fechaReal)
        {
            if (cantidadRequerida <= 0)
                throw new ArgumentException("La cantidad requerida debe ser mayor a cero.");

            var producto = await _productoRepo.ObtenerProductoPorId(idProducto);
            if (producto == null)
                throw new ArgumentException($"El producto {idProducto} no existe.");

            if (fechaEstimada.HasValue && fechaEstimada.Value.Date < fechaPedido.Date)
                throw new ArgumentException("La fecha estimada no puede ser anterior a la fecha de creación.");

            if (fechaReal.HasValue && fechaReal.Value.Date < fechaPedido.Date)
                throw new ArgumentException("La fecha real no puede ser anterior a la fecha de creación.");
        }

        private static OrdenProduccionDTO ADto(Ordenproduccion o)
        {
            var asig = o.OrdAsigOps.FirstOrDefault();
            var op = asig?.IdOperarioNavigation;

            return new OrdenProduccionDTO
            {
                IdProd = o.IdProd,
                FechaCreacion = o.FechaCreacion,
                EstadoOrden = o.EstadoOrden,
                FechaEstimada = o.FechaEstimada,
                FechaReal = o.FechaReal,
                CantidadAproducir = o.CantidadAproducir,
                IdProducto = o.IdProducto,


                NombreProducto = o.IdProductoNavigation?.Nombre,
                IdOperario = asig?.IdOperario,
                NombreOperario = op == null ? null : $"{op.Nombre} {op.Apellido}"
            };
        }

        /// <summary>
        /// Órdenes de producción que todavía no terminaron. Ya no se agrupan por pedido:
        /// todas van en un único grupo.
        /// </summary>
        public async Task<List<ProduccionPedidoDTO>> ObtenerProduccionAsync()
        {
            var ordenes = await _repo.ObtenerParaProduccionAsync();
            if (ordenes.Count == 0)
                return new List<ProduccionPedidoDTO>();

        //    return ordenes
        //        .GroupBy(o => o.IdPedido ?? 0)
        //        .Select(g => new ProduccionPedidoDTO
        //        {
        //            IdPedido = g.Key,
        //            FechaPedido = g.Min(o => o.FechaPedido),
        //            FechaEstimada = g.Max(o => o.FechaEstimada),
        //            Ordenes = g.Select(ADto).ToList()
        //        })
        //        .OrderByDescending(p => p.IdPedido)
        //        .ToList();
        //}
    }
}

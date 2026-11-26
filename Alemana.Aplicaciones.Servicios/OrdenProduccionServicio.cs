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
    /// Pendiente -> (confirmar: operario) En Proceso -> (finalizar: descuenta lotes, suma stock) Finalizada.
    /// </summary>
    public class OrdenProduccionServicio : IOrdenProduccionServicio
    {
        public const string EstadoPendiente = "Pendiente";
        public const string EstadoEnProceso = "En Proceso";
        public const string EstadoFinalizada = "Finalizada";
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

        /// <summary>Crea la orden en estado Pendiente. No reserva ni consume insumos hasta confirmarla.</summary>
        public async Task<OrdenProduccionDTO> Agregar(OrdenProduccionDTO dto)
        {
            if (dto == null)
                throw new ArgumentException("La orden de producción no puede ser nula.");

            var ahora = DateTime.Now;
            await ValidarAsync(dto.CantidadAproducir, dto.IdProducto, ahora, dto.FechaEstimada, null);

            var entidad = new Ordenproduccion
            {
                FechaCreacion = ahora,
                EstadoOrden = EstadoPendiente,
                FechaEstimada = dto.FechaEstimada,
                FechaReal = null,
                CantidadAproducir = dto.CantidadAproducir,
                IdProducto = dto.IdProducto
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

            await ValidarAsync(dto.CantidadAproducir, dto.IdProducto, existente.FechaCreacion, dto.FechaEstimada, dto.FechaReal);

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
                IdProducto = dto.IdProducto
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

        /// <summary>
        /// Calcula la materia prima necesaria para hacer la receta la cantidad de veces indicada (cada vez rinde
        /// recetaproducto.rinde unidades del producto). El disponible descuenta lo que
        /// ya tienen reservado las órdenes En Proceso.
        /// </summary>
        public async Task<CalculoProduccionDTO> CalcularAsync(CalcularProduccionDTO dto)
        {
            if (dto == null || dto.Cantidad <= 0)
                throw new ArgumentException("Las veces que se hará la receta deben ser mayores a cero.");

            var producto = await _productoRepo.ObtenerProductoPorId(dto.IdProducto);
            if (producto == null)
                throw new ArgumentException($"El producto {dto.IdProducto} no existe.");

            var rinde = await _stock.ObtenerRindeAsync(dto.IdProducto);
            if (rinde <= 0)
                throw new ArgumentException($"La receta del producto {dto.IdProducto} no tiene definido cuánto rinde.");

            var requerimientos = await _stock.ObtenerRequerimientosAsync(dto.IdProducto);
            if (requerimientos.Count == 0)
                throw new ArgumentException($"El producto {dto.IdProducto} no tiene una receta con materias primas cargadas.");

            var reservado = await _stock.ObtenerReservadoPorOrdenesEnProcesoAsync();

            var resultado = new CalculoProduccionDTO
            {
                IdProducto = producto.IdProducto,
                NombreProducto = producto.Nombre,
                Cantidad = dto.Cantidad,
                Rinde = rinde,
                Suficiente = true
            };

            foreach (var (idMateriaP, nombre, unidad, necesariaPorUnidad) in requerimientos)
            {
                var necesaria = necesariaPorUnidad * dto.Cantidad;
                var lotes = await _stock.ObtenerLotesDisponiblesAsync(idMateriaP);
                var enLotes = lotes.Sum(l => l.CantidadLote);
                var disponible = Math.Max(enLotes - (reservado.TryGetValue(idMateriaP, out var r) ? r : 0m), 0m);
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
        /// Confirma una orden pendiente: valida operario y materia prima disponible (descontando lo reservado),
        /// asigna el operario y pasa la orden a En Proceso. Los lotes se descuentan al finalizar.
        /// </summary>
        public async Task<(ResultadoConfirmacion Resultado, string? Mensaje)> ConfirmarAsync(int idProd, int idOperario)
        {
            var orden = await _repo.ObtenerPorId(idProd);
            if (orden == null)
                return (ResultadoConfirmacion.NoExiste, null);

            if (orden.EstadoOrden != EstadoPendiente)
                return (ResultadoConfirmacion.NoPendiente, "La orden ya fue confirmada.");

            var capaces = await _operarios.ObtenerCapacesAsync(orden.IdProducto);
            if (!capaces.Any(o => o.IdOperario == idOperario))
                return (ResultadoConfirmacion.OperarioNoCapaz,
                    $"El operario {idOperario} no puede producir el producto {orden.IdProducto}.");

            var calculo = await CalcularAsync(new CalcularProduccionDTO
            {
                IdProducto = orden.IdProducto,
                Cantidad = orden.CantidadAproducir
            });

            var faltantes = calculo.MateriasPrimas.Where(m => !m.Suficiente).ToList();
            if (faltantes.Count > 0)
            {
                var detalle = string.Join("; ", faltantes.Select(f =>
                    $"{f.NombreMateriaP} (necesita {f.CantidadNecesaria:0.##} {f.Unidad}, disponible {f.StockDisponible:0.##})"));
                return (ResultadoConfirmacion.StockInsuficiente, "No hay materia prima suficiente: " + detalle + ".");
            }

            orden.OrdAsigOps.Add(new OrdAsigOp
            {
                IdOperario = idOperario,
                Cantidades = orden.CantidadAproducir,
                FechaIni = DateTime.Now
            });
            orden.EstadoOrden = EstadoEnProceso;

            await _repo.GuardarCambiosAsync();
            return (ResultadoConfirmacion.Ok, null);
        }

        /// <summary>
        /// Finaliza una orden En Proceso: descuenta la materia prima de los lotes (FIFO por fecha de ingreso),
        /// registra el consumo, suma al stock del producto (veces que se hizo la receta * lo que rinde) y cierra la orden.
        /// </summary>
        public async Task<(ResultadoConfirmacion Resultado, string? Mensaje)> FinalizarAsync(int idProd)
        {
            var orden = await _repo.ObtenerConDetalleAsync(idProd);
            if (orden == null)
                return (ResultadoConfirmacion.NoExiste, null);

            if (orden.EstadoOrden != EstadoEnProceso)
                return (ResultadoConfirmacion.NoPendiente, "Solo se pueden finalizar órdenes En Proceso.");

            var requerimientos = await _stock.ObtenerRequerimientosAsync(orden.IdProducto);
            if (requerimientos.Count == 0)
                return (ResultadoConfirmacion.StockInsuficiente,
                    $"El producto {orden.IdProducto} no tiene una receta con materias primas cargadas.");

            var rinde = await _stock.ObtenerRindeAsync(orden.IdProducto);
            if (rinde <= 0)
                return (ResultadoConfirmacion.StockInsuficiente,
                    $"La receta del producto {orden.IdProducto} no tiene definido cuánto rinde.");

            // Pasada 1: verificar que alcanza, sin tocar nada
            var plan = new List<(Lote Lote, decimal Usar)>();
            foreach (var (idMateriaP, nombre, unidad, porUnidad) in requerimientos)
            {
                decimal pendiente = porUnidad * orden.CantidadAproducir;
                var lotes = await _stock.ObtenerLotesDisponiblesAsync(idMateriaP);

                foreach (var lote in lotes)
                {
                    if (pendiente <= 0) break;
                    var usar = Math.Min(lote.CantidadLote, pendiente);
                    if (usar <= 0) continue;
                    plan.Add((lote, usar));
                    pendiente -= usar;
                }

                if (pendiente > 0)
                    return (ResultadoConfirmacion.StockInsuficiente,
                        $"Falta {pendiente:0.##} {unidad} de {nombre} para finalizar la orden.");
            }

            // Pasada 2: aplicar
            foreach (var (lote, usar) in plan)
            {
                lote.CantidadLote -= usar;
                if (lote.CantidadLote <= 0) lote.EstadoLote = 0;

                orden.Consumolotes.Add(new Consumolote
                {
                    IdLote = lote.IdLote,
                    CantConsumida = usar
                });
            }

            var producto = await _stock.ObtenerProductoAsync(orden.IdProducto);
            if (producto != null)
                producto.StockActual += orden.CantidadAproducir * rinde;

            var ahora = DateTime.Now;
            foreach (var a in orden.OrdAsigOps.Where(a => a.FechaFin == null))
                a.FechaFin = ahora;

            orden.EstadoOrden = EstadoFinalizada;
            orden.FechaReal = ahora;

            await _repo.GuardarCambiosAsync();
            return (ResultadoConfirmacion.Ok, null);
        }

        /// <summary>Órdenes que todavía no terminaron (Pendiente y En Proceso).</summary>
        public async Task<List<OrdenProduccionDTO>> ObtenerProduccionAsync()
        {
            var ordenes = await _repo.ObtenerParaProduccionAsync();
            return ordenes.Select(ADto).ToList();
        }

        private async Task ValidarAsync(
            int cantidadAproducir,
            int idProducto,
            DateTime fechaCreacion,
            DateTime? fechaEstimada,
            DateTime? fechaReal)
        {
            if (cantidadAproducir <= 0)
                throw new ArgumentException("La cantidad a producir debe ser mayor a cero.");

            var producto = await _productoRepo.ObtenerProductoPorId(idProducto);
            if (producto == null)
                throw new ArgumentException($"El producto {idProducto} no existe.");

            if (fechaEstimada.HasValue && fechaEstimada.Value.Date < fechaCreacion.Date)
                throw new ArgumentException("La fecha estimada no puede ser anterior a la fecha de creación.");

            if (fechaReal.HasValue && fechaReal.Value.Date < fechaCreacion.Date)
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
                Rinde = o.IdProductoNavigation?.IdRecetaNavigation?.Rinde ?? 0,
                IdProducto = o.IdProducto,
                NombreProducto = o.IdProductoNavigation?.Nombre,
                IdOperario = asig?.IdOperario,
                NombreOperario = op == null ? null : $"{op.Nombre} {op.Apellido}"
            };
        }
    }
}

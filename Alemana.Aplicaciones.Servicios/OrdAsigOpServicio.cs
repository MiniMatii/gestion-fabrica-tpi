using Alemana.Data.Repositorios;
using Alemana.Dominio.Models;
using Alemana.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alemana.Aplicaciones.Servicios
{
    public class OrdAsigOpServicio : IOrdAsigOpServicio
    {
        private readonly IOrdAsigOpRepositorio _repo;
        private readonly IOrdenProduccionRepositorio _ordenRepo;
        private readonly IOperarioRepositorio _operarioRepo;

        public OrdAsigOpServicio(
            IOrdAsigOpRepositorio repo,
            IOrdenProduccionRepositorio ordenRepo,
            IOperarioRepositorio operarioRepo)
        {
            _repo = repo;
            _ordenRepo = ordenRepo;
            _operarioRepo = operarioRepo;
        }

        public async Task<List<OrdAsigOpDTO>> ObtenerTodas()
        {
            var lista = await _repo.ObtenerTodas();
            return lista.Select(ADto).ToList();
        }

        public async Task<List<OrdAsigOpDTO>?> ObtenerPorOrden(int idProd)
        {
            var orden = await _ordenRepo.ObtenerPorId(idProd);
            if (orden == null) return null;

            var lista = await _repo.ObtenerPorOrden(idProd);
            return lista.Select(ADto).ToList();
        }

        public async Task<OrdAsigOpDTO?> ObtenerPorId(int idProd, int idOperario)
        {
            var a = await _repo.ObtenerPorId(idProd, idOperario);
            return a == null ? null : ADto(a);
        }

        public async Task<OrdAsigOpDTO> Agregar(OrdAsigOpDTO dto)
        {
            if (dto == null)
                throw new ArgumentException("La asignación no puede ser nula.");

            var orden = await _ordenRepo.ObtenerPorId(dto.IdProd);
            if (orden == null)
                throw new ArgumentException($"La orden de producción {dto.IdProd} no existe.");

            var operario = await _operarioRepo.ObtenerOperarioPorId(dto.IdOperario);
            if (operario == null)
                throw new ArgumentException($"El operario {dto.IdOperario} no existe.");

            if (await _repo.ObtenerPorId(dto.IdProd, dto.IdOperario) != null)
                throw new InvalidOperationException(
                    "El operario ya está asignado a esta orden. Modifique la asignación existente.");

            var fechaIni = dto.FechaIni == default ? DateTime.Now : dto.FechaIni;

            ValidarFechas(fechaIni, dto.FechaFin);
            await ValidarCantidadAsync(orden, dto.Cantidades, null);

            var entidad = new OrdAsigOp
            {
                IdProd = dto.IdProd,
                IdOperario = dto.IdOperario,
                Cantidades = dto.Cantidades,
                FechaIni = fechaIni,
                FechaFin = dto.FechaFin
            };

            var nueva = await _repo.Agregar(entidad);
            return ADto(nueva);
        }

        public async Task<bool> Actualizar(OrdAsigOpDTO dto)
        {
            if (dto == null)
                throw new ArgumentException("La asignación no puede ser nula.");

            var existente = await _repo.ObtenerPorId(dto.IdProd, dto.IdOperario);
            if (existente == null) return false;

            var orden = await _ordenRepo.ObtenerPorId(dto.IdProd);
            if (orden == null) return false;

            var fechaIni = dto.FechaIni == default ? existente.FechaIni : dto.FechaIni;

            ValidarFechas(fechaIni, dto.FechaFin);
            await ValidarCantidadAsync(orden, dto.Cantidades, dto.IdOperario);

            var entidad = new OrdAsigOp
            {
                IdProd = existente.IdProd,
                IdOperario = existente.IdOperario,
                Cantidades = dto.Cantidades,
                FechaIni = fechaIni,
                FechaFin = dto.FechaFin
            };

            return await _repo.Actualizar(entidad);
        }

        public async Task<bool> Eliminar(int idProd, int idOperario)
        {
            return await _repo.Eliminar(idProd, idOperario);
        }

        private static void ValidarFechas(DateTime fechaIni, DateTime? fechaFin)
        {
            if (fechaFin.HasValue && fechaFin.Value < fechaIni)
                throw new ArgumentException("La fecha de fin no puede ser anterior a la fecha de inicio.");
        }

        private async Task ValidarCantidadAsync(Ordenproduccion orden, int cantidades, int? excluirIdOperario)
        {
            if (cantidades <= 0)
                throw new ArgumentException("La cantidad asignada debe ser mayor a cero.");

            var yaAsignado = await _repo.TotalAsignadoPorOrden(orden.IdProd, excluirIdOperario);
            var total = yaAsignado + cantidades;

            if (total > orden.CantidadRequerida)
                throw new ArgumentException(
                    $"La suma asignada ({total}) supera la cantidad requerida de la orden ({orden.CantidadRequerida}).");
        }

        private static OrdAsigOpDTO ADto(OrdAsigOp a)
        {
            return new OrdAsigOpDTO
            {
                IdProd = a.IdProd,
                IdOperario = a.IdOperario,
                Cantidades = a.Cantidades,
                FechaIni = a.FechaIni,
                FechaFin = a.FechaFin
            };
        }
    }
}

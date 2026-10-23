using Alemana.Data.Repositorios;
using Alemana.Dominio.Models;
using Alemana.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alemana.Aplicaciones.Servicios
{
    public class ConsumoLoteServicio : IConsumoLoteServicio
    {
        private readonly IConsumoLoteRepositorio _repo;
        private readonly IOrdenProduccionRepositorio _ordenRepo;
        private readonly ILoteRepositorio _loteRepo;

        public ConsumoLoteServicio(
            IConsumoLoteRepositorio repo,
            IOrdenProduccionRepositorio ordenRepo,
            ILoteRepositorio loteRepo)
        {
            _repo = repo;
            _ordenRepo = ordenRepo;
            _loteRepo = loteRepo;
        }

        public async Task<List<ConsumoLoteDTO>> ObtenerTodos()
        {
            var lista = await _repo.ObtenerTodos();
            return lista.Select(ADto).ToList();
        }

        public async Task<List<ConsumoLoteDTO>?> ObtenerPorOrden(int idProd)
        {
            var orden = await _ordenRepo.ObtenerPorId(idProd);
            if (orden == null) return null;

            var lista = await _repo.ObtenerPorOrden(idProd);
            return lista.Select(ADto).ToList();
        }

        public async Task<ConsumoLoteDTO?> ObtenerPorId(int id)
        {
            var c = await _repo.ObtenerPorId(id);
            return c == null ? null : ADto(c);
        }

        public async Task<ConsumoLoteDTO> Agregar(ConsumoLoteDTO dto)
        {
            if (dto == null)
                throw new ArgumentException("El consumo de lote no puede ser nulo.");

            await ValidarAsync(dto, null);

            var entidad = new Consumolote
            {
                CantConsumida = dto.CantConsumida,
                IdProd = dto.IdProd,
                IdLote = dto.IdLote
            };

            var nuevo = await _repo.Agregar(entidad);
            return ADto(nuevo);
        }

        public async Task<bool> Actualizar(ConsumoLoteDTO dto)
        {
            if (dto == null)
                throw new ArgumentException("El consumo de lote no puede ser nulo.");

            var existente = await _repo.ObtenerPorId(dto.IdConsumo);
            if (existente == null) return false;

            await ValidarAsync(dto, existente);

            var entidad = new Consumolote
            {
                IdConsumo = existente.IdConsumo,
                CantConsumida = dto.CantConsumida,
                IdProd = dto.IdProd,
                IdLote = dto.IdLote
            };

            return await _repo.Actualizar(entidad);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _repo.Eliminar(id);
        }

        private async Task ValidarAsync(ConsumoLoteDTO dto, Consumolote? existente)
        {
            if (dto.CantConsumida <= 0)
                throw new ArgumentException("La cantidad consumida debe ser mayor a cero.");

            var orden = await _ordenRepo.ObtenerPorId(dto.IdProd);
            if (orden == null)
                throw new ArgumentException($"La orden de producción {dto.IdProd} no existe.");

            var lote = await _loteRepo.ObtenerLotePorId(dto.IdLote);
            if (lote == null)
                throw new ArgumentException($"El lote {dto.IdLote} no existe.");

            var cambiaDeLote = existente == null || existente.IdLote != dto.IdLote;
            if (cambiaDeLote && lote.EstadoLote == 0)
                throw new ArgumentException($"El lote {dto.IdLote} está dado de baja.");

            var yaConsumido = await _repo.TotalConsumidoPorLote(dto.IdLote, existente?.IdConsumo);
            var disponible = lote.CantidadLote - yaConsumido;
            if (dto.CantConsumida > disponible)
                throw new ArgumentException(
                    $"El lote {dto.IdLote} solo tiene {disponible:0.##} disponibles.");
        }

        private static ConsumoLoteDTO ADto(Consumolote c)
        {
            return new ConsumoLoteDTO
            {
                IdConsumo = c.IdConsumo,
                CantConsumida = c.CantConsumida,
                IdProd = c.IdProd,
                IdLote = c.IdLote
            };
        }
    }
}

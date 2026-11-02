using Alemana.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Alemana.Data.Repositorios
{
    public class SolicitudPedidoRepositorio : ISolicitudPedidoRepositorio
    {
        private readonly DbAlemanaContext _DbA;

        public SolicitudPedidoRepositorio(DbAlemanaContext dbA)
        {
            _DbA = dbA;
        }

        public async Task<Solicitudpedido> AltaPedido(Solicitudpedido pedido)
        {
            if (pedido == null) return null;

            await _DbA.Solicitudpedidos.AddAsync(pedido);
            await _DbA.SaveChangesAsync();
            return pedido;
        }

        public async Task<List<Solicitudpedido>> ObtenerTodos()
        {
            return await _DbA.Solicitudpedidos
                .Include(p => p.DetallePedidos)
                .ToListAsync();
        }

        public async Task<Solicitudpedido> ObtenerPorId(int id)
        {
            return await _DbA.Solicitudpedidos
                .Include(p => p.DetallePedidos)
                .FirstOrDefaultAsync(p => p.IdPedido == id);
        }

        public async Task<bool> EliminarPedido(int id)
        {
            var pedido = await _DbA.Solicitudpedidos
                .Include(p => p.DetallePedidos)
                .FirstOrDefaultAsync(p => p.IdPedido == id);

            if (pedido == null) return false;

            _DbA.DetallePedidos.RemoveRange(pedido.DetallePedidos);
            _DbA.Solicitudpedidos.Remove(pedido);

            await _DbA.SaveChangesAsync();
            return true;
        }

        public async Task<List<DetallePedido>> ObtenerDetallePedido(int idPedido)
        {
            return await _DbA.DetallePedidos
                .AsNoTracking()
                .Include(d => d.IdProductoNavigation)
                .Where(d => d.IdPedido == idPedido)
                .ToListAsync();
        }

        public async Task<List<Solicitudpedido>> ObtenerPendientes()
        {
            return await _DbA.Solicitudpedidos
                .AsNoTracking()
                .Where(p => p.EstadoPedido == "Pendiente")
                .OrderBy(p => p.IdPedido)
                .ToListAsync();
        }

        public async Task<List<Solicitudpedido>> ObtenerPendientesDesde(int ultimoId)
        {
            return await _DbA.Solicitudpedidos
                .AsNoTracking()
                .Where(p => p.EstadoPedido == "Pendiente" && p.IdPedido > ultimoId)
                .OrderBy(p => p.IdPedido)
                .ToListAsync();
        }

        public async Task GuardarCambiosAsync()
        {
            await _DbA.SaveChangesAsync();
        }


    }
    }

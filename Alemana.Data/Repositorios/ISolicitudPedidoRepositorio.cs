using Alemana.Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace Alemana.Data.Repositorios
{
    public interface ISolicitudPedidoRepositorio
    {
        Task<Solicitudpedido> AltaPedido(Solicitudpedido pedido);
        Task<List<Solicitudpedido>> ObtenerTodos();
        Task<Solicitudpedido> ObtenerPorId(int id);
        Task<bool> EliminarPedido(int id);
        Task<List<DetallePedido>> ObtenerDetallePedido(int idPedido);
        Task<List<Solicitudpedido>> ObtenerPendientes();               
        Task<List<Solicitudpedido>> ObtenerPendientesDesde(int ultimoId);
        Task GuardarCambiosAsync();

    }

}
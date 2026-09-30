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
    }

}
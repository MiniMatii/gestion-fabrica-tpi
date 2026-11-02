using Alemana.Data.Repositorios;
using Alemana.Dominio.Models;
using Alemana.DTOs;

namespace Alemana.Aplicaciones.Servicios
{
    public interface ISolicitudPedidoServicio
    {
        Task<SolicitudPedidoDTO> AltaPedido(SolicitudPedidoDTO dto);
        Task<List<SolicitudPedidoDTO>> ObtenerTodos();
        Task<SolicitudPedidoDTO> ObtenerPorId(int id);
        Task<bool> EliminarPedido(int id);
        Task<List<PedidoItemDTO>> ObtenerProductosDePedidoAsync(int idPedido);
        Task<List<PedidoResumenDTO>> ObtenerPendientesAsync();
        Task<List<PedidoResumenDTO>> ObtenerPendientesDesdeAsync(int ultimoId);
        Task<List<ItemAsignableDTO>?> ObtenerItemsAsignablesAsync(int idPedido);
        Task<(ResultadoAceptacion Resultado, string? Mensaje)> AceptarPedidoAsync(int idPedido, AceptarPedidoDTO dto);

    }

}
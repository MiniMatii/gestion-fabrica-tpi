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
        Task<List<ItemPedidoDespachoDTO>?> ObtenerItemsAsync(int idPedido);
        Task<(ResultadoPedido, string?, ResultadoPedidoDTO?)> AceptarAsync(int idPedido, AceptarPedidoProductosDTO dto);
        Task<(ResultadoPedido, string?, ResultadoPedidoDTO?)> DespacharAsync(int idPedido, DespacharPedidoDTO dto);


    }
}

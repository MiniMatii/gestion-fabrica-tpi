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
        Task<List<ItemPedidoAceptacionDTO>?> ObtenerItemsAceptacionAsync(int idPedido);
        Task<(ResultadoAceptarPedido Resultado, string? Mensaje, ResultadoAceptacionPedidoDTO? Datos)> AceptarPedidoAsync(int idPedido, AceptarPedidoProductosDTO dto);
        Task<(ResultadoAceptarPedido Resultado, string? Mensaje, ResultadoAceptacionPedidoDTO? Datos)> DespacharPendientesAsync(int idPedido);
    }
}

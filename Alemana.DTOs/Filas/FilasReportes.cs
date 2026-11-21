namespace Alemana.DTOs;

// Filas de los reportes estadísticos (pantalla Reportes de la web).

/// <summary>
/// Una fila por (pedido, producto, orden de producción, lote). Los campos de orden y lote son null
/// cuando no hay producción finalizada candidata para ese producto.
/// </summary>
public record ReporteLoteProductoFila(
    int IdPedido, DateTime FechaPedido, int IdProducto, string Producto, int CantidadDespachada,
    int? IdProd, DateTime? FechaOrden, string MateriaPrima, string Unidad,
    int? IdLote, decimal? CantidadUsada, DateTime? FechaVencimiento, string Proveedor);

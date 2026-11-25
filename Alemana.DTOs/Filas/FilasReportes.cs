namespace Alemana.DTOs;

// Filas de los reportes estadísticos (pantalla Reportes de la web).

/// <summary>
/// Una fila por (pedido, producto, orden de origen, lote). Los campos de lote son null cuando la orden no tiene consumos.
/// </summary>
public record ReporteLoteProductoFila(
    int IdPedido, DateTime FechaPedido, int IdProducto, string Producto, int CantidadDeOrigen,
    int IdProd, DateTime? FechaOrden, string MateriaPrima, string Unidad,
    int? IdLote, decimal? CantidadUsada, DateTime? FechaVencimiento, string Proveedor);

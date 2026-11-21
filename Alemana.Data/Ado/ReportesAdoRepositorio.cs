using Alemana.DTOs;

namespace Alemana.Data.Ado;

/// <summary>Reportes estadísticos con ADO.NET. Cada reporte es un método con sus filtros.</summary>
public class ReportesAdoRepositorio(AdoConexion db)
{
    /// <summary>
    /// De cada producto despachado en un pedido, de qué lotes salió la materia prima. Las órdenes no están atadas
    /// a pedidos: se toman las órdenes finalizadas de ese producto hasta el último despacho, dentro de <paramref name="dias"/>.
    /// </summary>
    public Task<List<ReporteLoteProductoFila>> LotesPorProductoDePedidoAsync(
        int? idPedido, string? producto, DateTime? desde, DateTime? hasta, int dias)
    {
        var filtros = new Filtros()
            .Si(idPedido is not null, "sp.idPedido = @pedido", ("@pedido", idPedido))
            .Si(!string.IsNullOrWhiteSpace(producto), "pr.nombre LIKE @producto", ("@producto", Filtros.Like(producto ?? "")))
            .Si(desde is not null, "DATE(sp.fechaPedido) >= @desde", ("@desde", desde?.Date))
            .Si(hasta is not null, "DATE(sp.fechaPedido) <= @hasta", ("@hasta", hasta?.Date));

        var sql =
            "SELECT sp.idPedido, sp.fechaPedido, pr.idProducto, pr.nombre AS producto, dp.cantidad, " +
            "       o.idProd, o.fechaReal AS fechaOrden, mp.nombre AS materiaPrima, mp.unidad, " +
            "       cl.idLote, cl.cantConsumida, l.fechaVencimiento, COALESCE(pv.razonSocial, '') AS proveedor " +
            "FROM solicitudpedido sp " +
            "JOIN (SELECT d.idPedido, dd.idProducto, SUM(dd.cantidad) AS cantidad, MAX(d.fechaDespacho) AS ultima " +
            "      FROM despacho d JOIN detalle_despacho dd ON dd.idDespacho = d.idDespacho " +
            "      GROUP BY d.idPedido, dd.idProducto) dp ON dp.idPedido = sp.idPedido " +
            "JOIN productos pr ON pr.idProducto = dp.idProducto " +
            "LEFT JOIN ordenproduccion o ON o.idProducto = pr.idProducto AND o.estadoOrden = 'Finalizada' " +
            "     AND o.fechaReal <= dp.ultima AND o.fechaReal >= DATE_SUB(dp.ultima, INTERVAL @dias DAY) " +
            "LEFT JOIN consumolote cl ON cl.idProd = o.idProd " +
            "LEFT JOIN lote l ON l.idLote = cl.idLote " +
            "LEFT JOIN materiap mp ON mp.idMateriaP = l.idMateriaP " +
            "LEFT JOIN proveedores pv ON pv.idProveedor = l.idProveedor " +
            filtros.Where +
            " ORDER BY sp.idPedido DESC, pr.nombre, o.idProd, mp.nombre, cl.idLote";

        return db.ConsultarAsync(sql, r => new ReporteLoteProductoFila(
                Lector.Int(r, "idPedido"),
                Lector.Fecha(r, "fechaPedido"),
                Lector.Int(r, "idProducto"),
                Lector.Texto(r, "producto"),
                Lector.Int(r, "cantidad"),
                Lector.IntN(r, "idProd"),
                Lector.FechaN(r, "fechaOrden"),
                Lector.Texto(r, "materiaPrima"),
                Lector.Texto(r, "unidad"),
                Lector.IntN(r, "idLote"),
                r["cantConsumida"] is DBNull ? null : Lector.Decimal(r, "cantConsumida"),
                Lector.FechaN(r, "fechaVencimiento"),
                Lector.Texto(r, "proveedor")),
            filtros.Parametros.Append(("@dias", (object?)dias)).ToArray());
    }
}

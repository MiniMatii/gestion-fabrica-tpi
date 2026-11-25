using Alemana.DTOs;

namespace Alemana.Data.Ado;

/// <summary>
/// Trazabilidad con ADO.NET. El vínculo pedido -> producción es exacto: cada línea de detalle_despacho
/// guarda la orden de la que sale la cantidad (FIFO por fechaReal); el producto se obtiene de la orden.
/// </summary>
public class TrazabilidadAdoRepositorio(AdoConexion db)
{
    private const string SqlOrden =
        "SELECT o.idProd, o.idProducto, pr.nombre AS producto, o.estadoOrden, o.cantidadAProducir, " +
        "       o.fechaCreacion, o.fechaReal, " +
        "       COALESCE((SELECT TRIM(CONCAT(op.nombre, ' ', op.apellido)) FROM ord_asig_op a " +
        "                 JOIN operarios op ON op.idOperario = a.idOperario " +
        "                 WHERE a.idProd = o.idProd ORDER BY a.fechaIni LIMIT 1), '') AS operario " +
        "FROM ordenproduccion o JOIN productos pr ON pr.idProducto = o.idProducto ";

    private static TrazaOrdenFila MapOrden(System.Data.Common.DbDataReader r) => new(
        Lector.Int(r, "idProd"), Lector.Int(r, "idProducto"), Lector.Texto(r, "producto"),
        Lector.Texto(r, "estadoOrden"), Lector.Int(r, "cantidadAProducir"),
        Lector.Fecha(r, "fechaCreacion"), Lector.FechaN(r, "fechaReal"), Lector.Texto(r, "operario"));

    public async Task<TrazabilidadPedidoDTO?> PorPedidoAsync(int idPedido)
    {
        var cabecera = await db.ConsultarAsync(
            "SELECT sp.idPedido, sp.fechaPedido, sp.estadoPedido, " +
            "       COALESCE(s.nombreSuc, '') AS sucursal, " +
            "       TRIM(CONCAT(COALESCE(e.nombre, ''), ' ', COALESCE(e.apellido, ''))) AS empleado " +
            "FROM solicitudpedido sp " +
            "LEFT JOIN empleados e ON e.idEmpleado = sp.idEmpleado " +
            "LEFT JOIN sucursales s ON s.idSucursal = e.idSucursal " +
            "WHERE sp.idPedido = @id",
            r => new TrazabilidadPedidoDTO
            {
                IdPedido = Lector.Int(r, "idPedido"),
                FechaPedido = Lector.Fecha(r, "fechaPedido"),
                EstadoPedido = Lector.Texto(r, "estadoPedido"),
                Sucursal = Lector.Texto(r, "sucursal"),
                Empleado = Lector.Texto(r, "empleado")
            },
            ("@id", idPedido));

        var traza = cabecera.FirstOrDefault();
        if (traza is null) return null;

        traza.Despachos = await db.ConsultarAsync(
            "SELECT d.idDespacho, d.fechaDespacho, dd.idProd, o.idProducto, pr.nombre AS producto, dd.cantidad " +
            "FROM despacho d " +
            "JOIN detalle_despacho dd ON dd.idDespacho = d.idDespacho " +
            "JOIN ordenproduccion o ON o.idProd = dd.idProd " +
            "JOIN productos pr ON pr.idProducto = o.idProducto " +
            "WHERE d.idPedido = @id ORDER BY d.fechaDespacho, pr.nombre, o.fechaReal, dd.idProd",
            r => new TrazaDespachoFila(
                Lector.Int(r, "idDespacho"), Lector.Fecha(r, "fechaDespacho"), Lector.Int(r, "idProd"),
                Lector.Int(r, "idProducto"), Lector.Texto(r, "producto"), Lector.Int(r, "cantidad")),
            ("@id", idPedido));

        traza.Ordenes = await db.ConsultarAsync(
            SqlOrden +
            "WHERE o.idProd IN (SELECT dd.idProd FROM despacho d " +
            "                   JOIN detalle_despacho dd ON dd.idDespacho = d.idDespacho " +
            "                   WHERE d.idPedido = @id) " +
            "ORDER BY pr.nombre, o.fechaReal",
            MapOrden, ("@id", idPedido));

        traza.Consumos = await ConsumosAsync(traza.Ordenes.Select(o => o.IdProd).ToList());
        return traza;
    }

    public async Task<TrazabilidadOrdenDTO?> PorOrdenAsync(int idProd)
    {
        var orden = (await db.ConsultarAsync(SqlOrden + "WHERE o.idProd = @id", MapOrden, ("@id", idProd)))
            .FirstOrDefault();
        if (orden is null) return null;

        var traza = new TrazabilidadOrdenDTO
        {
            Orden = orden,
            Consumos = await ConsumosAsync(new List<int> { idProd })
        };

        traza.Despachos = await db.ConsultarAsync(
            "SELECT d.idPedido, d.idDespacho, d.fechaDespacho, SUM(dd.cantidad) AS cantidad, " +
            "       COALESCE(s.nombreSuc, '') AS sucursal " +
            "FROM detalle_despacho dd " +
            "JOIN despacho d ON d.idDespacho = dd.idDespacho " +
            "JOIN solicitudpedido sp ON sp.idPedido = d.idPedido " +
            "LEFT JOIN empleados e ON e.idEmpleado = sp.idEmpleado " +
            "LEFT JOIN sucursales s ON s.idSucursal = e.idSucursal " +
            "WHERE dd.idProd = @prod " +
            "GROUP BY d.idPedido, d.idDespacho, d.fechaDespacho, s.nombreSuc " +
            "ORDER BY d.fechaDespacho",
            r => new TrazaDespachoPosteriorFila(
                Lector.Int(r, "idPedido"), Lector.Int(r, "idDespacho"), Lector.Fecha(r, "fechaDespacho"),
                Lector.Int(r, "cantidad"), Lector.Texto(r, "sucursal")),
            ("@prod", idProd));

        return traza;
    }

    private async Task<List<TrazaConsumoFila>> ConsumosAsync(List<int> ordenes)
    {
        if (ordenes.Count == 0) return new List<TrazaConsumoFila>();

        // Solo se arman nombres de parámetros (@o0, @o1...); los valores viajan parametrizados
        var nombres = ordenes.Select((_, i) => "@o" + i).ToList();
        var parametros = ordenes.Select((id, i) => ("@o" + i, (object?)id)).ToArray();

        return await db.ConsultarAsync(
            "SELECT cl.idProd, mp.idMateriaP, mp.nombre AS materiaPrima, mp.unidad, cl.idLote, cl.cantConsumida, " +
            "       l.fechaIngreso, l.fechaVencimiento, COALESCE(pv.razonSocial, '') AS proveedor " +
            "FROM consumolote cl " +
            "JOIN lote l ON l.idLote = cl.idLote " +
            "JOIN materiap mp ON mp.idMateriaP = l.idMateriaP " +
            "LEFT JOIN proveedores pv ON pv.idProveedor = l.idProveedor " +
            "WHERE cl.idProd IN (" + string.Join(",", nombres) + ") " +
            "ORDER BY cl.idProd, mp.nombre, cl.idLote",
            r => new TrazaConsumoFila(
                Lector.Int(r, "idProd"), Lector.Int(r, "idMateriaP"), Lector.Texto(r, "materiaPrima"),
                Lector.Texto(r, "unidad"), Lector.Int(r, "idLote"), Lector.Decimal(r, "cantConsumida"),
                Lector.Fecha(r, "fechaIngreso"), Lector.Fecha(r, "fechaVencimiento"), Lector.Texto(r, "proveedor")),
            parametros);
    }
}

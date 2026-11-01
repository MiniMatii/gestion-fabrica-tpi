namespace Alemana.Web.Datos;

public class PedidoRepositorio(DbConexion db)
{
    /// <param name="estado">null (todos), "pendientes" (sin entrega real) o "entregados".</param>
    public Task<List<PedidoFila>> ListarAsync(string? texto, string? estado, DateTime? desde, DateTime? hasta)
    {
        var filtros = new Filtros()
            .Si(!string.IsNullOrWhiteSpace(texto),
                "(CAST(sp.idPedido AS CHAR) LIKE @texto OR e.nombre LIKE @texto OR e.apellido LIKE @texto)",
                ("@texto", Filtros.Like(texto ?? "")))
            .Si(estado == "pendientes", "sp.fechaReal IS NULL")
            .Si(estado == "entregados", "sp.fechaReal IS NOT NULL")
            .Si(desde is not null, "DATE(sp.fechaPedido) >= @desde", ("@desde", desde?.Date))
            .Si(hasta is not null, "DATE(sp.fechaPedido) <= @hasta", ("@hasta", hasta?.Date));

        var sql =
            "SELECT sp.idPedido, sp.fechaPedido, sp.estadoPedido, sp.fechaEstimada, sp.fechaReal, sp.idEmpleado, " +
            "       TRIM(CONCAT(COALESCE(e.nombre, ''), ' ', COALESCE(e.apellido, ''))) AS empleado, " +
            "       (SELECT COUNT(*) FROM detalle_pedido dp WHERE dp.idPedido = sp.idPedido) AS cantItems " +
            "FROM solicitudpedido sp " +
            "LEFT JOIN empleados e ON e.idEmpleado = sp.idEmpleado " +
            filtros.Where + " ORDER BY sp.fechaPedido DESC";

        return db.ConsultarAsync(sql, r => new PedidoFila(
                Lector.Int(r, "idPedido"),
                Lector.Fecha(r, "fechaPedido"),
                Lector.Texto(r, "estadoPedido"),
                Lector.FechaN(r, "fechaEstimada"),
                Lector.FechaN(r, "fechaReal"),
                Lector.Int(r, "idEmpleado"),
                Lector.Texto(r, "empleado"),
                Lector.Int(r, "cantItems")),
            filtros.Parametros);
    }
}

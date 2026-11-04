using Alemana.DTOs;

namespace Alemana.Data.Ado;

public class LoteAdoRepositorio(AdoConexion db)
{
    /// <param name="vencimiento">null (todos), "vencidos", "porVencer" (próximos 7 días) o "vigentes".</param>
    public Task<List<LoteFila>> ListarAsync(string? texto, int? estado, string? vencimiento)
    {
        var filtros = new Filtros()
            .Si(!string.IsNullOrWhiteSpace(texto),
                "(m.nombre LIKE @texto OR p.razonSocial LIKE @texto)",
                ("@texto", Filtros.Like(texto ?? "")))
            .Si(estado is not null, "l.estadoLote = @estado", ("@estado", estado))
            .Si(vencimiento == "vencidos", "DATE(l.fechaVencimiento) < CURDATE()")
            .Si(vencimiento == "porVencer",
                "DATE(l.fechaVencimiento) BETWEEN CURDATE() AND CURDATE() + INTERVAL 7 DAY")
            .Si(vencimiento == "vigentes", "DATE(l.fechaVencimiento) > CURDATE() + INTERVAL 7 DAY");

        var sql =
            "SELECT l.idLote, l.fechaIngreso, l.fechaVencimiento, l.cantidadLote, l.estadoLote, " +
            "       l.idProveedor, COALESCE(p.razonSocial, '') AS proveedor, " +
            "       l.idMateriaP, COALESCE(m.nombre, '') AS materiaPrima " +
            "FROM lote l " +
            "LEFT JOIN proveedores p ON p.idProveedor = l.idProveedor " +
            "LEFT JOIN materiap m ON m.idMateriaP = l.idMateriaP " +
            filtros.Where + " ORDER BY l.fechaVencimiento";

        return db.ConsultarAsync(sql, r => new LoteFila(
                Lector.Int(r, "idLote"),
                Lector.Fecha(r, "fechaIngreso"),
                Lector.Fecha(r, "fechaVencimiento"),
                Lector.Decimal(r, "cantidadLote"),
                Lector.IntN(r, "estadoLote"),
                Lector.Int(r, "idProveedor"),
                Lector.Texto(r, "proveedor"),
                Lector.Int(r, "idMateriaP"),
                Lector.Texto(r, "materiaPrima")),
            filtros.Parametros);
    }
}

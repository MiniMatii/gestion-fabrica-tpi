using Alemana.DTOs;

namespace Alemana.Data.Ado;

public class ProductoAdoRepositorio(AdoConexion db)
{
    public Task<List<ProductoFila>> ListarAsync(string? texto, bool? camara, bool? disponible)
    {
        var filtros = new Filtros()
            .Si(!string.IsNullOrWhiteSpace(texto), "p.nombre LIKE @texto", ("@texto", Filtros.Like(texto ?? "")))
            .Si(camara is not null, "p.camara = @camara", ("@camara", camara))
            .Si(disponible is not null, "p.disponible = @disp", ("@disp", disponible));

        var sql = "SELECT p.idProducto, p.nombre, p.idReceta, p.camara, p.disponible, p.StockActual " +
                  "FROM productos p " + filtros.Where + " ORDER BY p.nombre";

        return db.ConsultarAsync(sql, r => new ProductoFila(
                Lector.Int(r, "idProducto"),
                Lector.Texto(r, "nombre"),
                Lector.Int(r, "idReceta"),
                Lector.Bool(r, "camara"),
                Lector.BoolN(r, "disponible"),
                Lector.Int(r, "StockActual")),
            filtros.Parametros);
    }
}

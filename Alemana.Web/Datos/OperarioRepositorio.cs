using Alemana.DTOs;

namespace Alemana.Web.Datos;

public class OperarioRepositorio(DbConexion db)
{
    public Task<List<OperarioFila>> ListarAsync(string? texto, int? disponibilidad)
    {
        var filtros = new Filtros()
            .Si(!string.IsNullOrWhiteSpace(texto),
                "(nombre LIKE @texto OR apellido LIKE @texto)",
                ("@texto", Filtros.Like(texto ?? "")))
            .Si(disponibilidad is not null,
                "disponibilidad = @disp",
                ("@disp", disponibilidad));

        var sql = "SELECT idOperario, nombre, apellido, disponibilidad FROM operarios "
                  + filtros.Where + " ORDER BY apellido, nombre";

        return db.ConsultarAsync(sql, r => new OperarioFila(
                Lector.Int(r, "idOperario"),
                Lector.Texto(r, "nombre"),
                Lector.Texto(r, "apellido"),
                Lector.Int(r, "disponibilidad")),
            filtros.Parametros);
    }

    public Task<long> AltaAsync(OperariosDTO operario) =>
        db.EjecutarInsertAsync(
            "INSERT INTO operarios (nombre, apellido, disponibilidad) VALUES (@nombre, @apellido, @disp)",
            ("@nombre", operario.Nombre),
            ("@apellido", operario.Apellido),
            ("@disp", (int)operario.Disponibilidad));
}

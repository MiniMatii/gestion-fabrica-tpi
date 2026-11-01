using Alemana.DTOs;

namespace Alemana.Web.Datos;

public class SucursalRepositorio(DbConexion db)
{
    public Task<List<SucursalFila>> ListarAsync(string? texto, int? codPostal)
    {
        var filtros = new Filtros()
            .Si(!string.IsNullOrWhiteSpace(texto),
                "(s.nombreSuc LIKE @texto OR c.nombreCiudad LIKE @texto)",
                ("@texto", Filtros.Like(texto ?? "")))
            .Si(codPostal is not null, "s.codPostal = @cp", ("@cp", codPostal));

        var sql = "SELECT s.idSucursal, s.nombreSuc, s.codPostal, COALESCE(c.nombreCiudad, '') AS nombreCiudad " +
                  "FROM sucursales s " +
                  "LEFT JOIN ciudades c ON c.codPostal = s.codPostal " +
                  filtros.Where + " ORDER BY s.nombreSuc";

        return db.ConsultarAsync(sql, r => new SucursalFila(
                Lector.Int(r, "idSucursal"),
                Lector.Texto(r, "nombreSuc"),
                Lector.Int(r, "codPostal"),
                Lector.Texto(r, "nombreCiudad")),
            filtros.Parametros);
    }

    public Task<long> AltaAsync(SucursalesDTO sucursal) =>
        db.EjecutarInsertAsync(
            "INSERT INTO sucursales (nombreSuc, codPostal) VALUES (@nombre, @cp)",
            ("@nombre", sucursal.NombreSuc),
            ("@cp", sucursal.CodPostal));
}

using System.Data.Common;
using MySqlConnector;

namespace Alemana.Data.Ado;

/// <summary>
/// Acceso a MySQL con ADO.NET (MySqlConnector). Vive en la capa de datos:
/// solo la API lo usa; la interfaz web nunca se conecta a la base.
/// </summary>
public class AdoConexion
{
    private readonly string _cadena;

    public AdoConexion(string cadena)
    {
        _cadena = cadena ?? throw new ArgumentNullException(nameof(cadena));
    }

    public async Task<List<T>> ConsultarAsync<T>(string sql, Func<DbDataReader, T> mapear,
        params (string Nombre, object? Valor)[] parametros)
    {
        await using var cn = new MySqlConnection(_cadena);
        await cn.OpenAsync();
        await using var cmd = new MySqlCommand(sql, cn);
        foreach (var (nombre, valor) in parametros)
        {
            cmd.Parameters.AddWithValue(nombre, valor ?? DBNull.Value);
        }

        await using var lector = await cmd.ExecuteReaderAsync();
        var lista = new List<T>();
        while (await lector.ReadAsync())
        {
            lista.Add(mapear(lector));
        }
        return lista;
    }
}

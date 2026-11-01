using System.Data.Common;
using MySqlConnector;
using Microsoft.Extensions.Configuration;

namespace Alemana.Web.Datos;

public class DbConexion
{
    private readonly string _cadena;

    public DbConexion(IConfiguration configuracion)
    {
        _cadena = configuracion.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Falta ConnectionStrings:DefaultConnection en appsettings.json.");
    }

    public async Task<List<T>> ConsultarAsync<T>(string sql, Func<DbDataReader, T> mapear,
        params (string Nombre, object? Valor)[] parametros)
    {
        await using var cn = new MySqlConnection(_cadena);
        await cn.OpenAsync();
        await using var cmd = new MySqlCommand(sql, cn);
        AgregarParametros(cmd, parametros);

        await using var lector = await cmd.ExecuteReaderAsync();
        var lista = new List<T>();
        while (await lector.ReadAsync())
        {
            lista.Add(mapear(lector));
        }
        return lista;
    }
    public async Task<long> EjecutarInsertAsync(string sql, params (string Nombre, object? Valor)[] parametros)
    {
        await using var cn = new MySqlConnection(_cadena);
        await cn.OpenAsync();
        await using var cmd = new MySqlCommand(sql, cn);
        AgregarParametros(cmd, parametros);

        await cmd.ExecuteNonQueryAsync();
        return cmd.LastInsertedId;
    }

    private static void AgregarParametros(MySqlCommand cmd, (string Nombre, object? Valor)[] parametros)
    {
        foreach (var (nombre, valor) in parametros)
        {
            cmd.Parameters.AddWithValue(nombre, valor ?? DBNull.Value);
        }
    }
}

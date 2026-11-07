using System.Data.Common;

namespace Alemana.Data.Ado;

/// <summary>Lectura segura de columnas (maneja NULL y TINYINT(1) como bool o número).</summary>
public static class Lector
{
    public static int Int(DbDataReader r, string col) => Convert.ToInt32(r[col]);

    public static int? IntN(DbDataReader r, string col) =>
        r[col] is DBNull ? (int?)null : Convert.ToInt32(r[col]);

    public static string Texto(DbDataReader r, string col) => Convert.ToString(r[col]) ?? string.Empty;

    public static decimal Decimal(DbDataReader r, string col) => Convert.ToDecimal(r[col]);

    public static DateTime Fecha(DbDataReader r, string col) => Convert.ToDateTime(r[col]);

    public static DateTime? FechaN(DbDataReader r, string col) =>
        r[col] is DBNull ? (DateTime?)null : Convert.ToDateTime(r[col]);

    public static bool Bool(DbDataReader r, string col) => Convert.ToBoolean(r[col]);

    public static bool? BoolN(DbDataReader r, string col) =>
        r[col] is DBNull ? (bool?)null : Convert.ToBoolean(r[col]);
}

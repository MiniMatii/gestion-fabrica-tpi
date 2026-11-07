using System.Globalization;

namespace Alemana.Web.Filtros;

/// <summary>Arma la URL de un listado con filtros. Omite los valores vacíos o nulos.</summary>
public static class QueryString
{
    public static string Crear(string ruta, params (string Nombre, object? Valor)[] pares)
    {
        var partes = new List<string>();
        foreach (var (nombre, valor) in pares)
        {
            string? texto = valor switch
            {
                null => null,
                string s when string.IsNullOrWhiteSpace(s) => null,
                string s => s.Trim(),
                DateTime d => d.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                bool b => b ? "true" : "false",
                IFormattable f => f.ToString(null, CultureInfo.InvariantCulture),
                _ => valor.ToString()
            };

            if (texto is not null)
            {
                partes.Add($"{Uri.EscapeDataString(nombre)}={Uri.EscapeDataString(texto)}");
            }
        }
        return partes.Count == 0 ? ruta : ruta + "?" + string.Join("&", partes);
    }
}

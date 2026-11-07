namespace Alemana.Data.Ado;

/// <summary>
/// Arma la cláusula WHERE solo con los filtros que tienen valor.
/// Las cláusulas son constantes del código; los valores siempre viajan como parámetros.
/// </summary>
public sealed class Filtros
{
    private readonly List<string> _clausulas = new();
    private readonly List<(string Nombre, object? Valor)> _parametros = new();

    public Filtros Si(bool condicion, string clausula, params (string Nombre, object? Valor)[] parametros)
    {
        if (condicion)
        {
            _clausulas.Add(clausula);
            _parametros.AddRange(parametros);
        }
        return this;
    }

    public string Where => _clausulas.Count == 0
        ? string.Empty
        : "WHERE " + string.Join(" AND ", _clausulas);

    public (string Nombre, object? Valor)[] Parametros => _parametros.ToArray();

    public static string Like(string texto) => "%" + texto.Trim() + "%";
}

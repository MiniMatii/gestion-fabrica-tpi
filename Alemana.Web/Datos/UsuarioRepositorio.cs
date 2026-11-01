using Alemana.Web.Auth;

namespace Alemana.Web.Datos;

public class UsuarioRepositorio(DbConexion db)
{
    private const string SqlPorNombre =
        "SELECT idUsuario, usuario, claveHash, idEmpleado, idOperario " +
        "FROM usuarios WHERE usuario = @usuario LIMIT 1";

    /// <summary>Valida credenciales (BCrypt, igual que la API) y devuelve la sesión o null.</summary>
    public async Task<SesionUsuario?> ValidarAsync(string nombreUsuario, string clave)
    {
        if (string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrEmpty(clave))
        {
            return null;
        }

        var filas = await db.ConsultarAsync(SqlPorNombre, r => new UsuarioLogin(
                Lector.Int(r, "idUsuario"),
                Lector.Texto(r, "usuario"),
                Lector.Texto(r, "claveHash"),
                Lector.IntN(r, "idEmpleado"),
                Lector.IntN(r, "idOperario")),
            ("@usuario", nombreUsuario.Trim()));

        var usuario = filas.FirstOrDefault();
        if (usuario is null)
        {
            return null;
        }

        bool claveOk;
        try
        {
            claveOk = BCrypt.Net.BCrypt.Verify(clave, usuario.ClaveHash);
        }
        catch (Exception)
        {
            return null; // hash mal formado en la base
        }

        if (!claveOk)
        {
            return null;
        }

        var rol = usuario.IdEmpleado is not null ? "Empleado" : "Operario";
        return new SesionUsuario(usuario.IdUsuario, usuario.NombreUsuario, rol, usuario.IdOperario, usuario.IdEmpleado);
    }
}

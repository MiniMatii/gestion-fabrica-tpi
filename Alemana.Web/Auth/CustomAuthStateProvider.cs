using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace Alemana.Web.Auth;

/// <summary>
/// Autenticación basada en claims. La sesión se guarda cifrada en el navegador (ProtectedLocalStorage),
/// así no hace falta token JWT ni llamadas a la API.
/// </summary>
public class CustomAuthStateProvider(ProtectedLocalStorage almacen) : AuthenticationStateProvider
{
    private const string ClaveAlmacen = "sesionAlemana";

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            var resultado = await almacen.GetAsync<SesionUsuario>(ClaveAlmacen);
            if (!resultado.Success || resultado.Value is null)
            {
                return Anonimo();
            }
            return new AuthenticationState(CrearPrincipal(resultado.Value));
        }
        catch (InvalidOperationException)
        {
            // Prerenderizado: todavía no hay JavaScript disponible
            return Anonimo();
        }
        catch (Exception)
        {
            // Dato alterado o ilegible
            return Anonimo();
        }
    }

    public async Task IniciarSesionAsync(SesionUsuario sesion)
    {
        await almacen.SetAsync(ClaveAlmacen, sesion);
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(CrearPrincipal(sesion))));
    }

    public async Task CerrarSesionAsync()
    {
        await almacen.DeleteAsync(ClaveAlmacen);
        NotifyAuthenticationStateChanged(Task.FromResult(Anonimo()));
    }

    private static AuthenticationState Anonimo() => new(new ClaimsPrincipal(new ClaimsIdentity()));

    private static ClaimsPrincipal CrearPrincipal(SesionUsuario sesion)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, sesion.Nombre),
            new(ClaimTypes.Role, sesion.Rol),
            new(ClaimTypes.NameIdentifier, sesion.IdUsuario.ToString())
        };
        if (sesion.IdOperario is not null)
        {
            claims.Add(new Claim("operarioId", sesion.IdOperario.Value.ToString()));
        }
        if (sesion.IdEmpleado is not null)
        {
            claims.Add(new Claim("empleadoId", sesion.IdEmpleado.Value.ToString()));
        }

        var identidad = new ClaimsIdentity(claims, "sesion", ClaimTypes.Name, ClaimTypes.Role);
        return new ClaimsPrincipal(identidad);
    }
}

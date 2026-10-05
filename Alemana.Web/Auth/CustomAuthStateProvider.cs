using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Alemana.Web.Auth;

public class CustomAuthStateProvider : AuthenticationStateProvider
{
    private const string TokenKey = "authToken";
    private readonly ILocalStorageService _localStorage;

    private static AuthenticationState Anonimo() =>
        new(new ClaimsPrincipal(new ClaimsIdentity()));

    public CustomAuthStateProvider(ILocalStorageService localStorage)
        => _localStorage = localStorage;

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            var token = await _localStorage.GetItemAsync<string>(TokenKey);
            if (string.IsNullOrWhiteSpace(token))
                return Anonimo();

            var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);

            // Token vencido: se limpia y queda como anónimo
            if (jwt.ValidTo <= DateTime.UtcNow)
            {
                await _localStorage.RemoveItemAsync(TokenKey);
                return Anonimo();
            }

            return new AuthenticationState(CrearPrincipal(jwt));
        }
        catch (InvalidOperationException)
        {
            // Todavía no hay JavaScript disponible (prerenderizado)
            return Anonimo();
        }
        catch (Exception)
        {
            // Token mal formado
            return Anonimo();
        }
    }

    public void MarcarUsuarioComoAutenticado(string token)
    {
        var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
        NotifyAuthenticationStateChanged(
            Task.FromResult(new AuthenticationState(CrearPrincipal(jwt))));
    }

    public async Task MarcarUsuarioComoDesconectadoAsync()
    {
        await _localStorage.RemoveItemAsync(TokenKey);
        NotifyAuthenticationStateChanged(Task.FromResult(Anonimo()));
    }

    private static ClaimsPrincipal CrearPrincipal(JwtSecurityToken jwt)
    {
        var claims = jwt.Claims.Select(c => c.Type switch
        {
            "unique_name" => new Claim(ClaimTypes.Name, c.Value),
            "role" => new Claim(ClaimTypes.Role, c.Value),
            "nameid" => new Claim(ClaimTypes.NameIdentifier, c.Value),
            _ => c   // los que ya vienen con nombre largo pasan tal cual
        }).ToList();

        var identity = new ClaimsIdentity(claims, "jwt", ClaimTypes.Name, ClaimTypes.Role);
        return new ClaimsPrincipal(identity);
    }
}
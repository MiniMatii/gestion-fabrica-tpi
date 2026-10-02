using Alemana.Aplicaciones.Servicios;
using Alemana.Data.Repositorios;
using Alemana.DTOs;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace SwaggerWeb
{
    public static class AuthEndpoint
    {
        public static void MapAuthEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/api/auth/login", async (LoginDTO dto, IUsuarioServicio usuarios, IConfiguration config) =>
            {
                var usuario = await usuarios.Validar(dto.Usuario, dto.Clave);
                if (usuario is null) return Results.Unauthorized();

                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, usuario.Nombre),
                    new Claim(ClaimTypes.Role, usuario.Rol)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!));
                var token = new JwtSecurityToken(
                    config["Jwt:Issuer"], config["Jwt:Audience"], claims,
                    expires: DateTime.UtcNow.AddHours(2),
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

                return Results.Ok(new LoginRespuestaDTO
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Usuario = usuario.Nombre,
                    Rol = usuario.Rol
                });
            }).AllowAnonymous();




        }
    }
}

    

using Alemana.Aplicaciones.Servicios;
using Alemana.Data.Repositorios;
using Alemana.DTOs;
using Microsoft.IdentityModel.Tokens;
using System;
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

                var claims = new List<Claim>
                {
                    new(ClaimTypes.Name, usuario.Nombre),
                    new(ClaimTypes.Role, usuario.Rol)
                };
                if (usuario.IdOperario.HasValue)
                    claims.Add(new Claim("operarioId", usuario.IdOperario.Value.ToString()));
                if (usuario.IdEmpleado.HasValue)
                    claims.Add(new Claim("empleadoId", usuario.IdEmpleado.Value.ToString()));

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




            app.MapPost("/auth/registrar", async (LoginDTO dto, IUsuarioServicio svc) =>
            {
                try
                {
                    var id = await svc.RegistrarAsync(dto);
                    return Results.Created($"/auth/usuarios/{id}", new { id });
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(ex.Message);
                }
                catch (InvalidOperationException ex)
                {
                    return Results.Conflict(ex.Message);
                }
            }).AllowAnonymous();
        }


    
    }
}

    

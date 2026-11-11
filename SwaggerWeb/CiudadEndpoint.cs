
using Alemana.Aplicaciones.Servicios;
using Alemana.DTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace SwaggerWeb
{
    public static class CiudadesEndpoint
    {
        public static void MapCiudadesEndpoint(this WebApplication app)
        {
            app.MapPost("/ciudades", async (
                CiudadesDTO dto,
                ICiudadServicio ciudadServicio) =>
            {
                try
                {
                    var ciudad = await ciudadServicio.AltaCiudad(dto);

                    return Results.Created(
                        $"/ciudades/{ciudad.CodPostal}",
                        ciudad
                    );
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            }).WithName("Alta Ciudad")
            .WithTags("Ciudades")
            .Produces<CiudadesDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapGet("/ciudades/{id}", async (int id, ICiudadServicio ciudadServicio) =>
            {
                try
                {
                    var laC = await ciudadServicio.BuscarCiudad(id);
                    if (laC is not null)
                    {
                        return Results.Ok(laC);
                    }
                    return Results.NotFound();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            }).WithName("Buscar Ciudad")
            .WithTags("Ciudades")
            .Produces<CiudadesDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapGet("/ciudades", async (ICiudadServicio ciudadServicio) =>
            {
                var lasc = await ciudadServicio.BuscarTodas();
                return Results.Ok(lasc);
            }
            )
            .WithName("Buscar todas las ciudades")
            .WithTags("Ciudades")
            .Produces<List<CiudadesDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapDelete("/ciudades/{id}", async (int id, ICiudadServicio ciudadServicio) =>
            {
                try
                {
                    var borrada = await ciudadServicio.BorrarCiudad(id);
                    return borrada
                        ? Results.NoContent()
                        : Results.NotFound(new { error = "La ciudad no existe." });
                }
                catch (DbUpdateException)
                {
                    return Results.Conflict(new { error = "No se puede eliminar: hay sucursales asociadas a esa ciudad." });
                }
            })
            .WithName("Borrar Ciudad")
            .WithTags("Ciudades")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status409Conflict)
            .WithOpenApi();


        }
    }
}
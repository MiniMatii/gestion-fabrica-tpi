using Alemana.DTOs;
using Alemana.Aplicaciones.Servicios;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Components;

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
            .Produces<CiudadesDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapGet("/ciudades/{id}", async (int id, ICiudadServicio ciudadServicio) =>
            {
                try
                {
                    var laC = await ciudadServicio.BuscarCiudad(id);
                    if(laC is not null)
                    {
                        return Results.Ok(laC);
                    }
                    return Results.NotFound();
                }
                catch(ArgumentException ex) 
                {
                    return Results.BadRequest(new {error= ex.Message});
                }
            }).WithName("Buscar Ciudad")
            .Produces<CiudadesDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapGet("/ciudades", async (ICiudadServicio ciudadServicio) =>
            {
                var lasc = await ciudadServicio.BuscarTodas();
                return Results.Ok(lasc);
            }
            ).WithName("Buscar todas las ciudades")
            .Produces<List<CiudadesDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();
        }
    }
}

using Alemana.DTOs;
using Alemana.Aplicaciones.Servicios;
using System.Runtime.CompilerServices;

namespace SwaggerWeb
{
    public static class CiudadesEndpoint
    {
        public static void MapCiudadesEndpoint(this WebApplication app)
        {
            app.MapPost("/ciudad", async (
                CiudadesDTO dto,
                ICiudadServicio ciudadServicio) =>
            {
                try
                {
                    var ciudad = await ciudadServicio.AltaCiudad(dto);

                    return Results.Created(
                        $"/ciudad/{ciudad.CodPostal}",
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

            app.MapPut("/ciudad/{codPostal}/sucursales",async (int codPostal, List<int> idSucursales, ICiudadServicio ciudadServicio) =>
            {
                try
                {
                    var ciudad = await ciudadServicio.AgregarSucursal(
                        codPostal,
                        idSucursales
                    );

                    if (ciudad is null)
                    {
                        return Results.NotFound();
                    }

                    return Results.Ok(ciudad);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            }).WithName("Agregar Sucursales")
        .Produces<CiudadesDTO>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status400BadRequest)
        .Produces(StatusCodes.Status404NotFound)
        .WithOpenApi();


        }
    }
}

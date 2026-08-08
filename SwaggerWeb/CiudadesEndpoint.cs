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


        }
    }
}

using Alemana.DTOs;
using Alemana.Aplicaciones.Servicios;


namespace SwaggerWeb
{
    public static class CapacidadesEndpoint
    {

        public static void MapCapacidadesEndpoint(this WebApplication app)
        {
            app.MapPost("/capacidad", async (CapacidadDTO dto, ICapacidadServicio capacidadServicio) =>
            {
                try
                {
                    CapacidadDTO capacidadDto = await capacidadServicio.AltaCapacidad(dto);
                    return Results.Created($"/capacidad/{capacidadDto.IdCap}", capacidadDto);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            }).WithName("Alta Capacidad")
            .WithTags("Capacidades")
            .Produces<CapacidadDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapDelete("/capacidad/{id}", async (int id, ICapacidadServicio capacidadServicio) =>
            {
                try
                {
                    await capacidadServicio.BorrarCapacidad(id);
                    return Results.Ok();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            }
            ).WithName("Borrar Capacidad")
            .WithTags("Capacidades")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            

        }
    }
}

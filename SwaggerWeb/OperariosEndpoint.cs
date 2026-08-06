using Alemana.DTOs;
using Alemana.Aplicaciones.Servicios;


namespace SwaggerWeb
{
    public static class OperariosEndpoint
    {
        public static void MapOperariosEndpoint(this WebApplication app) 
        {

            app.MapPost("/operario", async (OperariosDTO dto, IOperarioServicios operarioServicios) =>
            {
                try
                {
                    OperariosDTO operarioDto = await operarioServicios.AltaOperario(dto);
                    return Results.Created($"/operario/{operarioDto.IdOperario}", operarioDto);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            }).WithName("Alta Operario")
            .Produces<OperariosDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/operario/{idOperario}/capacidad", async (int idOperario, List<int> caps, IOperarioServicios operarioServicios) =>
            {
                try
                {
                    OperariosDTO operarioDto = await operarioServicios.AsignarCapacidad(idOperario, caps);
                    return Results.Ok(operarioDto);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            }).WithName("Asignar Capacidad")
            .Produces<OperariosDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/operario/{idOperario}", async (int idOperario, IOperarioServicios operarioServicios) => 
            {
                try 
                { 
                    OperariosDTO operarioDto = await operarioServicios.ModificarOperario(idOperario);
                    return Results.Ok(operarioDto);
                } 
                catch (ArgumentException ex) 
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            }).WithName("Modificar Operario")
            .Produces<OperariosDTO>(StatusCodes.Status202Accepted)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();



        }


    }
}

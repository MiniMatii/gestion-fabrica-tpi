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

            app.MapPut("/operario/{idOperario}", async (OperariosDTO dto, IOperarioServicios operarioServicios) => 
            {
                try
                {
                    var rta = await operarioServicios.ModificarOperario(dto);

                    if (!rta)
                    {
                        return Results.NotFound();
                    }

                    return Results.NoContent();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            }).WithName("Modificar Operario")
            .Produces<OperariosDTO>(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();


            app.MapGet("/operarios/", async (IOperarioServicios operarioServicios)  =>
            {
                var resultado = await operarioServicios.ObtenerTodos();
                return Results.Ok(resultado);
            }).WithName("Obtener Todos los Operarios")
            .Produces<IEnumerable<OperariosDTO>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();


            app.MapDelete("/operario/{idOperario}", async (int idOperario, IOperarioServicios operarioServicios) =>
            {
                try
                {
                    var rta = await operarioServicios.EliminarOperario(idOperario);
                    if (!rta)
                    {
                        return Results.NotFound();
                    }
                    return Results.NoContent();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            }).WithName("Eliminar Operario")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapDelete("/operario/{idOperario}/capacidad/{idCapacidad}", async (int idOperario, int idCapacidad, IOperarioServicios operarioServicios) =>
            {
                try
                {
                    OperariosDTO operarioDto = await operarioServicios.EliminarCapacidadOperario(idOperario, idCapacidad);
                    if (operarioDto == null)
                    {
                        return Results.NotFound();
                    }
                    return Results.Ok(operarioDto);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            }).WithName("Eliminar Capacidad de Operario")
            .Produces<OperariosDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();
        }


    }
}

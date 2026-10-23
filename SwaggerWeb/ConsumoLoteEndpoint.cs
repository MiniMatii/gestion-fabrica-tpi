using Alemana.Aplicaciones.Servicios;
using Alemana.DTOs;

namespace SwaggerWeb
{
    public static class ConsumoLoteEndpoint
    {
        public static void MapConsumoLoteEndpoint(this WebApplication app)
        {
            app.MapGet("/consumolote", async (IConsumoLoteServicio servicio) =>
            {
                var resultados = await servicio.ObtenerTodos();
                return Results.Ok(resultados);
            })
            .WithName("ObtenerConsumosLote")
            .WithTags("ConsumoLote")
            .Produces<List<ConsumoLoteDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapGet("/consumolote/orden/{idProd:int}", async (int idProd, IConsumoLoteServicio servicio) =>
            {
                var resultados = await servicio.ObtenerPorOrden(idProd);
                if (resultados == null) return Results.NotFound(new { error = "La orden de producción no existe." });
                return Results.Ok(resultados);
            })
            .WithName("ObtenerConsumosLotePorOrden")
            .WithTags("ConsumoLote")
            .Produces<List<ConsumoLoteDTO>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/consumolote/{id:int}", async (int id, IConsumoLoteServicio servicio) =>
            {
                var resultado = await servicio.ObtenerPorId(id);
                if (resultado == null) return Results.NotFound();
                return Results.Ok(resultado);
            })
            .WithName("ObtenerConsumoLotePorId")
            .WithTags("ConsumoLote")
            .Produces<ConsumoLoteDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapPost("/consumolote", async (ConsumoLoteDTO dto, IConsumoLoteServicio servicio) =>
            {
                try
                {
                    var agregado = await servicio.Agregar(dto);
                    return Results.Created($"/consumolote/{agregado.IdConsumo}", agregado);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AgregarConsumoLote")
            .WithTags("ConsumoLote")
            .Produces<ConsumoLoteDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/consumolote", async (ConsumoLoteDTO dto, IConsumoLoteServicio servicio) =>
            {
                try
                {
                    var actualizado = await servicio.Actualizar(dto);
                    if (!actualizado) return Results.NotFound();
                    return Results.Ok(true);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("ActualizarConsumoLote")
            .WithTags("ConsumoLote")
            .Produces<bool>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapDelete("/consumolote/{id:int}", async (int id, IConsumoLoteServicio servicio) =>
            {
                var eliminado = await servicio.Eliminar(id);
                if (!eliminado) return Results.NotFound();
                return Results.Ok(true);
            })
            .WithName("EliminarConsumoLote")
            .WithTags("ConsumoLote")
            .Produces<bool>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();
        }
    }
}

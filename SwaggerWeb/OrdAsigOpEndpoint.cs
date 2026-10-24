using Alemana.Aplicaciones.Servicios;
using Alemana.DTOs;

namespace SwaggerWeb
{
    public static class OrdAsigOpEndpoint
    {
        public static void MapOrdAsigOpEndpoint(this WebApplication app)
        {
            app.MapGet("/ordasigop", async (IOrdAsigOpServicio servicio) =>
            {
                var resultados = await servicio.ObtenerTodas();
                return Results.Ok(resultados);
            })
            .WithName("ObtenerAsignaciones")
            .WithTags("OrdAsigOp")
            .Produces<List<OrdAsigOpDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapGet("/ordasigop/orden/{idProd:int}", async (int idProd, IOrdAsigOpServicio servicio) =>
            {
                var resultados = await servicio.ObtenerPorOrden(idProd);
                if (resultados == null) return Results.NotFound(new { error = "La orden de producción no existe." });
                return Results.Ok(resultados);
            })
            .WithName("ObtenerAsignacionesPorOrden")
            .WithTags("OrdAsigOp")
            .Produces<List<OrdAsigOpDTO>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/ordasigop/{idProd:int}/{idOperario:int}", async (int idProd, int idOperario, IOrdAsigOpServicio servicio) =>
            {
                var resultado = await servicio.ObtenerPorId(idProd, idOperario);
                if (resultado == null) return Results.NotFound();
                return Results.Ok(resultado);
            })
            .WithName("ObtenerAsignacionPorId")
            .WithTags("OrdAsigOp")
            .Produces<OrdAsigOpDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapPost("/ordasigop", async (OrdAsigOpDTO dto, IOrdAsigOpServicio servicio) =>
            {
                try
                {
                    var agregada = await servicio.Agregar(dto);
                    return Results.Created($"/ordasigop/{agregada.IdProd}/{agregada.IdOperario}", agregada);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
                catch (InvalidOperationException ex)
                {
                    return Results.Conflict(new { error = ex.Message });
                }
            })
            .WithName("AgregarAsignacion")
            .WithTags("OrdAsigOp")
            .Produces<OrdAsigOpDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status409Conflict)
            .WithOpenApi();

            app.MapPut("/ordasigop", async (OrdAsigOpDTO dto, IOrdAsigOpServicio servicio) =>
            {
                try
                {
                    var actualizada = await servicio.Actualizar(dto);
                    if (!actualizada) return Results.NotFound();
                    return Results.Ok(true);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("ActualizarAsignacion")
            .WithTags("OrdAsigOp")
            .Produces<bool>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapDelete("/ordasigop/{idProd:int}/{idOperario:int}", async (int idProd, int idOperario, IOrdAsigOpServicio servicio) =>
            {
                var eliminada = await servicio.Eliminar(idProd, idOperario);
                if (!eliminada) return Results.NotFound();
                return Results.Ok(true);
            })
            .WithName("EliminarAsignacion")
            .WithTags("OrdAsigOp")
            .Produces<bool>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();
        }
    }
}

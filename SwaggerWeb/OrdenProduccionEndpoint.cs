using Alemana.Aplicaciones.Servicios;
using Alemana.DTOs;

namespace SwaggerWeb
{
    public static class OrdenProduccionEndpoint
    {
        public static void MapOrdenProduccionEndpoint(this WebApplication app)
        {
            app.MapGet("/ordenproduccion", async (IOrdenProduccionServicio servicio) =>
            {
                var resultados = await servicio.ObtenerTodas();
                return Results.Ok(resultados);
            })
            .WithName("ObtenerOrdenesProduccion")
            .WithTags("OrdenProduccion")
            .Produces<List<OrdenProduccionDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapGet("/ordenproduccion/{id}", async (int id, IOrdenProduccionServicio servicio) =>
            {
                var resultado = await servicio.ObtenerPorId(id);
                if (resultado == null) return Results.NotFound();
                return Results.Ok(resultado);
            })
            .WithName("ObtenerOrdenProduccionPorId")
            .WithTags("OrdenProduccion")
            .Produces<OrdenProduccionDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapPost("/ordenproduccion", async (OrdenProduccionDTO dto, IOrdenProduccionServicio servicio) =>
            {
                try
                {
                    var agregada = await servicio.Agregar(dto);
                    return Results.Created($"/ordenproduccion/{agregada.IdProd}", agregada);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AgregarOrdenProduccion")
            .WithTags("OrdenProduccion")
            .Produces<OrdenProduccionDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/ordenproduccion", async (OrdenProduccionDTO dto, IOrdenProduccionServicio servicio) =>
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
            .WithName("ActualizarOrdenProduccion")
            .WithTags("OrdenProduccion")
            .Produces<bool>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapDelete("/ordenproduccion/{id}", async (int id, IOrdenProduccionServicio servicio) =>
            {
                try
                {
                    var eliminado = await servicio.Eliminar(id);
                    if (!eliminado) return Results.NotFound();
                    return Results.Ok(true);
                }
                catch (InvalidOperationException ex)
                {
                    return Results.Conflict(new { error = ex.Message });
                }
            })
            .WithName("EliminarOrdenProduccion")
            .WithTags("OrdenProduccion")
            .Produces<bool>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status409Conflict)
            .WithOpenApi();
        }
    }
}

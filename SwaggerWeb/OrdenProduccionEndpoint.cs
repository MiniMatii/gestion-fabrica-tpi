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
            .AllowAnonymous()
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
            .AllowAnonymous()
            .WithOpenApi();

            app.MapGet("/ordenproduccion/produccion", async (IOrdenProduccionServicio servicio) =>
            Results.Ok(await servicio.ObtenerProduccionAsync()))
            .WithName("ObtenerOrdenProduccionesPendientes")
            .WithTags("OrdenProduccion")
            .AllowAnonymous()
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
            .AllowAnonymous()
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
            .AllowAnonymous()
            .WithOpenApi();

            // Calcula la materia prima necesaria para producir una cantidad (no consume nada)
            app.MapPost("/ordenproduccion/calcular", async (CalcularProduccionDTO dto, IOrdenProduccionServicio servicio) =>
            {
                try
                {
                    return Results.Ok(await servicio.CalcularAsync(dto));
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("CalcularProduccion")
            .WithTags("OrdenProduccion")
            .WithOpenApi();

            // Operarios capaces de producir la orden
            app.MapGet("/ordenproduccion/{id:int}/operarios", async (int id, IOrdenProduccionServicio servicio) =>
            {
                var operarios = await servicio.ObtenerOperariosCapacesAsync(id);
                return operarios is null ? Results.NotFound() : Results.Ok(operarios);
            })
            .WithName("OperariosCapacesOrden")
            .WithTags("OrdenProduccion")
            .WithOpenApi();

            // Confirma la orden: asigna operario, consume materia prima y la pasa a En Proceso
            app.MapPost("/ordenproduccion/{id:int}/confirmar",
                async (int id, ConfirmarOrdenDTO dto, IOrdenProduccionServicio servicio) =>
                {
                    var (resultado, mensaje) = await servicio.ConfirmarAsync(id, dto.IdOperario);
                    IResult respuesta = resultado switch
                    {
                        ResultadoConfirmacion.Ok => Results.NoContent(),
                        ResultadoConfirmacion.NoExiste => Results.NotFound(),
                        ResultadoConfirmacion.NoPendiente => Results.Conflict(mensaje),
                        ResultadoConfirmacion.StockInsuficiente => Results.UnprocessableEntity(mensaje),
                        _ => Results.BadRequest(mensaje)
                    };
                    return respuesta;
                })
                .WithName("ConfirmarOrdenProduccion")
                .WithTags("OrdenProduccion")
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
            .AllowAnonymous()
            .WithOpenApi();
        }
    }
}

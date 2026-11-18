using Alemana.Aplicaciones.Servicios;
using Alemana.DTOs;

namespace SwaggerWeb
{
    public static class SolicitudPedidoEndpoint
    {
        private static IResult RespuestaAceptacion(ResultadoAceptarPedido resultado, string? mensaje, ResultadoAceptacionPedidoDTO? datos) =>
            resultado switch
            {
                ResultadoAceptarPedido.Ok => Results.Ok(datos),
                ResultadoAceptarPedido.NoExiste => Results.NotFound(),
                ResultadoAceptarPedido.NoPendiente => Results.Conflict(mensaje),
                _ => Results.UnprocessableEntity(mensaje)
            };

        public static void MapSolicitudPedidoEndpoint(this WebApplication app)
        {
            app.MapGet("/pedidos", async (ISolicitudPedidoServicio servicio) =>
            {
                var pedidos = await servicio.ObtenerTodos();
                return Results.Ok(pedidos);
            }).WithName("Obtener Pedidos")
              .WithTags("Pedidos")
              .AllowAnonymous()
              .WithOpenApi();

            app.MapGet("/pedidos/{id}", async (int id, ISolicitudPedidoServicio servicio) =>
            {
                var pedido = await servicio.ObtenerPorId(id);
                if (pedido == null) return Results.NotFound(new { mensaje = "Pedido no encontrado" });
                return Results.Ok(pedido);
            }).WithName("Obtener Pedido Por Id")
              .WithTags("Pedidos")
              .AllowAnonymous()
              .WithOpenApi();

            app.MapPost("/pedidos", async (SolicitudPedidoDTO dto, ISolicitudPedidoServicio servicio) =>
            {
                try
                {
                    var nuevoPedido = await servicio.AltaPedido(dto);
                    return Results.Created($"/pedidos/{nuevoPedido.IdPedido}", nuevoPedido);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            }).WithName("Alta Pedido")
              .WithTags("Pedidos")
              .Produces<SolicitudPedidoDTO>(StatusCodes.Status201Created)
              .Produces(StatusCodes.Status400BadRequest)
              .AllowAnonymous()
              .WithOpenApi();

            app.MapDelete("/pedidos/{id}", async (int id, ISolicitudPedidoServicio servicio) =>
            {
                var eliminado = await servicio.EliminarPedido(id);
                if (!eliminado) return Results.NotFound();
                return Results.NoContent();
            }).WithName("Eliminar Pedido")
              .WithTags("Pedidos")
              .Produces(StatusCodes.Status204NoContent)
              .Produces(StatusCodes.Status404NotFound)
              .AllowAnonymous()
              .WithOpenApi();

            app.MapGet("/pedidos/{id:int}/productos", async (int id, ISolicitudPedidoServicio servicio) =>
            {
                var productos = await servicio.ObtenerProductosDePedidoAsync(id);
                return Results.Ok(productos);
            })
            .WithName("Obtener Productos De Pedido")
            .WithTags("Pedidos")
            .AllowAnonymous()
            .WithOpenApi();

            app.MapGet("/pedidos/pendientes", async (ISolicitudPedidoServicio servicio) =>
               Results.Ok(await servicio.ObtenerPendientesAsync()))
                .WithTags("Pedidos")
                .AllowAnonymous()
                .WithOpenApi();

            app.MapGet("/pedidos/desde/{ultimoId:int}", async (int ultimoId, ISolicitudPedidoServicio servicio) =>
                Results.Ok(await servicio.ObtenerPendientesDesdeAsync(ultimoId)))
                .WithTags("Pedidos")
                .AllowAnonymous()
                .WithOpenApi();

            // Productos del pedido con cantidad pedida y stock, para el menú de aceptación
            app.MapGet("/pedidos/{id:int}/aceptacion", async (int id, ISolicitudPedidoServicio servicio) =>
            {
                var items = await servicio.ObtenerItemsAceptacionAsync(id);
                return items is null ? Results.NotFound() : Results.Ok(items);
            })
            .WithName("Items de aceptacion")
            .WithTags("Pedidos")
            .WithOpenApi();

            // El responsable acepta una cantidad por producto. Lo que falta queda pendiente de producción
            app.MapPost("/pedidos/{id:int}/aceptar",
                async (int id, AceptarPedidoProductosDTO dto, ISolicitudPedidoServicio servicio) =>
                {
                    var (resultado, mensaje, datos) = await servicio.AceptarPedidoAsync(id, dto);
                    return RespuestaAceptacion(resultado, mensaje, datos);
                })
                .WithName("Aceptar pedido")
                .WithTags("Pedidos")
                .WithOpenApi();

            // Despacha lo pendiente de producción que ya haya en stock
            app.MapPost("/pedidos/{id:int}/despachar-pendientes",
                async (int id, ISolicitudPedidoServicio servicio) =>
                {
                    var (resultado, mensaje, datos) = await servicio.DespacharPendientesAsync(id);
                    return RespuestaAceptacion(resultado, mensaje, datos);
                })
                .WithName("Despachar pendientes")
                .WithTags("Pedidos")
                .WithOpenApi();
        }
    }
}

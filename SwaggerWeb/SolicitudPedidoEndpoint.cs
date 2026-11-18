using Alemana.Aplicaciones.Servicios;
using Alemana.DTOs;

namespace SwaggerWeb
{
    public static class SolicitudPedidoEndpoint
    {
        static IResult Responder(ResultadoPedido r, string? msg, ResultadoPedidoDTO? datos) => r switch
        {
            ResultadoPedido.Ok => Results.Ok(datos),
            ResultadoPedido.NoExiste => Results.NotFound(),
            ResultadoPedido.YaCompletado => Results.Conflict(msg),
            _ => Results.UnprocessableEntity(msg)
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

            app.MapGet("/pedidos/{id:int}/items", async (int id, ISolicitudPedidoServicio s) =>
            {
                var items = await s.ObtenerItemsAsync(id);
                return items is null ? Results.NotFound() : Results.Ok(items);
            }).WithTags("Pedidos").WithOpenApi();

            app.MapPost("/pedidos/{id:int}/aceptar", async (int id, AceptarPedidoProductosDTO dto, ISolicitudPedidoServicio s) =>
            {
                var (r, m, d) = await s.AceptarAsync(id, dto);
                return Responder(r, m, d);
            }).WithTags("Pedidos").WithOpenApi();


            app.MapPost("/pedidos/{id:int}/despachos", async (int id, DespacharPedidoDTO dto, ISolicitudPedidoServicio s) =>
            {
                var (r, m, d) = await s.DespacharAsync(id, dto);
                return Responder(r, m, d);
            }).WithTags("Pedidos").WithOpenApi();
        }
    }
}

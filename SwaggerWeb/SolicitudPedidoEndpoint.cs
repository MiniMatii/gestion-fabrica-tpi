using Alemana.Aplicaciones.Servicios;
using Alemana.DTOs;

namespace SwaggerWeb
{
    public static class SolicitudPedidoEndpoint
    {
        public static void MapSolicitudPedidoEndpoint(this WebApplication app)
        {
            app.MapGet("/pedidos", async (ISolicitudPedidoServicio servicio) =>
            {
                var pedidos = await servicio.ObtenerTodos();
                return Results.Ok(pedidos);
            }).WithName("Obtener Pedidos")
              .WithTags("Pedidos")
              .WithOpenApi();

            app.MapGet("/pedidos/{id}", async (int id, ISolicitudPedidoServicio servicio) =>
            {
                var pedido = await servicio.ObtenerPorId(id);
                if (pedido == null) return Results.NotFound(new { mensaje = "Pedido no encontrado" });

                return Results.Ok(pedido);
            }).WithName("Obtener Pedido Por Id")
              .WithTags("Pedidos")
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
              .WithOpenApi();
        }
    }
}
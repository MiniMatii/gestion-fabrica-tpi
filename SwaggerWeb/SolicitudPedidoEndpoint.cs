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



            app.MapGet("/pedidos/{id:int}/productos", async (int id, ISolicitudPedidoServicio servicio) =>
            {
                var productos = await servicio.ObtenerProductosDePedidoAsync(id);
                return Results.Ok(productos);
            })
            .WithName("Obtener Productos De Pedido")
            .WithTags("Pedidos")
            .WithOpenApi();

            app.MapGet("/pedidos/pendientes", async (ISolicitudPedidoServicio servicio) =>
               Results.Ok(await servicio.ObtenerPendientesAsync()))
                .WithTags("Pedidos")
                .WithOpenApi();


            app.MapGet("/pedidos/desde/{ultimoId:int}", async (int ultimoId, ISolicitudPedidoServicio servicio) =>
                Results.Ok(await servicio.ObtenerPendientesDesdeAsync(ultimoId)))
                .WithTags("Pedidos")
                .WithOpenApi();

            app.MapGet("/pedidos/{id:int}/asignables", async (int id, ISolicitudPedidoServicio servicio) =>
            {
                var items = await servicio.ObtenerItemsAsignablesAsync(id);
                return items is null ? Results.NotFound() : Results.Ok(items);
            })
            .WithTags("Pedidos")
            .WithOpenApi();

            app.MapPost("/pedidos/{id:int}/aceptar",
                async (int id, AceptarPedidoDTO dto, ISolicitudPedidoServicio servicio) =>
                {
                    var (resultado, mensaje) = await servicio.AceptarPedidoAsync(id, dto);

                    IResult respuesta = resultado switch
                    {
                        ResultadoAceptacion.Ok => Results.NoContent(),
                        ResultadoAceptacion.NoExiste => Results.NotFound(),
                        ResultadoAceptacion.NoPendiente => Results.Conflict(mensaje),
                        ResultadoAceptacion.StockInsuficiente => Results.UnprocessableEntity(mensaje),   
                        _ => Results.BadRequest(mensaje)
                    };
                    return respuesta;
                })
                .WithTags("Pedidos")
            .WithOpenApi();
        }



    }
}
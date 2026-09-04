using Alemana.Aplicaciones.Servicios;
using Alemana.DTOs;


namespace SwaggerWeb
{
    public static class ProductoEndpoint
    {

        public static void MapProductoEndpoint(this WebApplication app)
        {
            app.MapPost("/producto", async (ProductoDTO productoDTO, IProductoServicio productoServicio) =>
            {
                try
                {

                    var productoAgregado = await productoServicio.AgregarProducto(productoDTO);
                    return Results.Created($"/producto/{productoAgregado.IdProducto}", productoAgregado);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(ex.Message);
                }

            }).WithName("AgregarProducto")
            .WithTags("Producto")
            .Produces<ProductoDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/producto/baja", async (int id, IProductoServicio productoServicio) =>
            {
                try
                {
                    var productoBaja = await productoServicio.BajaProducto(id);

                    return Results.Ok(productoBaja);
                }
                catch (ArgumentException ex) 
                {
                    return Results.BadRequest(ex.Message);
                }
            }).WithName("BajaProducto")
            .WithTags("Producto")
            .Produces<ProductoDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapDelete("/producto/{id}", async (int id, IProductoServicio productoServicio) => 
            {
                try 
                { 
                    var result = await productoServicio.EliminarProducto(id);
                    return Results.Ok(result);
                } catch (ArgumentException ex) 
                {
                    return Results.BadRequest(ex.Message);
                }
            }).WithName("EliminarProducto")
            .WithTags("Producto")
            .Produces<bool>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/producto/", async (ProductoDTO dto, IProductoServicio productoServicio) =>
            {
                try
                {
                    var productoAct = await productoServicio.ActualizarProducto(dto);
                    return Results.Ok(productoAct);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            }).WithName("Actualizar Producto")
            .WithTags("Producto")
            .Produces<bool>(StatusCodes.Status202Accepted)
            .Produces(StatusCodes.Status400BadRequest).WithOpenApi();
        }

    }
}

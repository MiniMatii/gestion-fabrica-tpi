using Alemana.Aplicaciones.Servicios;
using Alemana.DTOs;


namespace SwaggerWeb
{
    public static class ProductoEndpoint
    {

        public static void MapProductoEndpoint(this WebApplication app)
        {
            app.MapGet("/producto", async (IProductoServicio productoServicio) =>
            {
                var productos = await productoServicio.ObtenerProductos();
                return Results.Ok(productos);
            })
            .WithName("ObtenerProductos")
            .WithTags("Producto")
            .Produces<List<ProductoDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapGet("/producto/{id}", async (int id, IProductoServicio productoServicio) =>
            {
                var producto = await productoServicio.ObtenerProductoPorId(id);
                if (producto == null)
                {
                    return Results.NotFound(new { mensaje = "El producto no existe." });
                }
                return Results.Ok(producto);
            })
            .WithName("ObtenerProductoPorId")
            .WithTags("Producto")
            .Produces<ProductoDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();
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
                }
                catch (ArgumentException ex)
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

            //    app.MapGet("/producto/", async (IProductoServicio productoServicio) =>
            //    {
            //        try
            //        {
            //            List<ProductoDTO> losProd = await productoServicio.ObtenerTodos();
            //            return Results.Ok(losProd);
            //        }
            //        catch (ArgumentException ex)
            //        {
            //            return Results.BadRequest(ex.Message);
            //        }

            //    }).WithName("Listar Productos")
            //    .WithTags("Producto")
            //    .Produces<List<ProductoDTO>>(StatusCodes.Status200OK)
            //    .Produces(StatusCodes.Status400BadRequest).WithOpenApi();
            //}

        }


    }
}

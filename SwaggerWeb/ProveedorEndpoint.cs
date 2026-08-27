using Alemana.Aplicaciones.Servicios;
using Alemana.DTOs;

namespace SwaggerWeb
{
    public static class ProveedorEndpoint
    {

        public static void MapProveedorEndpoint(this WebApplication app)
        {

            app.MapPost("/proveedores", async (ProveedorDTO dto, IProveedorServicio proveedorServicio) =>
            {
                try
                {
                    ProveedorDTO proveedorDto = await proveedorServicio.AgregarProveedor(dto);

                    return Results.Created($"/proveedores/{proveedorDto.IdProveedor}", proveedorDto);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            }).WithName("Alta Proveedor")
            .WithTags("Proveedores")
            .Produces<ProveedorDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapGet("/proveedores", async (IProveedorServicio proveedorServicio) =>
            {
                try
                {
                    var proveedores = await proveedorServicio.ObtenerTodos();
                    return Results.Ok(proveedores);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            }).WithName("Obtener Proveedores")
            .WithTags("Proveedores")
            .Produces<List<ProveedorDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapGet("/proveedores/{id}", async (int id, IProveedorServicio proveedorServicio) =>
            {
                try
                {
                    var proveedor = await proveedorServicio.ObtenerPorId(id);

                    if (proveedor == null)
                    {
                        return Results.NotFound(new { mensaje = $"No se encontró el proveedor con ID {id}" });
                    }

                    return Results.Ok(proveedor);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            }).WithName("Obtener Proveedor Por Id")
            .WithTags("Proveedores")
            .Produces<ProveedorDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapPut("/proveedores/{id}", async (int id, ProveedorDTO dto, IProveedorServicio proveedorServicio) =>
            {
                try
                {
                    if (id != dto.IdProveedor)
                    {
                        return Results.BadRequest(new { error = "El ID de la ruta no coincide con el ID del proveedor." });
                    }

                    ProveedorDTO proveedorActualizado = await proveedorServicio.ModificarProveedor(dto);
                    return Results.Ok(proveedorActualizado);
                }
                catch (ArgumentException ex)
                {
                    return Results.NotFound(new { error = ex.Message });
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            }).WithName("Modificar Proveedor")
            .WithTags("Proveedores")
            .Produces<ProveedorDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();
        }

    }
}
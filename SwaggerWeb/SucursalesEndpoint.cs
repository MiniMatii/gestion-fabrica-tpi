using Alemana.Aplicaciones.Servicios;
using Alemana.DTOs;

namespace SwaggerWeb
{
    public static class SucursalesEndpoint
    {
        public static void MapSucursalesEndpoint(this WebApplication app) 
        {

            app.MapPost("/sucursales", async (SucursalesDTO dto, ISucursalServicio sucursalServicio) =>
            {
                try 
                {
                    var sucursal = await sucursalServicio.AgregarUnaSucursal(dto);
                    return Results.Ok(sucursal);

                } catch (ArgumentException ex) 
                {
                    return Results.BadRequest(ex.Message);
                }

            }).WithName("Alta sucursal")
            .WithTags("Sucursales")
            .Produces<SucursalesDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/sucursales", async (SucursalesDTO dto, ISucursalServicio sucursalServicio) => 
            {
                try
                {
                    var found = await sucursalServicio.ModificarSucursal(dto);
                    if (found)
                    {
                        return Results.NoContent(); //no sé qué es mejor, si el NoContent o el Ok
                    }
                    return Results.NotFound();
                }
                catch(ArgumentException ex)
                {
                    return Results.BadRequest(new {error= ex.Message});
                }
            }).WithTags("ModificarSucursales")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapGet("/sucursales", async (ISucursalServicio sucursalServicio) => 
            {
                var Sucursales = await sucursalServicio.ObtenerTodos();
                return Results.Ok(Sucursales);
            }).WithTags("BuscarTodasSucursales")
            .Produces<List<SucursalesDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapPost("/sucursales/{id}", async(int id, List<int> idEs, ISucursalServicio sucursalServicio) =>
            {
                try
                {
                    var laS = await sucursalServicio.AgregarEmpleados(id, idEs);
                    if (laS != null)
                    {
                        return Results.Ok(laS);
                    }
                    return Results.NotFound();
                }
                catch (ArgumentException ex) 
                {
                    return Results.BadRequest(new { error = ex.Message });
                }


            }).WithTags("AgregarEmpleados")
            .Produces<SucursalesDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

        }
    }
}

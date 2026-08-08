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
        }
    }
}

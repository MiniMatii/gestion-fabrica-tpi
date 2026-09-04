using Alemana.Aplicaciones.Servicios;
using Alemana.DTOs;


namespace SwaggerWeb
{
    public static class LoteEndpoint
    {

        public static void MapLoteEndpoint(this WebApplication app) 
        {



            app.MapPost("/lotes", async (LoteDTO dto, ILoteServicio loteServicio) =>
            {
                try
                {
                    LoteDTO loteDto = await loteServicio.AgregarLote(dto);

                    return Results.Created($"/lotes/{loteDto.IdLote}", loteDto);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            }).WithName("Alta Lote")
            .WithTags("Lotes")
            .Produces<LoteDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();
            

            app.MapPut($"/lotes", async (int codLote, ILoteServicio loteServicio) => 
            {
                try 
                {
                    LoteDTO loteDto = await loteServicio.BajaLote(codLote);


                    return Results.Created($"/lotes/{loteDto.IdLote}", loteDto);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            }).WithName("Modificar Estado Lote")
            .WithTags("Lotes")
            .Produces<LoteDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();


            app.MapDelete("/lotes/{id}", async (int codLote, ILoteServicio loteServicio) =>
            {
                var eliminado = await loteServicio.EliminarLote(codLote);

                if (!eliminado)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            })
            .WithName("Borrar Lote")
            .WithTags("Lotes")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();


            app.MapGet("/lotes", async (ILoteServicio loteServicio) =>
            {
                try
                {
                    var lotes = await loteServicio.ObtenerTodos();
                    return Results.Ok(lotes);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            }).WithName("Obtener Lotes")
            .WithTags("Lotes")
            .Produces<List<LoteDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();


        }


    }
}

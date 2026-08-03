using Alemana.Aplicaciones.Servicios;
using Alemana.DTOs;


namespace SwaggerWeb
{
    public static class LoteEndpoint
    {

        public static void MapLoteEndpoint(this WebApplication app) 
        {



            app.MapPost("/lote", async (LoteDTO dto, ILoteServicio loteServicio) =>
            {
                try
                {
                    LoteDTO loteDto = await loteServicio.AgregarLote(dto);

                    return Results.Created($"/lote/{loteDto.IdLote}", loteDto);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            }).WithName("Alta Lote")
            .Produces<LoteDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();
            
        }
    }
}

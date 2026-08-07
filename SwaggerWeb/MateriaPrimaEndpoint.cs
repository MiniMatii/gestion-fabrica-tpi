using Alemana.Aplicaciones.Servicios;
using Alemana.DTOs;

namespace SwaggerWeb
{
    public static class MateriapEndpoint
    {
        public static void MapMateriapEndpoint(this WebApplication app)
        {
            app.MapPost("/materiap", async (MateriaPrimaDTO dto, IMateriapServicio materiapServicio) =>
            {
                try
                {
                    MateriaPrimaDTO materiapDto = await materiapServicio.AgregarMateriaPrima(dto);

                    return Results.Created($"/materiap/{materiapDto.IdMateriaP}", materiapDto);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            }).WithName("Alta Materia Prima")
            .WithTags("Materia Prima")
            .Produces<MateriaPrimaDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapGet("/materiap", async (IMateriapServicio materiapServicio) =>
            {
                try
                {
                    var materiasPrimas = await materiapServicio.ObtenerTodos();
                    return Results.Ok(materiasPrimas);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            }).WithName("Obtener Materias Primas")
            .WithTags("Materia Prima")
            .Produces<List<MateriaPrimaDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();


            app.MapGet("/materiap/{id}", async (int id, IMateriapServicio materiapServicio) =>
            {
                try
                {
                    var materiap = await materiapServicio.ObtenerPorId(id);

                    if (materiap == null)
                    {
                        return Results.NotFound(new { mensaje = $"No se encontró la materia prima con ID {id}" });
                    }

                    return Results.Ok(materiap);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            }).WithName("Obtener Materia Prima Por Id")
            .WithTags("Materia Prima")
            .Produces<MateriaPrimaDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapPut("/materiap/{id}", async (int id, MateriaPrimaDTO dto, IMateriapServicio materiapServicio) =>
            {
                try
                {
                    if (id != dto.IdMateriaP)
                    {
                        return Results.BadRequest(new { error = "El ID de la ruta no coincide con el ID de la materia prima." });
                    }

                    MateriaPrimaDTO matActualizada = await materiapServicio.ModificarMateriaPrima(dto);
                    return Results.Ok(matActualizada);
                }
                catch (ArgumentException ex)
                {
                    return Results.NotFound(new { error = ex.Message });
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            }).WithName("Modificar Materia Prima")
            .WithTags("Materia Prima")
            .Produces<MateriaPrimaDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();
        }

    }
}
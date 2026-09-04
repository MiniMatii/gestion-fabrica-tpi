using Alemana.Aplicaciones.Servicios;
using Alemana.DTOs;
using Pomelo.EntityFrameworkCore.MySql.Query.Internal;
using System.Runtime.CompilerServices;

namespace SwaggerWeb
{
    public static class RecetaProductoEndpoint
    {
        public static void MapRecetaProductoEndpoint(this WebApplication app)
        {
            app.MapPost("/Recetas", async (RecetaProductoDTO nuevaR, IRecetaProductoServicio recetaService) =>
            {
                try
                {
                    var receta = await recetaService.AltaReceta(nuevaR);
                    return Results.Created($"/Recetas/{receta.IdReceta}", receta);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            }

            ).WithName("AltaReceta")
            .WithTags("Recetas")
            .Produces<RecetaProductoDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/Recetas", async (RecetaProductoDTO rtaModifdto, IRecetaProductoServicio recetaService) =>
            {
                try
                {
                    var rtaModif = await recetaService.ModificarReceta(rtaModifdto);
                    if (rtaModif is null)
                    {
                        return Results.NotFound();
                    }
                    return Results.NoContent();
                }
                catch(ArgumentException ex) 
                { 
                    return Results.BadRequest(ex.Message);
                }
            }).WithName("ModificarReceta")
            .WithTags("Recetas")
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapGet("/Recetas", async (IRecetaProductoServicio recetaService) =>
            {
                var recetas = await recetaService.ObtenerTodos();
                return Results.Ok(recetas);
            }).WithName("Obtener Recetas")
              .WithTags("Recetas")
              .WithOpenApi();

            app.MapGet("/Recetas/{id}", async (int id, IRecetaProductoServicio recetaService) =>
            {
                var receta = await recetaService.ObtenerPorId(id);
                if (receta == null) return Results.NotFound(new { mensaje = "Receta no encontrada" });

                return Results.Ok(receta);
            }).WithName("Obtener Receta Por Id")
              .WithTags("Recetas")
              .WithOpenApi();

            app.MapDelete("/Recetas/{id}", async (int id, IRecetaProductoServicio recetaService) =>
            {
                if (await recetaService.EliminarReceta(id))
                {
                    return Results.NoContent();
                }
                return Results.NotFound();
            }
            ).WithName("EliminarReceta")
            .WithTags("Recetas")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapPut("/Recetas/{id}/materiasPrimas", async (int id, List<MateriapRecetaDTO> mps, IRecetaProductoServicio recetaService) =>
            {
                try
                {
                    var found = await recetaService.AgregarMateriaPrima(id, mps);
                    if (found)
                    {
                        return Results.NoContent();
                    }
                    return Results.NotFound();
                }
                catch (ArgumentException ex) 
                { 
                    return Results.BadRequest(ex.Message);
                }
            }).WithName("AgregarMateriaPrima")
            .WithTags("Recetas")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

        }
    }
}

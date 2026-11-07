using Alemana.Data.Ado;

namespace SwaggerWeb
{
    /// <summary>Listados con filtros, resueltos con ADO.NET en la capa de datos.</summary>
    public static class ConsultasAdoEndpoints
    {
        public static void MapConsultasAdoEndpoints(this WebApplication app)
        {
            app.MapGet("/ado/operarios", async (string? texto, int? disponibilidad, OperarioAdoRepositorio repo) =>
                Results.Ok(await repo.ListarAsync(texto, disponibilidad)))
               .WithName("ADO Operarios").WithTags("Consultas ADO").WithOpenApi();

            app.MapGet("/ado/lotes", async (string? texto, int? estado, string? vencimiento, LoteAdoRepositorio repo) =>
                Results.Ok(await repo.ListarAsync(texto, estado, vencimiento)))
               .WithName("ADO Lotes").WithTags("Consultas ADO").WithOpenApi();

            app.MapGet("/ado/productos", async (string? texto, bool? camara, bool? disponible, ProductoAdoRepositorio repo) =>
                Results.Ok(await repo.ListarAsync(texto, camara, disponible)))
               .WithName("ADO Productos").WithTags("Consultas ADO").WithOpenApi();

            app.MapGet("/ado/sucursales", async (string? texto, int? codPostal, SucursalAdoRepositorio repo) =>
                Results.Ok(await repo.ListarAsync(texto, codPostal)))
               .WithName("ADO Sucursales").WithTags("Consultas ADO").WithOpenApi();

            app.MapGet("/ado/pedidos", async (string? texto, string? estado, DateTime? desde, DateTime? hasta, PedidoAdoRepositorio repo) =>
                Results.Ok(await repo.ListarAsync(texto, estado, desde, hasta)))
               .WithName("ADO Pedidos").WithTags("Consultas ADO").WithOpenApi();
        }
    }
}

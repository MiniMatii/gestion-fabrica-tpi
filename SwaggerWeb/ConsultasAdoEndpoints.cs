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

            // Reportes estadísticos
            app.MapGet("/ado/reportes/lotes-por-producto",
                async (int? pedido, string? producto, DateTime? desde, DateTime? hasta, ReportesAdoRepositorio repo) =>
                    Results.Ok(await repo.LotesPorProductoDePedidoAsync(pedido, producto, desde, hasta)))
               .WithName("ADO Reporte Lotes por producto").WithTags("Consultas ADO").WithOpenApi();

            // Trazabilidad exacta: pedido -> despacho -> orden de origen -> materia prima y lotes
            app.MapGet("/ado/trazabilidad/pedido/{id:int}", async (int id, TrazabilidadAdoRepositorio repo) =>
            {
                var traza = await repo.PorPedidoAsync(id);
                return traza is null ? Results.NotFound() : Results.Ok(traza);
            }).WithName("ADO Trazabilidad Pedido").WithTags("Consultas ADO").WithOpenApi();

            app.MapGet("/ado/trazabilidad/orden/{id:int}", async (int id, TrazabilidadAdoRepositorio repo) =>
            {
                var traza = await repo.PorOrdenAsync(id);
                return traza is null ? Results.NotFound() : Results.Ok(traza);
            }).WithName("ADO Trazabilidad Orden").WithTags("Consultas ADO").WithOpenApi();

            app.MapGet("/ado/pedidos", async (string? texto, string? estado, DateTime? desde, DateTime? hasta, PedidoAdoRepositorio repo) =>
                Results.Ok(await repo.ListarAsync(texto, estado, desde, hasta)))
               .WithName("ADO Pedidos").WithTags("Consultas ADO").WithOpenApi();
        }
    }
}

using Alemana.Dominio.Models;

namespace Alemana.Data.Repositorios
{
    public interface IStockRepositorio
    {
        Task<List<(int IdMateriaP, string Nombre, string Unidad, decimal CantidadNecesaria)>> ObtenerRequerimientosAsync(int idProducto);

        Task<List<Lote>> ObtenerLotesDisponiblesAsync(int idMateriaP);

        Task<int> ObtenerStockProductoAsync(int idProducto);

        Task<Producto?> ObtenerProductoAsync(int idProducto);

        /// <summary>Materia prima comprometida por órdenes En Proceso (todavía no descontada de los lotes).</summary>
        Task<Dictionary<int, decimal>> ObtenerReservadoPorOrdenesEnProcesoAsync();
    }
}
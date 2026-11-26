using Alemana.Dominio.Models;

namespace Alemana.Data.Repositorios
{
    public interface IStockRepositorio
    {
        Task<List<(int IdMateriaP, string Nombre, string Unidad, decimal CantidadNecesaria)>> ObtenerRequerimientosAsync(int idProducto);

        Task<List<Lote>> ObtenerLotesDisponiblesAsync(int idMateriaP);

        Task<int> ObtenerStockProductoAsync(int idProducto);

        Task<Producto?> ObtenerProductoAsync(int idProducto);

        /// <summary>Unidades del producto que salen cada vez que se hace su receta (recetaproducto.rinde). 0 si no está definido.</summary>
        Task<int> ObtenerRindeAsync(int idProducto);

        /// <summary>
        /// Órdenes finalizadas del producto con unidades todavía sin despachar, de la más antigua (fechaReal) a la más nueva.
        /// Saldo = cantidad producida - unidades ya asignadas a despachos.
        /// </summary>
        Task<List<(int IdProd, int Saldo)>> ObtenerOrdenesConSaldoAsync(int idProducto);

        /// <summary>Materia prima comprometida por órdenes En Proceso (todavía no descontada de los lotes).</summary>
        Task<Dictionary<int, decimal>> ObtenerReservadoPorOrdenesEnProcesoAsync();
    }
}
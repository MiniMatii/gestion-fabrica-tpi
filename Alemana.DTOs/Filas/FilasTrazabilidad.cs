namespace Alemana.DTOs;

// Trazabilidad: pedido -> despachos (cada línea con su orden de origen) -> materia prima y lotes.

public record TrazaDespachoFila(
    int IdDespacho, DateTime FechaDespacho, int IdProd, int IdProducto, string Producto, int Cantidad);

public record TrazaOrdenFila(
    int IdProd, int IdProducto, string Producto, string EstadoOrden, int CantidadAProducir,
    DateTime FechaCreacion, DateTime? FechaReal, string Operario);

public record TrazaConsumoFila(
    int IdProd, int IdMateriaP, string MateriaPrima, string Unidad, int IdLote, decimal CantConsumida,
    DateTime FechaIngreso, DateTime FechaVencimiento, string Proveedor);

/// <summary>Despacho al que fue a parar lo producido por una orden.</summary>
public record TrazaDespachoPosteriorFila(
    int IdPedido, int IdDespacho, DateTime FechaDespacho, int Cantidad, string Sucursal);

/// <summary>Qué se despachó en un pedido, de qué órdenes salió (FIFO por fechaReal) y con qué materia prima y lotes.</summary>
public class TrazabilidadPedidoDTO
{
    public int IdPedido { get; set; }
    public DateTime FechaPedido { get; set; }
    public string EstadoPedido { get; set; } = string.Empty;
    public string Sucursal { get; set; } = string.Empty;
    public string Empleado { get; set; } = string.Empty;
    public List<TrazaDespachoFila> Despachos { get; set; } = new();
    public List<TrazaOrdenFila> Ordenes { get; set; } = new();
    public List<TrazaConsumoFila> Consumos { get; set; } = new();
}

/// <summary>Una orden de producción con su materia prima y lotes, y a qué despachos fue lo que produjo.</summary>
public class TrazabilidadOrdenDTO
{
    public TrazaOrdenFila Orden { get; set; } = null!;
    public List<TrazaConsumoFila> Consumos { get; set; } = new();
    public List<TrazaDespachoPosteriorFila> Despachos { get; set; } = new();
}

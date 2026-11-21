namespace Alemana.DTOs;

// Trazabilidad: pedido -> despachos -> órdenes de producción -> materia prima y lotes.

public record TrazaDespachoFila(
    int IdDespacho, DateTime FechaDespacho, int IdProducto, string Producto, int Cantidad);

public record TrazaOrdenFila(
    int IdProd, int IdProducto, string Producto, string EstadoOrden, int CantidadAProducir,
    DateTime FechaCreacion, DateTime? FechaReal, string Operario);

public record TrazaConsumoFila(
    int IdProd, int IdMateriaP, string MateriaPrima, string Unidad, int IdLote, decimal CantConsumida,
    DateTime FechaIngreso, DateTime FechaVencimiento, string Proveedor);

public record TrazaDespachoPosteriorFila(
    int IdPedido, int IdDespacho, DateTime FechaDespacho, int Cantidad, string Sucursal);

/// <summary>Qué se despachó en un pedido y de qué producciones pudo salir (con su materia prima y lotes).</summary>
public class TrazabilidadPedidoDTO
{
    public int IdPedido { get; set; }
    public DateTime FechaPedido { get; set; }
    public string EstadoPedido { get; set; } = string.Empty;
    public string Sucursal { get; set; } = string.Empty;
    public string Empleado { get; set; } = string.Empty;
    public int VentanaDias { get; set; }
    public List<TrazaDespachoFila> Despachos { get; set; } = new();
    public List<TrazaOrdenFila> Ordenes { get; set; } = new();
    public List<TrazaConsumoFila> Consumos { get; set; } = new();
}

/// <summary>Una orden de producción con su materia prima y lotes, y a qué pedidos pudo ir su producto.</summary>
public class TrazabilidadOrdenDTO
{
    public TrazaOrdenFila Orden { get; set; } = null!;
    public int VentanaDias { get; set; }
    public List<TrazaConsumoFila> Consumos { get; set; } = new();
    public List<TrazaDespachoPosteriorFila> Despachos { get; set; } = new();
}

namespace Alemana.DTOs;

// Filas de lectura para los listados con filtros (incluyen datos de tablas relacionadas).
// Las usan la API (endpoints /ado/...) y la web (Blazor) para mostrar los resultados.

public record OperarioFila(int IdOperario, string Nombre, string Apellido, int Disponibilidad);

public record LoteFila(
    int IdLote, DateTime FechaIngreso, DateTime FechaVencimiento, decimal CantidadLote,
    int? EstadoLote, int IdProveedor, string Proveedor, int IdMateriaP, string MateriaPrima);

public record ProductoFila(int IdProducto, string Nombre, int IdReceta, bool Camara, bool? Disponible, int StockActual);

public record SucursalFila(int IdSucursal, string NombreSuc, int CodPostal, string NombreCiudad);

public record PedidoFila(
    int IdPedido, DateTime FechaPedido, string EstadoPedido, DateTime? FechaEstimada,
    DateTime? FechaReal, int IdEmpleado, string Empleado, int CantItems);

using System;
using System.Collections.Generic;

namespace Alemana.Dominio.Models;

/// <summary>Orden de producción. No está vinculada a ningún pedido.</summary>
public partial class Ordenproduccion
{
    public int IdProd { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string EstadoOrden { get; set; } = null!;

    public DateTime? FechaEstimada { get; set; }

    public DateTime? FechaReal { get; set; }

    public int CantidadAproducir { get; set; }

    public int IdProducto { get; set; }

    public virtual ICollection<DetalleDespacho> DetalleDespachos { get; set; } = new List<DetalleDespacho>();

    public virtual ICollection<Consumolote> Consumolotes { get; set; } = new List<Consumolote>();

    public virtual Producto IdProductoNavigation { get; set; } = null!;

    public virtual ICollection<OrdAsigOp> OrdAsigOps { get; set; } = new List<OrdAsigOp>();
}

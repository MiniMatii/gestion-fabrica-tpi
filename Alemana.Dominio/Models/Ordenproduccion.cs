using System;
using System.Collections.Generic;

namespace Alemana.Dominio.Models;

public partial class Ordenproduccion
{
    public int IdProd { get; set; }

    public DateTime FechaPedido { get; set; }

    public string EstadoPedido { get; set; } = null!;

    public DateTime? FechaEstimada { get; set; }

    public DateTime? FechaReal { get; set; }

    public int CantidadRequerida { get; set; }

    public int IdProducto { get; set; }

    public int? IdPedido { get; set; }

    public virtual ICollection<Consumolote> Consumolotes { get; set; } = new List<Consumolote>();

    public virtual Solicitudpedido? IdPedidoNavigation { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;

    public virtual ICollection<OrdAsigOp> OrdAsigOps { get; set; } = new List<OrdAsigOp>();
}

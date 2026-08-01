using System;
using System.Collections.Generic;

namespace Alemana.Dominio.Models;

public partial class DetallePedido
{
    public int IdPedido { get; set; }

    public int IdProducto { get; set; }

    public int CantidadesProductos { get; set; }

    public virtual Solicitudpedido IdPedidoNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}

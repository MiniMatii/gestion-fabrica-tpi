using System;
using System.Collections.Generic;

namespace Alemana.Dominio.Models;

public partial class DetalleDespacho
{
    public int IdDespacho { get; set; }

    public int IdProducto { get; set; }

    public int Cantidad { get; set; }

    public virtual Despacho IdDespachoNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}

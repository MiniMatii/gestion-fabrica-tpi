using System;
using System.Collections.Generic;

namespace Alemana.Dominio.Models;

public partial class DetalleDespacho
{
    public int IdDespacho { get; set; }

    /// <summary>Orden de producción de la que sale lo despachado. El producto se obtiene de la orden (no se repite acá).</summary>
    public int IdProd { get; set; }

    public int Cantidad { get; set; }

    public virtual Despacho IdDespachoNavigation { get; set; } = null!;

    public virtual Ordenproduccion IdProdNavigation { get; set; } = null!;
}

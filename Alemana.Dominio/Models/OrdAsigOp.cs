using System;
using System.Collections.Generic;

namespace Alemana.Dominio.Models;

public partial class OrdAsigOp
{
    public int IdProd { get; set; }

    public int IdOperario { get; set; }

    public int Cantidades { get; set; }

    public DateTime FechaIni { get; set; }

    public DateTime? FechaFin { get; set; }

    public virtual Operario IdOperarioNavigation { get; set; } = null!;

    public virtual Ordenproduccion IdProdNavigation { get; set; } = null!;
}

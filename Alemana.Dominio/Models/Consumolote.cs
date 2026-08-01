using System;
using System.Collections.Generic;

namespace Alemana.Dominio.Models;

public partial class Consumolote
{
    public int IdConsumo { get; set; }

    public decimal CantConsumida { get; set; }

    public int IdProd { get; set; }

    public int IdLote { get; set; }

    public virtual Lote IdLoteNavigation { get; set; } = null!;

    public virtual Ordenproduccion IdProdNavigation { get; set; } = null!;
}

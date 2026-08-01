using System;
using System.Collections.Generic;

namespace Alemana.Dominio.Models;

public partial class Lote
{
    public int IdLote { get; set; }

    public DateTime FechaIngreso { get; set; }

    public DateTime FechaVencimiento { get; set; }

    public decimal CantidadLote { get; set; }

    public int IdProveedor { get; set; }

    public int IdMateriaP { get; set; }

    public sbyte? EstadoLote { get; set; }

    public virtual ICollection<Consumolote> Consumolotes { get; set; } = new List<Consumolote>();

    public virtual Materiap IdMateriaPNavigation { get; set; } = null!;

    public virtual Proveedore IdProveedorNavigation { get; set; } = null!;
}

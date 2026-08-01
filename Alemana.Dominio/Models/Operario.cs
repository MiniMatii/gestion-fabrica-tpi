using System;
using System.Collections.Generic;

namespace Alemana.Dominio.Models;

public partial class Operario
{
    public int IdOperario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public sbyte Disponibilidad { get; set; }

    public virtual ICollection<OrdAsigOp> OrdAsigOps { get; set; } = new List<OrdAsigOp>();

    public virtual ICollection<Capacidad> IdCaps { get; set; } = new List<Capacidad>();
}

using System;
using System.Collections.Generic;

namespace Alemana.Dominio.Models;

public partial class Capacidad
{
    public int IdCap { get; set; }

    public string DescCapacidad { get; set; } = null!;

    public string NomCapacidad { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();

    public virtual ICollection<Operario> IdOperarios { get; set; } = new List<Operario>();
}

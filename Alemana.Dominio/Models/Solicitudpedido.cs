using System;
using System.Collections.Generic;

namespace Alemana.Dominio.Models;

public partial class Solicitudpedido
{
    public int IdPedido { get; set; }

    public DateTime FechaPedido { get; set; }

    public string EstadoPedido { get; set; } = null!;

    public DateTime? FechaEstimada { get; set; }

    public DateTime? FechaReal { get; set; }

    public int IdEmpleado { get; set; }

    public virtual ICollection<Despacho> Despachos { get; set; } = new List<Despacho>();

    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;
}

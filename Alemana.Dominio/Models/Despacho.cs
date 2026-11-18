using System;
using System.Collections.Generic;

namespace Alemana.Dominio.Models;

public partial class Despacho
{
    public int IdDespacho { get; set; }

    public int IdPedido { get; set; }

    public DateTime FechaDespacho { get; set; }

    public int IdEmpleado { get; set; }

    public virtual ICollection<DetalleDespacho> DetalleDespachos { get; set; } = new List<DetalleDespacho>();

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;

    public virtual Solicitudpedido IdPedidoNavigation { get; set; } = null!;
}

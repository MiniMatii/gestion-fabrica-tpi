using System;
using System.Collections.Generic;

namespace Alemana.Dominio.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Dni { get; set; } = null!;

    //public int IdSucursal { get; set; }

    public int? IdJefe { get; set; }
    public sbyte Disponibilidad { get; set; }

    public string? Motivo { get; set; }

    public virtual Empleado? IdJefeNavigation { get; set; }

    //public virtual Sucursale IdSucursalNavigation { get; set; } = null!;

    public virtual ICollection<Empleado> InverseIdJefeNavigation { get; set; } = new List<Empleado>();

    public virtual ICollection<Solicitudpedido> Solicitudpedidos { get; set; } = new List<Solicitudpedido>();
}

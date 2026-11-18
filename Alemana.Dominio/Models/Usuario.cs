using System;
using System.Collections.Generic;

namespace Alemana.Dominio.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Usuario1 { get; set; }

    public string? ClaveHash { get; set; }

    public int? IdEmpleado { get; set; }

    public int? IdOperario { get; set; }

    public virtual Empleado? IdEmpleadoNavigation { get; set; }

    public virtual Operario? IdOperarioNavigation { get; set; }
}

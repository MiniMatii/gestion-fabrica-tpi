using System;
using System.Collections.Generic;

namespace Alemana.Dominio.Models;

public partial class Sucursale
{
    public int IdSucursal { get; set; }

    public string NombreSuc { get; set; } = null!;

    public int CodPostal { get; set; }

    public virtual Ciudade CodPostalNavigation { get; set; } = null!;

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}

using System;
using System.Collections.Generic;

namespace Alemana.Dominio.Models;

public partial class Ciudade
{
    public int CodPostal { get; set; }

    public string NombreCiudad { get; set; } = null!;

    public virtual ICollection<Sucursale> Sucursales { get; set; } = new List<Sucursale>();
}

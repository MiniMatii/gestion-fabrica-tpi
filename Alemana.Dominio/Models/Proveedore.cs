using System;
using System.Collections.Generic;

namespace Alemana.Dominio.Models;

public partial class Proveedore
{
    public int IdProveedor { get; set; }

    public string RazonSocial { get; set; } = null!;

    public string Cuit { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Lote> Lotes { get; set; } = new List<Lote>();
}

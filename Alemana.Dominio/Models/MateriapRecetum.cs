using System;
using System.Collections.Generic;

namespace Alemana.Dominio.Models;

public partial class MateriapRecetum
{
    public int IdMateriaP { get; set; }

    public int IdReceta { get; set; }

    public decimal CantidadNecesaria { get; set; }

    public virtual Materiap IdMateriaPNavigation { get; set; } = null!;

    public virtual Recetaproducto IdRecetaNavigation { get; set; } = null!;
}

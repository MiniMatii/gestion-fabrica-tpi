using System;
using System.Collections.Generic;

namespace Alemana.Dominio.Models;

public partial class Materiap
{
    public int IdMateriaP { get; set; }

    public string Nombre { get; set; } = null!;

    public string Unidad { get; set; } = null!;

    public virtual ICollection<Lote> Lotes { get; set; } = new List<Lote>();

    public virtual ICollection<MateriapRecetum> MateriapReceta { get; set; } = new List<MateriapRecetum>();
}

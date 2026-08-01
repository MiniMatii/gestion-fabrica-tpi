using System;
using System.Collections.Generic;

namespace Alemana.Dominio.Models;

public partial class Recetaproducto
{
    public int IdReceta { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<MateriapRecetum> MateriapReceta { get; set; } = new List<MateriapRecetum>();

    public virtual Producto? Producto { get; set; }
}

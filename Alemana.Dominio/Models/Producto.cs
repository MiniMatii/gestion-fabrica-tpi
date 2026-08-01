using System;
using System.Collections.Generic;

namespace Alemana.Dominio.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Camara { get; set; }

    public bool? Disponible { get; set; }

    public int IdReceta { get; set; }

    public int StockActual { get; set; }

    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();

    public virtual Recetaproducto IdRecetaNavigation { get; set; } = null!;

    public virtual ICollection<Ordenproduccion> Ordenproduccions { get; set; } = new List<Ordenproduccion>();
}

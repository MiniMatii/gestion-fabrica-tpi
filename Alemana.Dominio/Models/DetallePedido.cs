using System;
using System.Collections.Generic;

namespace Alemana.Dominio.Models;

public partial class DetallePedido
{
    public int IdPedido { get; set; }

    public int IdProducto { get; set; }

    public int CantidadSolicitada { get; set; }

    /// <summary>Cantidad que el responsable aceptó del pedido.</summary>
    public int CantidadAceptada { get; set; }

    /// <summary>Cantidad aceptada que salió del stock disponible.</summary>
    public int CantidadDespachada { get; set; }

    public virtual Solicitudpedido IdPedidoNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}

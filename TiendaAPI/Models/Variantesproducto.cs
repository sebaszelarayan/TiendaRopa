using System;
using System.Collections.Generic;

namespace TiendaAPI.Models;

public partial class Variantesproducto
{
    public int Id { get; set; }

    public int ProductoId { get; set; }

    public int TalleId { get; set; }

    public int ColorId { get; set; }

    public int Stock { get; set; }

    public virtual Color Color { get; set; } = null!;

    public virtual ICollection<Detalleventa> Detalleventa { get; set; } = new List<Detalleventa>();

    public virtual Producto Producto { get; set; } = null!;

    public virtual Talle Talle { get; set; } = null!;
}

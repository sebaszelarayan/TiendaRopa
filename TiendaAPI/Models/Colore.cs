using System;
using System.Collections.Generic;

namespace TiendaAPI.Models;

public partial class Color
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? CodigoHex { get; set; }

    public virtual ICollection<Variantesproducto> Variantesproductos { get; set; } = new List<Variantesproducto>();
}

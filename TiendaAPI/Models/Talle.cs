using System;
using System.Collections.Generic;

namespace TiendaAPI.Models;

public partial class Talle
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Variantesproducto> Variantesproductos { get; set; } = new List<Variantesproducto>();
}

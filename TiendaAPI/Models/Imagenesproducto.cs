using System;
using System.Collections.Generic;

namespace TiendaAPI.Models;

public partial class Imagenesproducto
{
    public int Id { get; set; }

    public int ProductoId { get; set; }

    public string ImagenUrl { get; set; } = null!;

    public int? Orden { get; set; }

    public virtual Producto Producto { get; set; } = null!;
}

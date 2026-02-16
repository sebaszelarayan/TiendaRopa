using System;
using System.Collections.Generic;

namespace TiendaAPI.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public int CategoriaId { get; set; }

    public virtual Categoria Categoria { get; set; } = null!;

    public virtual ICollection<Imagenesproducto> Imagenesproductos { get; set; } = new List<Imagenesproducto>();

    public virtual ICollection<Variantesproducto> Variantesproductos { get; set; } = new List<Variantesproducto>();
}

using System;
using System.Collections.Generic;

namespace TiendaAPI.Models;

public partial class Detalleventa
{
    public int Id { get; set; }

    public int? VentaId { get; set; }

    public int VarianteId { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public virtual Variantesproducto Variante { get; set; } = null!;

    public virtual Venta? Venta { get; set; }
}

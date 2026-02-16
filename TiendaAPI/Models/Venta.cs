using System;
using System.Collections.Generic;

namespace TiendaAPI.Models;

public partial class Venta
{
    public int Id { get; set; }

    public int? UsuarioId { get; set; }

    public DateTime? Fecha { get; set; }

    public decimal Total { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<Detalleventa> Detalleventa { get; set; } = new List<Detalleventa>();

    public virtual Usuario? Usuario { get; set; }
}

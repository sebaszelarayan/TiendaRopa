using System;
using System.Collections.Generic;

namespace TiendaAPI.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? Rol { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}

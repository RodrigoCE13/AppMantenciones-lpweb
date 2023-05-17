using System;
using System.Collections.Generic;

namespace AppMantenciones.Models;

public partial class Taller
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Fono { get; set; } = null!;

    public string? Direccion { get; set; }

    public virtual ICollection<Mantencion> Mantencions { get; set; } = new List<Mantencion>();
}

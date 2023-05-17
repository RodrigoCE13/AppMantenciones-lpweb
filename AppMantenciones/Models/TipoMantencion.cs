using System;
using System.Collections.Generic;

namespace AppMantenciones.Models;

public partial class TipoMantencion
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Mantencion> Mantencions { get; set; } = new List<Mantencion>();
}

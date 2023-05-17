using System;
using System.Collections.Generic;

namespace AppMantenciones.Models;

public partial class MarcaVehiculo
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
}

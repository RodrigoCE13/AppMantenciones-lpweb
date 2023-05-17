using System;
using System.Collections.Generic;

namespace AppMantenciones.Models;

public partial class Vehiculo
{
    public int Id { get; set; }

    public string Patente { get; set; } = null!;

    public string Modelo { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public int IdMarcaVehiculo { get; set; }

    public virtual MarcaVehiculo IdMarcaVehiculoNavigation { get; set; } = null!;

    public virtual ICollection<Mantencion> Mantencions { get; set; } = new List<Mantencion>();
}

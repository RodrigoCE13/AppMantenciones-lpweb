using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppMantenciones.Models;

public partial class Mantencion
{

    public int Id { get; set; }
    [Required(ErrorMessage = "Porfavor ingrese una descripcion")]
    public string Descripcion { get; set; } = null!;
    [Required]
    [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Por favor, ingrese un número válido.")]
    public int Precio { get; set; }

    public int IdVehiculo { get; set; }

    public int IdTipoMantencion { get; set; }

    public int IdTaller { get; set; }

    public virtual Taller IdTallerNavigation { get; set; } = null!;

    public virtual TipoMantencion IdTipoMantencionNavigation { get; set; } = null!;

    public virtual Vehiculo IdVehiculoNavigation { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace CrudMoto.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public int? Edad { get; set; }

    public string? Dui { get; set; }

    public string? Telefono { get; set; }

    public int? IdCargo { get; set; }

    public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; } = new List<DetalleFactura>();

    public virtual Cargo? IdCargoNavigation { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}

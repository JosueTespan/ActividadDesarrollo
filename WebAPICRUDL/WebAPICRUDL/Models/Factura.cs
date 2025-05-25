using System;
using System.Collections.Generic;

namespace WebAPICRUDL.Models;

public partial class Factura
{
    public int IdFactura { get; set; }

    public int? IdCliente { get; set; }

    public DateOnly? Fecha { get; set; }

    public decimal? Total { get; set; }

    public int? IdEmpleado { get; set; }

    public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; } = new List<DetalleFactura>();

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Empleado? IdEmpleadoNavigation { get; set; }
}

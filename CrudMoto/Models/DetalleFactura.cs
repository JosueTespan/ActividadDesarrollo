using System;
using System.Collections.Generic;

namespace CrudMoto.Models;

public partial class DetalleFactura
{
    public int IdDetalleFactura { get; set; }

    public int? IdFactura { get; set; }

    public int? IdEmpleado { get; set; }

    public int? IdCliente { get; set; }

    public int? IdServicioCliente { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Empleado? IdEmpleadoNavigation { get; set; }

    public virtual Factura? IdFacturaNavigation { get; set; }

    public virtual ServicioCliente? IdServicioClienteNavigation { get; set; }
}

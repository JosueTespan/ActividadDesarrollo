using System;
using System.Collections.Generic;

namespace WebAPICRUDL.Models;

public partial class DetalleFactura
{
    public int IdDetalleFac { get; set; }

    public int? IdFactura { get; set; }

    public int? IdEmpleado { get; set; }

    public int? IdServicioCli { get; set; }

    public virtual Empleado? IdEmpleadoNavigation { get; set; }

    public virtual Factura? IdFacturaNavigation { get; set; }

    public virtual ServicioCliente? IdServicioCliNavigation { get; set; }
}

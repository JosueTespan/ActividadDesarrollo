using System;
using System.Collections.Generic;

namespace CrudMoto.Models;

public partial class ServicioCliente
{
    public int IdServicioCliente { get; set; }

    public int? IdServicio { get; set; }

    public int? IdCliente { get; set; }

    public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; } = new List<DetalleFactura>();

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Servicio? IdServicioNavigation { get; set; }
}

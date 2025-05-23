using System;
using System.Collections.Generic;

namespace CrudMoto.Models;

public partial class Factura
{
    public int IdFactura { get; set; }

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; } = new List<DetalleFactura>();
}

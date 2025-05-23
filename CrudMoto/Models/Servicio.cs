using System;
using System.Collections.Generic;

namespace CrudMoto.Models;

public partial class Servicio
{
    public int IdServicio { get; set; }

    public string Servicio1 { get; set; } = null!;

    public decimal Precio { get; set; }

    public virtual ICollection<ServicioCliente> ServicioClientes { get; set; } = new List<ServicioCliente>();
}

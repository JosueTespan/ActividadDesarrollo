using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPICRUDL.Models;

public partial class Servicio
{
    public int IdServicio { get; set; }

    [Column("Servicio")]
    public string? NombreServicio { get; set; } = null!;

    public decimal? Precio { get; set; }

    public virtual ICollection<ServicioCliente> ServicioClientes { get; set; } = new List<ServicioCliente>();
}

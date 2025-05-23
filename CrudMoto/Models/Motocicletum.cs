using System;
using System.Collections.Generic;

namespace CrudMoto.Models;

public partial class Motocicletum
{
    public int IdMotocicleta { get; set; }

    public string Modelo { get; set; } = null!;

    public string Marca { get; set; } = null!;

    public int? Anio { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
}

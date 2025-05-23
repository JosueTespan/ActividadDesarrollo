using System;
using System.Collections.Generic;

namespace WebApiCrud.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? NombreCompleto { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public string? Direccion { get; set; }

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public virtual ICollection<Motocicletum> Motocicleta { get; set; } = new List<Motocicletum>();

    public virtual ICollection<ServicioCliente> ServicioClientes { get; set; } = new List<ServicioCliente>();
}

using System;
using System.Collections.Generic;

namespace CrudMoto.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public string? Direccion { get; set; }

    public int? IdMotocicleta { get; set; }

    public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; } = new List<DetalleFactura>();

    public virtual Motocicletum? IdMotocicletaNavigation { get; set; }

    public virtual ICollection<ServicioCliente> ServicioClientes { get; set; } = new List<ServicioCliente>();
}

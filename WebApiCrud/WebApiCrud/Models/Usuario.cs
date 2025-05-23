using System;
using System.Collections.Generic;

namespace WebApiCrud.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Usuario1 { get; set; }

    public string? Clave { get; set; }

    public int? IdEmpleado { get; set; }

    public virtual Empleado? IdEmpleadoNavigation { get; set; }
}

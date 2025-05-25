using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPICRUDL.Models;

namespace WebAPICRUDL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioClienteController : ControllerBase
    {
        private readonly TallerMotosContext dbContext;
        public ServicioClienteController(TallerMotosContext context)
        {
            dbContext = context;
        }
        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var lista = await dbContext.ServicioClientes.Include(sc => sc.IdClienteNavigation).Include(sc => sc.IdServicioNavigation).ToListAsync();
            return Ok(lista);
        }
        [HttpGet]
        [Route("Obtener/{id:int}")]
        public async Task<IActionResult> Obtener(int id)
        {
            var item = await dbContext.ServicioClientes
                .Include(sc => sc.IdClienteNavigation)
                .Include(sc => sc.IdServicioNavigation)
                .FirstOrDefaultAsync(sc => sc.IdServicioCli == id);

            if (item == null)
                return NotFound(new { mensaje = "Registro no encontrado" });

            return Ok(item);
        }
        [HttpPost]
        [Route("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] ServicioCliente modelo)
        {
            // Validar si el servicio ya fue asignado al cliente
            var existe = await dbContext.ServicioClientes
                .AnyAsync(sc => sc.IdCliente == modelo.IdCliente && sc.IdServicio == modelo.IdServicio);

            if (existe)
                return BadRequest(new { mensaje = "El servicio ya fue asignado a este cliente." });

            // Guardar el vínculo Servicio-Cliente
            dbContext.ServicioClientes.Add(modelo);
            await dbContext.SaveChangesAsync();

            // Recuperar el ID generado del ServicioCliente
            var idServicioCliente = modelo.IdServicioCli;

            // Verificar que el servicio exista
            var servicio = await dbContext.Servicios
                .FirstOrDefaultAsync(s => s.IdServicio == modelo.IdServicio);

            if (servicio == null)
                return BadRequest(new { mensaje = "Servicio no válido." });

            // Crear la factura
            var factura = new Factura
            {
                IdCliente = modelo.IdCliente,
                IdEmpleado = 1, // Puedes cambiarlo dinámicamente si necesitas
                Fecha = DateOnly.FromDateTime(DateTime.Now),
                Total = servicio.Precio ?? 0m
            };

            dbContext.Facturas.Add(factura);
            await dbContext.SaveChangesAsync();

            // Crear el detalle de la factura con el ID del ServicioCliente
            var detalle = new DetalleFactura
            {
                IdFactura = factura.IdFactura,
                IdEmpleado = factura.IdEmpleado,
                IdServicioCli = modelo.IdServicioCli // sin el ??
            };

            dbContext.DetalleFacturas.Add(detalle);
            await dbContext.SaveChangesAsync();

            // Devolver respuesta con datos opcionales
            return Ok(new
            {
                mensaje = "Servicio registrado con factura y detalle",
                factura = new
                {
                    factura.IdFactura,
                    factura.Fecha,
                    factura.Total,
                    factura.IdCliente,
                    factura.IdEmpleado
                },
                detalle = new
                {
                    detalle.IdDetalleFac,
                    detalle.IdFactura,
                    detalle.IdEmpleado,
                    detalle.IdServicioCli
                }
            });
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] ServicioCliente modelo)
        {
            var existe = await dbContext.ServicioClientes.AnyAsync(sc => sc.IdServicioCli == modelo.IdServicioCli);
            if (!existe)
                return NotFound(new { mensaje = "Registro no encontrado" });

            dbContext.ServicioClientes.Update(modelo);
            await dbContext.SaveChangesAsync();
            return Ok(new { mensaje = "Registro actualizado" });
        }
        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var modelo = await dbContext.ServicioClientes.FirstOrDefaultAsync(sc => sc.IdServicioCli == id);
            if (modelo == null)
                return NotFound(new { mensaje = "Registro no encontrado" });

            dbContext.ServicioClientes.Remove(modelo);
            await dbContext.SaveChangesAsync();
            return Ok(new { mensaje = "Registro eliminado" });
        }
    }
}

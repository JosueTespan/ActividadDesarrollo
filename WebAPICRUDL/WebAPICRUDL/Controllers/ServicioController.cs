using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPICRUDL.Models;

namespace WebAPICRUDL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly TallerMotosContext dbContext;

        public ServicioController(TallerMotosContext context)
        {
            dbContext = context;
        }

        // GET: api/Servicio/Lista
        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Get()
        {
            var listaServicio = await dbContext.Servicios.ToListAsync();
            return Ok(listaServicio);
        }

        // GET: api/Servicio/Obtener/5
        [HttpGet]
        [Route("Obtener/{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var servicio = await dbContext.Servicios.FirstOrDefaultAsync(s => s.IdServicio == id);

            if (servicio == null)
                return NotFound(new { mensaje = "Servicio no encontrado" });

            return Ok(servicio);
        }

        // POST: api/Servicio/Nuevo
        [HttpPost]
        [Route("Nuevo")]
        public async Task<IActionResult> Nuevo([FromBody] Servicio objeto)
        {
            if (string.IsNullOrWhiteSpace(objeto.NombreServicio) || objeto.Precio <= 0)
                return BadRequest(new { mensaje = "Datos inválidos del servicio." });

            await dbContext.Servicios.AddAsync(objeto);
            await dbContext.SaveChangesAsync();

            return Ok(new { mensaje = "Servicio creado correctamente", servicio = objeto });
        }

        // PUT: api/Servicio/Editar
        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] Servicio objeto)
        {
            var existe = await dbContext.Servicios.AnyAsync(s => s.IdServicio == objeto.IdServicio);
            if (!existe)
                return NotFound(new { mensaje = "Servicio no encontrado" });

            dbContext.Servicios.Update(objeto);
            await dbContext.SaveChangesAsync();

            return Ok(new { mensaje = "Servicio actualizado correctamente" });
        }

        // DELETE: api/Servicio/Eliminar/5
        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var servicio = await dbContext.Servicios.FirstOrDefaultAsync(s => s.IdServicio == id);
            if (servicio == null)
                return NotFound(new { mensaje = "Servicio no encontrado" });

            dbContext.Servicios.Remove(servicio);
            await dbContext.SaveChangesAsync();

            return Ok(new { mensaje = "Servicio eliminado correctamente" });
        }
    }
}

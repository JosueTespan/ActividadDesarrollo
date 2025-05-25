using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPICRUDL.Models;

namespace WebAPICRUDL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotoController : ControllerBase
    {
        private readonly TallerMotosContext dbContext;
        public MotoController(TallerMotosContext _dbContext)
        {
            dbContext = _dbContext;
        }
        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Get()
        {
            var listaMoto = await dbContext.Motocicleta.ToListAsync();
            return StatusCode(StatusCodes.Status200OK, listaMoto);
        }
        [HttpGet]
        [Route("Obtener/{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var motocicleta = await dbContext.Motocicleta.FirstOrDefaultAsync(m => m.IdMotocicleta == id);
            return StatusCode(StatusCodes.Status200OK, motocicleta);
        }
        [HttpPost]
        [Route("Nuevo")]
        public async Task<IActionResult> Nuevo([FromBody] Motocicletum objeto)
        {
            await dbContext.Motocicleta.AddAsync(objeto);
            await dbContext.SaveChangesAsync(); 
            return Ok(new { mensaje = "ok", moto = objeto });
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] Motocicletum objeto)
        {
            dbContext.Motocicleta.Update(objeto);
            await dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
        }
        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var motocicleta = await dbContext.Motocicleta.FirstOrDefaultAsync(m => m.IdMotocicleta == id);
            dbContext.Motocicleta.Remove(motocicleta);
            await dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
        }

    }
}

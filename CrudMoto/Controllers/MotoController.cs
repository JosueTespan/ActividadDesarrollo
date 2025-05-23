using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using CrudMoto.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudMoto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotoController : ControllerBase
    {
        private readonly TallerMecanicoContext dbContext;
        public MotoController(TallerMecanicoContext _dbContext)
        { 
            dbContext = _dbContext;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Get()
        {
            var ListaMoto = await dbContext.Motocicleta.ToListAsync();
            return StatusCode(StatusCodes.Status200OK,ListaMoto);
        }

        [HttpGet]
        [Route("Obtener/{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var moto = await dbContext.Motocicleta.FirstOrDefaultAsync(e =>e.IdMotocicleta==id);
            return StatusCode(StatusCodes.Status200OK, moto);
        }

        [HttpPost]
        [Route("Nuevo")]
        public async Task<IActionResult> Nuevo([FromBody] Motocicletum objeto)
        {
            await dbContext.Motocicleta.AddAsync(objeto);
            await dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, new {mensaje="ok"});
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
            var moto = await dbContext.Motocicleta.FirstOrDefaultAsync(e => e.IdMotocicleta == id);
            dbContext.Motocicleta.Remove(moto);
            await dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
        }
    }
}

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.Entities;

namespace WebApiAutores.Controllers
{
    [Route("api/autores")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AutoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Autor>>> Get() 
        {
            return await _context.Autores.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Autor modelo) 
        {
            _context.Add(modelo);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id:int}")] // api/autores/4
        public async Task<IActionResult> Put(int id, Autor modelo) 
        {
            var autor = await _context.Autores.FirstOrDefaultAsync(a => a.Id == id);
            if (autor is null)
            {
                return NotFound("Autor no encontrado");
            }

            autor.Name = modelo.Name;
            _context.Update(autor);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}

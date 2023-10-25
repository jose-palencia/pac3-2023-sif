using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.Entities;
using WebApiAutores.Filters;

namespace WebApiAutores.Controllers
{
    [Route("api/autores")]
    [ApiController]
    //[Authorize]
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

        [HttpGet("{id:int}")]
        //[Authorize]
        [ServiceFilter(typeof(MiFiltro))]
        [ResponseCache(Duration = 10)]
        public async Task<ActionResult<object>> GetOneById(int id) 
        {
            throw new NotImplementedException();
            var autor = await _context.Autores.FirstOrDefaultAsync(x => x.Id == id);

            return new {
                autor,
                number = new Random().Next(0, 100)
            };
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

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id) 
        {
            var autor = await _context.Autores.FirstOrDefaultAsync(a => a.Id == id);
            if (autor is null)
            {
                return NotFound("Autor no encontrado");
            }

            _context.Remove(autor);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}

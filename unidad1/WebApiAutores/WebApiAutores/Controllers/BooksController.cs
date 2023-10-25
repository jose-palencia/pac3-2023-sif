using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.Dtos;
using WebApiAutores.Entities;

namespace WebApiAutores.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BooksController(ApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id:Guid}")] // api/books/9E343657-45E1-4268-0F14-08DBCA004D0A
        public async Task<ActionResult<BookDto>> Get(Guid id) 
        {
            var book = await _context.Books
                .Include(b => b.Autor)
                .FirstOrDefaultAsync(x => x.Id == id);

            var bookDto = _mapper.Map<BookDto>(book);


            return bookDto;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Book model) 
        {
            var autorExiste = await _context.Autores
                .AnyAsync(x => x.Id == model.AutorId);

            if (!autorExiste) 
            {
                return BadRequest($"No existe el autor: {model.AutorId}");
            }

            _context.Books.Add(model);
            await _context.SaveChangesAsync();

            return Ok("Libro creado correctamente");
        }

    }
}

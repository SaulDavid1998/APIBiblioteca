using APIBiblioteca.Entidades;
using APIBiblioteca.Entidades.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIBiblioteca.Controllers
{
    [Route("api/libros/{libroid}/[controller]")]
    [ApiController]
    public class ComentariosController : ControllerBase
    {
        private BibliotecaContext _context;
        public ComentariosController(BibliotecaContext context)
        {

            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get(int libroid)
        {
            var libro = await _context.Libro.Where(libro => libro.LibroId == libroid).FirstOrDefaultAsync();
            if (libro == null)
            {
                return NotFound();
            }

            var comentarios = await _context.Comentario
                                            .Where(comentario => comentario.LibroFK == libroid)
                                            .Include(comentario => comentario.Libro)
                                            .ToListAsync();

            var lstcomentariosDTO = new List<ComentarioDTO>();
            foreach (var registro in comentarios)
            {
                ComentarioDTO dto = new ComentarioDTO
                {
                    ComentarioId = registro.ComentarioId,
                    Texto = registro.Texto,
                    FechaPublicacion = registro.FechaPublicacion,
                    Libro = registro.Libro.Titulo

                };

                lstcomentariosDTO.Add(dto);
            }


            if (comentarios.Count == 0)
            {
                return NotFound();
            }
            return Ok(lstcomentariosDTO);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int libroid, Guid id)
        {
            var libro = await _context.Libro.Where(libro => libro.LibroId == libroid).FirstOrDefaultAsync();
            if (libro == null)
            {
                return NotFound();
            }
            var comentario = await _context.Comentario.
                                            Where(comentario => comentario.LibroFK == libroid && comentario.ComentarioId == id).
                                            FirstOrDefaultAsync();
            if (comentario == null)
            {
                return NotFound();
            }

            var comentarioDTO = new ComentarioDTO
            {
                ComentarioId = comentario.ComentarioId,
                Texto = comentario.Texto,
                FechaPublicacion = comentario.FechaPublicacion,
                Libro = comentario.Libro.Titulo
            };
            return Ok(comentarioDTO);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Post(int libroid, ComentarioDTOPostPut comentarioDTO)
        {
            var libro = await _context.Libro.Where(libro => libro.LibroId == libroid).FirstOrDefaultAsync();
            if (libro == null)
            {
                return NotFound();
            }
            Comentario comentario = new Comentario
            {
                Texto = comentarioDTO.Texto,
                FechaPublicacion = DateTime.Today,
                LibroFK = libroid
            };

            await _context.Comentario.AddAsync(comentario);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Get", new { libroid = libroid, id = comentario.ComentarioId }, comentarioDTO);
        }
    }
}

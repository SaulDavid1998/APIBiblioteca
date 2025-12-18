using APIBiblioteca.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : Controller
    {

        private BibliotecaContext context;

        public LibrosController(BibliotecaContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            List<Libro> lstLibros = await context.Libro.ToListAsync();
            return Ok(lstLibros);
        }


        [HttpGet("{id}", Name = "GetLibroPorId")]
        public async Task<ActionResult> Get(int id)
        {
            var consulta = await context.Libro.Where(libro => libro.LibroId == id).FirstOrDefaultAsync();
            if (consulta == null)
            {
                return NotFound();
            }
            return Ok(consulta);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Libro libro)
        {
            await context.Libro.AddAsync(libro);
            await context.SaveChangesAsync();
            return CreatedAtRoute("GetLibroPorId", new { id = libro.LibroId }, libro);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Libro libro)
        {

            if (id != libro.LibroId)
            {
                return BadRequest();
            }

            bool encontrado = await context.Libro.Where(libro => libro.LibroId == id).AnyAsync();

            if (encontrado == false)
            {
                return NotFound();
            }

            context.Libro.Update(libro);
            await context.SaveChangesAsync();

            // Nota: se devuelve BadRequest cuando el id de la ruta no coincide con el id en el cuerpo,
            // porque indica una petición inválida/contradictoria. NotFound se usa cuando el recurso indicado
            // por la ruta no existe en el servidor.
            return Ok();
        }
    }

}

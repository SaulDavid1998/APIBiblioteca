using APIBiblioteca.Entidades;
using APIBiblioteca.Entidades.DTOs;
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

            List<Libro> lstLibros = await context.Libro
                                                .Include(registro=>registro.Autor)
                                                .ToListAsync();
            List<LibroDTO> lstLibroDTO = new List<LibroDTO>();

            foreach(var registro in lstLibros)
            {
                LibroDTO libroDTO = new LibroDTO
                {
                    LibroId = registro.LibroId,
                    Titulo = registro.Titulo,
                    Descripcion = registro.Descripcion,
                    Publicacion=registro.Publicacion,
                    Autor = registro.Autor.Nombre + " " + registro.Autor.Apellido
                };
                lstLibroDTO.Add(libroDTO);
            }

            return Ok(lstLibroDTO);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var consulta = await context.Libro.Include(libro=>libro.Autor).Where(libro => libro.LibroId == id).FirstOrDefaultAsync();
            if (consulta == null)
            {
                return NotFound();
            }

            LibroDTO libroDTO = new LibroDTO
            {
                LibroId = consulta.LibroId,
                Titulo = consulta.Titulo,
                Descripcion = consulta.Descripcion,
                Publicacion = consulta.Publicacion,
                Autor = consulta.Autor.Nombre + " " + consulta.Autor.Apellido
            };
            return Ok(libroDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Libro libro)
        {
           var existeAutor= await context.Autor.Where(autor => autor.AutorId == libro.AutorFK).AnyAsync();

            // Si el autor no existe, devolvemos un error de validación
            //El error de validacion es el JSON que devuelve cuando el modelo no es valido
            //Problem Detail es el estandar para devolver errores en APIs REST
            if (existeAutor ==false)
            {
                ModelState.AddModelError("AutorFK","No existe el autor");
                return ValidationProblem();
            }

            

            await context.Libro.AddAsync(libro);
            await context.SaveChangesAsync();
            return CreatedAtAction("Get", new { id = libro.LibroId }, libro);
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

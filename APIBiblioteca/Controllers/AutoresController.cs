using APIBiblioteca.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace APIBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : Controller
    {
        private BibliotecaContext context;

        public AutoresController(BibliotecaContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            List<Autor> lstAutores = await context.Autor.ToListAsync();


            return Ok(lstAutores);
        }

        [HttpGet("{id}", Name = "GetAutorPorId")]
        public async Task<ActionResult> Get(int id)
        {
            Autor autor = await context.Autor.Where(a => a.AutorId == id).FirstOrDefaultAsync();
            if (autor == null)
            {
                return NotFound();
            }
            return Ok(autor);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Autor autor)
        {
            await context.Autor.AddAsync(autor);
            // await en SaveChangesAsync porque es la operación que realiza I/O (persistir en la base de datos)
            // y puede tardar o lanzar excepciones; Add solo marca la entidad en memoria y no requiere await.
            await context.SaveChangesAsync();

            return CreatedAtRoute("GetAutorPorId", new { id = autor.AutorId }, autor);

        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id,Autor autor)
        {

            if (id != autor.AutorId)
            {
                return BadRequest();
            }

            bool encontrado = await context.Autor.Where(autor => autor.AutorId == id).AnyAsync();

            if(encontrado==false)
            {
                return NotFound();
            }

             context.Autor.Update(autor);
            await context.SaveChangesAsync();

            return Ok();
            

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Autor autor = await context.Autor.Where(autor => autor.AutorId == id).FirstOrDefaultAsync();

            if (autor == null)
            {
                return NotFound();
            }

            context.Remove(autor);
            await context.SaveChangesAsync();
            return Ok();

        }




    }
}

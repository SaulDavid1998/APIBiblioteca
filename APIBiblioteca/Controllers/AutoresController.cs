using APIBiblioteca.Entidades;
using APIBiblioteca.Entidades.DTOs;
using Microsoft.AspNetCore.Authorization;
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

            List<AutorDTO> lstAutoresDTO = new List<AutorDTO>();
            foreach (Autor autor in lstAutores)
            {
                AutorDTO autorDTO = new AutorDTO()
                {
                    AutorId = autor.AutorId,
                    NombreCompleto = autor.Nombre + " " + autor.Apellido,
                    Nacionalidad=autor.Nacionalidad
                };
                lstAutoresDTO.Add(autorDTO);

            }

            return Ok(lstAutoresDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            Autor autor = await context.Autor.Where(a => a.AutorId == id).FirstOrDefaultAsync();
            if (autor == null)
            {
                return NotFound();
            }

            AutorDTO autorDTO = new AutorDTO
            {
                AutorId = autor.AutorId,
                NombreCompleto = autor.Nombre + " " + autor.Apellido,
                Nacionalidad=autor.Nacionalidad
            };
            return Ok(autorDTO);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Post(AutorDTOPostPut autorDTO)
        {
            var autor = new Autor
            {
                Nombre = autorDTO.Nombre,
                Apellido = autorDTO.Apellido,
                Nacionalidad = autorDTO.Nacionalidad,
                FechaNacimiento = autorDTO.FechaNacimiento,
                Identificacion = autorDTO.Identificacion
            };
            await context.Autor.AddAsync(autor);
            // await en SaveChangesAsync porque es la operación que realiza I/O (persistir en la base de datos)
            // y puede tardar o lanzar excepciones; Add solo marca la entidad en memoria y no requiere await.
            await context.SaveChangesAsync();


            return CreatedAtAction("Get", new { id = autor.AutorId }, autorDTO);

        }


        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult> Put(int id,AutorDTOPostPut autorDTO)
        {

            // Antes se validaba que el id de la URL coincidiera con el id enviado en el body.
            // Como ahora usamos un DTO sin AutorId en el body, esta verificación ya no es necesaria.

            /*if (id != autor.AutorId)
            {
                return BadRequest();
            }*/
            

            bool encontrado = await context.Autor.Where(autor => autor.AutorId == id).AnyAsync();

            if(encontrado==false)
            {
                return NotFound();
            }

            var autor = await context.Autor.Where(a => a.AutorId == id).FirstOrDefaultAsync();

            autor.Nombre = autorDTO.Nombre;
            autor.Apellido = autorDTO.Apellido;
            autor.Nacionalidad = autorDTO.Nacionalidad;
            autor.FechaNacimiento = autorDTO.FechaNacimiento;
            autor.Identificacion = autorDTO.Identificacion;


            context.Autor.Update(autor);
            await context.SaveChangesAsync();

            return Ok();
            

        }

        [HttpDelete("{id}")]
        [Authorize]
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

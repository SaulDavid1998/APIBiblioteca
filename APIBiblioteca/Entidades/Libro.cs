using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIBiblioteca.Entidades
{
    public class Libro
    {
        [Key]
        public int LibroId { get; set; }


        [Required(AllowEmptyStrings=true)]
        [StringLength(300)]
        public string Descripcion { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string Titulo { get; set; } = string.Empty;

        [Required]
        public int? Publicacion { get; set; }

        [Required]
        public int AutorFK { get; set; }

        [ValidateNever]
        [ForeignKey("AutorFK")]
        public Autor Autor { get; set; } = null!;
    }
}

using System.ComponentModel.DataAnnotations;

namespace APIBiblioteca.Entidades.DTOs
{
    public class LibroDTOPostPut
    {
        [Required(AllowEmptyStrings = true)]
        [StringLength(300)]
        public string Descripcion { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string Titulo { get; set; } = string.Empty;

        [Required]
        public int? Publicacion { get; set; }

        [Required]
        public int AutorFK { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace APIBiblioteca.Entidades
{
    public class Autor
    {
        [Key]
        public int AutorId { get; set; }

        [Required]
        [StringLength(80)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(80)]
        public string Apellido { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Nacionalidad { get; set; } = string.Empty;

        [Required]
        public DateOnly FechaNacimiento { get; set; }

        [StringLength(20)]
        public string? Identificacion { get; set; }





    }
}

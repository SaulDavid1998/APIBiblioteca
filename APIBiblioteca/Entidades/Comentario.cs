using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIBiblioteca.Entidades
{
    public class Comentario
    {
        [Key]
        public Guid ComentarioId { get; set; }

        [Required]
        public string Texto { get; set; } = string.Empty;

        [Required]
        public DateTime FechaPublicacion { get; set; }

        [Required]
        public int LibroFK { get; set; }

        [ForeignKey("LibroFK")]
        [ValidateNever]
        public Libro Libro { get; set; } = null!;
    }
}

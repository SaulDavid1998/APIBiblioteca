using System.ComponentModel.DataAnnotations;

namespace APIBiblioteca.Entidades.DTOs
{
    public class ComentarioDTO
    {
        public Guid ComentarioId { get; set; }

        public string Texto { get; set; } = string.Empty;

        public DateTime FechaPublicacion { get; set; }

        public string Libro { get; set; } = string.Empty;
    }
}

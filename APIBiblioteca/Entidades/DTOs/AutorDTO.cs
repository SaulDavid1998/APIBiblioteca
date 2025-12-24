using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace APIBiblioteca.Entidades.DTOs
{
    public class AutorDTO
    {
        public int AutorId { get; set; }

        public string NombreCompleto { get; set; } = string.Empty;

        public string Nacionalidad { get; set; } = string.Empty;
    }
}

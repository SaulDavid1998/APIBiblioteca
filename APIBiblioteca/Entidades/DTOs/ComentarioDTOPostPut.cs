using System.ComponentModel.DataAnnotations;

namespace APIBiblioteca.Entidades.DTOs
{
    public class ComentarioDTOPostPut
    {
        [Required]
        public string Texto { get; set; } = string.Empty;



    }
}

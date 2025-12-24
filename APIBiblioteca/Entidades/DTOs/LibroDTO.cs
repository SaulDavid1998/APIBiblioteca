namespace APIBiblioteca.Entidades.DTOs
{
    public class LibroDTO
    {
        public int LibroId { get; set; }

        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;

        public int? Publicacion { get; set; }

        public string Autor { get; set; } = string.Empty;
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace APIBiblioteca.Entidades
{
    public class BibliotecaContext : IdentityDbContext
    {
        public BibliotecaContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Autor> Autor { get; set; } = null!;

        public DbSet<Libro> Libro { get; set; } = null!;

        public DbSet<Comentario> Comentario { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Autor>().HasData(
                new Autor() { AutorId = 1, Nombre = "Gabriel García",Apellido= "Márquez", Nacionalidad = "Colombiana", FechaNacimiento = new DateOnly(1927, 3, 6),Identificacion="123" },
                new Autor() { AutorId = 2, Nombre = "Stephen",Apellido= "King", Nacionalidad = "Estadounidense", FechaNacimiento = new DateOnly(1947, 9, 21),Identificacion="456" },
                new Autor() { AutorId = 3, Nombre = "J.K.",Apellido= "Rowling", Nacionalidad = "Britanica", FechaNacimiento = new DateOnly(1965, 7, 31),Identificacion="789" },
                new Autor() { AutorId = 4, Nombre = "J.R.R.",Apellido= "Tolkien", Nacionalidad = "Britanica", FechaNacimiento = new DateOnly(1892, 1, 3),Identificacion="321" }
            );

            modelBuilder.Entity<Libro>().HasData(
                new Libro() { LibroId = 1, Titulo = "Cien Años de Soledad", Publicacion=1967,AutorFK=1,Descripcion="" },
                new Libro() { LibroId = 2, Titulo = "El Resplandor", Publicacion=1977,AutorFK=2, Descripcion = "" },
                new Libro() { LibroId = 3, Titulo = "Harry Potter y la Piedra Filosofal",Publicacion=1997,AutorFK=3, Descripcion = "" },
                new Libro() { LibroId = 4, Titulo = "El Señor de los Anillos", Publicacion=1954,AutorFK=4 },
                new Libro() { LibroId = 5, Titulo = "El Hobbit", Publicacion=1937,AutorFK=4, Descripcion = "" },
                new Libro() { LibroId = 6, Titulo = "It", Publicacion=1986,AutorFK=2, Descripcion = "" },
                new Libro() { LibroId = 7, Titulo = "Crónica de una Muerte Anunciada",Publicacion=1981,AutorFK=1, Descripcion = "" },
                new Libro() { LibroId = 8, Titulo = "Harry Potter y las Reliquias de la Muerte",Publicacion=2007,AutorFK=3, Descripcion = "" }

            );

            modelBuilder.Entity<Comentario>().HasData(
                new Comentario() { ComentarioId = new Guid("521d2529-a2d5-470e-a74c-95e0f4281b46"), Texto = "Excelente libro, muy recomendable.", FechaPublicacion = new DateTime(2025, 12, 26), LibroFK = 1 },
                new Comentario() { ComentarioId = new Guid("535303b3-a3d0-4495-a7ad-bce547c20b5d"), Texto = "No me gustó mucho la trama.", FechaPublicacion = new DateTime(2025, 12, 26), LibroFK = 2 },
                new Comentario() { ComentarioId = new Guid("7995aed4-5a27-4bac-a80f-f09fb959c4c9"), Texto = "Una lectura fascinante para todas las edades.", FechaPublicacion = new DateTime(2025, 12, 26), LibroFK = 3 }
            );
        }
    }
}

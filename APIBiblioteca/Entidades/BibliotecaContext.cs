using Microsoft.EntityFrameworkCore;

namespace APIBiblioteca.Entidades
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Autor> Autor { get; set; } = null!;

        public DbSet<Libro> Libro { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Autor>().HasData(
                new Autor() { AutorId = 1, Nombre = "Gabriel García Márquez", Nacionalidad = "Colombiana", FechaNacimiento = new DateOnly(1927, 3, 6) },
                new Autor() { AutorId = 2, Nombre = "Stephen King", Nacionalidad = "Estadounidense", FechaNacimiento = new DateOnly(1947, 9, 21) },
                new Autor() { AutorId = 3, Nombre = "J.K. Rowling", Nacionalidad = "Britanica", FechaNacimiento = new DateOnly(1965, 7, 31) },
                new Autor() { AutorId = 4, Nombre = "Tolkien", Nacionalidad = "Britanica", FechaNacimiento = new DateOnly(1892, 1, 3) }
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
        }
    }
}

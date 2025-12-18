using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APIBiblioteca.Migrations
{
    /// <inheritdoc />
    public partial class CreacionTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    AutorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Nacionalidad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaNacimiento = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.AutorId);
                });

            migrationBuilder.CreateTable(
                name: "Libro",
                columns: table => new
                {
                    LibroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Publicacion = table.Column<int>(type: "int", nullable: false),
                    AutorFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libro", x => x.LibroId);
                    table.ForeignKey(
                        name: "FK_Libro_Autor_AutorFK",
                        column: x => x.AutorFK,
                        principalTable: "Autor",
                        principalColumn: "AutorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Autor",
                columns: new[] { "AutorId", "FechaNacimiento", "Nacionalidad", "Nombre" },
                values: new object[,]
                {
                    { 1, new DateOnly(1927, 3, 6), "Colombiana", "Gabriel García Márquez" },
                    { 2, new DateOnly(1947, 9, 21), "Estadounidense", "Stephen King" },
                    { 3, new DateOnly(1965, 7, 31), "Britanica", "J.K. Rowling" },
                    { 4, new DateOnly(1892, 1, 3), "Britanica", "Tolkien" }
                });

            migrationBuilder.InsertData(
                table: "Libro",
                columns: new[] { "LibroId", "AutorFK", "Publicacion", "Titulo" },
                values: new object[,]
                {
                    { 1, 1, 1967, "Cien Años de Soledad" },
                    { 2, 2, 1977, "El Resplandor" },
                    { 3, 3, 1997, "Harry Potter y la Piedra Filosofal" },
                    { 4, 4, 1954, "El Señor de los Anillos" },
                    { 5, 4, 1937, "El Hobbit" },
                    { 6, 2, 1986, "It" },
                    { 7, 1, 1981, "Crónica de una Muerte Anunciada" },
                    { 8, 3, 2007, "Harry Potter y las Reliquias de la Muerte" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Libro_AutorFK",
                table: "Libro",
                column: "AutorFK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Libro");

            migrationBuilder.DropTable(
                name: "Autor");
        }
    }
}

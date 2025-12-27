using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APIBiblioteca.Migrations
{
    /// <inheritdoc />
    public partial class CreacionTablaComentario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comentario",
                columns: table => new
                {
                    ComentarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Texto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaPublicacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LibroFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentario", x => x.ComentarioId);
                    table.ForeignKey(
                        name: "FK_Comentario_Libro_LibroFK",
                        column: x => x.LibroFK,
                        principalTable: "Libro",
                        principalColumn: "LibroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Comentario",
                columns: new[] { "ComentarioId", "FechaPublicacion", "LibroFK", "Texto" },
                values: new object[,]
                {
                    { new Guid("521d2529-a2d5-470e-a74c-95e0f4281b46"), new DateTime(2025, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Excelente libro, muy recomendable." },
                    { new Guid("535303b3-a3d0-4495-a7ad-bce547c20b5d"), new DateTime(2025, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "No me gustó mucho la trama." },
                    { new Guid("7995aed4-5a27-4bac-a80f-f09fb959c4c9"), new DateTime(2025, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Una lectura fascinante para todas las edades." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_LibroFK",
                table: "Comentario",
                column: "LibroFK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentario");
        }
    }
}

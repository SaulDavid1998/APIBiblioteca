using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIBiblioteca.Migrations
{
    /// <inheritdoc />
    public partial class AgregacionCamposClaseLibro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Autor",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Identificacion",
                table: "Autor",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Autor",
                keyColumn: "AutorId",
                keyValue: 1,
                columns: new[] { "Apellido", "Identificacion", "Nombre" },
                values: new object[] { "Márquez", "123", "Gabriel García" });

            migrationBuilder.UpdateData(
                table: "Autor",
                keyColumn: "AutorId",
                keyValue: 2,
                columns: new[] { "Apellido", "Identificacion", "Nombre" },
                values: new object[] { "King", "456", "Stephen" });

            migrationBuilder.UpdateData(
                table: "Autor",
                keyColumn: "AutorId",
                keyValue: 3,
                columns: new[] { "Apellido", "Identificacion", "Nombre" },
                values: new object[] { "Rowling", "789", "J.K." });

            migrationBuilder.UpdateData(
                table: "Autor",
                keyColumn: "AutorId",
                keyValue: 4,
                columns: new[] { "Apellido", "Identificacion", "Nombre" },
                values: new object[] { "Tolkien", "321", "J.R.R." });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Autor");

            migrationBuilder.DropColumn(
                name: "Identificacion",
                table: "Autor");

            migrationBuilder.UpdateData(
                table: "Autor",
                keyColumn: "AutorId",
                keyValue: 1,
                column: "Nombre",
                value: "Gabriel García Márquez");

            migrationBuilder.UpdateData(
                table: "Autor",
                keyColumn: "AutorId",
                keyValue: 2,
                column: "Nombre",
                value: "Stephen King");

            migrationBuilder.UpdateData(
                table: "Autor",
                keyColumn: "AutorId",
                keyValue: 3,
                column: "Nombre",
                value: "J.K. Rowling");

            migrationBuilder.UpdateData(
                table: "Autor",
                keyColumn: "AutorId",
                keyValue: 4,
                column: "Nombre",
                value: "Tolkien");
        }
    }
}

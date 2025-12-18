using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIBiblioteca.Migrations
{
    /// <inheritdoc />
    public partial class ColumnaDescripcion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Libro",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Libro",
                keyColumn: "LibroId",
                keyValue: 1,
                column: "Descripcion",
                value: "");

            migrationBuilder.UpdateData(
                table: "Libro",
                keyColumn: "LibroId",
                keyValue: 2,
                column: "Descripcion",
                value: "");

            migrationBuilder.UpdateData(
                table: "Libro",
                keyColumn: "LibroId",
                keyValue: 3,
                column: "Descripcion",
                value: "");

            migrationBuilder.UpdateData(
                table: "Libro",
                keyColumn: "LibroId",
                keyValue: 4,
                column: "Descripcion",
                value: "");

            migrationBuilder.UpdateData(
                table: "Libro",
                keyColumn: "LibroId",
                keyValue: 5,
                column: "Descripcion",
                value: "");

            migrationBuilder.UpdateData(
                table: "Libro",
                keyColumn: "LibroId",
                keyValue: 6,
                column: "Descripcion",
                value: "");

            migrationBuilder.UpdateData(
                table: "Libro",
                keyColumn: "LibroId",
                keyValue: 7,
                column: "Descripcion",
                value: "");

            migrationBuilder.UpdateData(
                table: "Libro",
                keyColumn: "LibroId",
                keyValue: 8,
                column: "Descripcion",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Libro");
        }
    }
}

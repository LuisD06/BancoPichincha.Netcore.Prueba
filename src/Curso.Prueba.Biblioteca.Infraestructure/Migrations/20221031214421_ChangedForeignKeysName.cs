using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Curso.Prueba.Biblioteca.Infraestructure.Migrations
{
    public partial class ChangedForeignKeysName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdAutor",
                table: "Libros");

            migrationBuilder.DropColumn(
                name: "IdEditorial",
                table: "Libros");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdAutor",
                table: "Libros",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdEditorial",
                table: "Libros",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}

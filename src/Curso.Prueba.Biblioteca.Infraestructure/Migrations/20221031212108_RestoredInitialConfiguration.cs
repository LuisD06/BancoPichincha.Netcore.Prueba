using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Curso.Prueba.Biblioteca.Infraestructure.Migrations
{
    public partial class RestoredInitialConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Autores_AutorId",
                table: "Libros");

            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Editoriales_EditorialId",
                table: "Libros");

            migrationBuilder.AlterColumn<int>(
                name: "EditorialId",
                table: "Libros",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AutorId",
                table: "Libros",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Autores_AutorId",
                table: "Libros",
                column: "AutorId",
                principalTable: "Autores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Editoriales_EditorialId",
                table: "Libros",
                column: "EditorialId",
                principalTable: "Editoriales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Autores_AutorId",
                table: "Libros");

            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Editoriales_EditorialId",
                table: "Libros");

            migrationBuilder.DropColumn(
                name: "IdAutor",
                table: "Libros");

            migrationBuilder.DropColumn(
                name: "IdEditorial",
                table: "Libros");

            migrationBuilder.AlterColumn<int>(
                name: "EditorialId",
                table: "Libros",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "AutorId",
                table: "Libros",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Autores_AutorId",
                table: "Libros",
                column: "AutorId",
                principalTable: "Autores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Editoriales_EditorialId",
                table: "Libros",
                column: "EditorialId",
                principalTable: "Editoriales",
                principalColumn: "Id");
        }
    }
}

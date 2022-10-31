

using Curso.Prueba.Biblioteca.Domain;
using Curso.Prueba.Biblioteca.Domain.models;
using Microsoft.EntityFrameworkCore;

namespace Curso.Prueba.Biblioteca.Infraestructure
{
    public class BibliotecaDbContext : DbContext
    {
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Editorial> Editoriales { get; set; }
        public DbSet<Autor> Autores { get; set; }

        public string DbPath { get; set; }
        public BibliotecaDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "curso.prueba.biblioteca.db");

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
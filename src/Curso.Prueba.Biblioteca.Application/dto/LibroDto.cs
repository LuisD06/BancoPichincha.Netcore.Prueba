using System.ComponentModel.DataAnnotations;
using Curso.Prueba.Biblioteca.Domain;

namespace Curso.Prueba.Biblioteca.Application
{
    public class LibroDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        public DateTime FechaPublicacion { get; set;}

        public Generos Genero { get; set; }

        [Required]
        public int IdAutor { get; set; }
        public string Autor { get; set; }

        [Required]
        public int IdEditorial { get; set; }
        public string Editorial { get; set; }
    }
}
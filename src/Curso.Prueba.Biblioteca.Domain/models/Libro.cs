using System.ComponentModel.DataAnnotations;
using Curso.Prueba.Biblioteca.Domain.models;

namespace Curso.Prueba.Biblioteca.Domain
{
    public class Libro
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        public DateTime FechaPublicacion { get; set;}

        public Generos Genero { get; set; }

        [Required]        
        public int AutorId { get; set; }
        public virtual Autor Autor { get; set; }

        [Required]
        public int EditorialId { get; set; }
        public virtual Editorial Editorial { get; set; }

    }
}
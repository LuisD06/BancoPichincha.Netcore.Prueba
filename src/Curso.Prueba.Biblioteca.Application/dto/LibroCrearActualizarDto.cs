using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Curso.Prueba.Biblioteca.Domain;

namespace Curso.Prueba.Biblioteca.Application
{
    public class LibroCrearActualizarDto
    {

        [Required]
        public string Titulo { get; set; }

        public DateTime FechaPublicacion { get; set;}

        public Generos Genero { get; set; }

        [Required]
        public int IdAutor { get; set; }
        [Required]
        public int IdEditorial { get; set; }
    }
}
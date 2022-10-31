using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.Prueba.Biblioteca.Domain.models
{
    public class Autor
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Pais { get; set; }
    }
}
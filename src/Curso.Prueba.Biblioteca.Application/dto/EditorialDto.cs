using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.Prueba.Biblioteca.Application.dto
{
    public class EditorialDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Pais { get; set; }
        public string Tipo { get; set; }
    }
}
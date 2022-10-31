using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.Prueba.Biblioteca.Application.dto
{
    public class AutorCrearActualizarDto
    {
        [Required]
        public string Nombre { get; set; }
        public string Pais { get; set; }
    }
}
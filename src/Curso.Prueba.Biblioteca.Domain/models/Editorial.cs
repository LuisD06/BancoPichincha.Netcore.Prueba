
using System.ComponentModel.DataAnnotations;


namespace Curso.Prueba.Biblioteca.Domain
{
    public class Editorial
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
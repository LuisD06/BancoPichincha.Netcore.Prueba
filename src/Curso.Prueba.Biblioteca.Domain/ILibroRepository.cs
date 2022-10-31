using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.Prueba.Biblioteca.Domain
{
    public interface ILibroRepository : IRepository<Libro> 
    {
        Task<bool> ExisteTitulo (string titulo);
        Task<bool> ExisteTitulo (string titulo, int id);
    }
}
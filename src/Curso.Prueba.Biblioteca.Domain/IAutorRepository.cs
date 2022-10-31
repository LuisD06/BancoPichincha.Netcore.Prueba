using Curso.Prueba.Biblioteca.Domain.models;

namespace Curso.Prueba.Biblioteca.Domain
{
    public interface IAutorRepository : IRepository<Autor>
    {
        Task<bool> ExisteAutor (string nombre);
        Task<bool> ExisteAutor (string nombre, int id);
    }
}
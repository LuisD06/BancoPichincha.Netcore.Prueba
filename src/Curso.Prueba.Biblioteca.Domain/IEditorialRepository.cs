namespace Curso.Prueba.Biblioteca.Domain
{
    public interface IEditorialRepository : IRepository<Editorial>
    {
        Task<bool> ExisteEditorial (string nombre);
        Task<bool> ExisteEditorial (string nombre, int id);
    }
}
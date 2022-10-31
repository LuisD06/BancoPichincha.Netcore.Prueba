using Curso.Prueba.Biblioteca.Domain;
using Curso.Prueba.Biblioteca.Domain.models;
using Microsoft.EntityFrameworkCore;

namespace Curso.Prueba.Biblioteca.Infraestructure
{
    public class AutorRepository : EfRepository<Autor>, IAutorRepository
    {
        public AutorRepository(BibliotecaDbContext context) : base(context)
        {
        }

        public async Task<bool> ExisteAutor(string nombre)
        {
            var resultado = await this._context.Set<Autor>()
                           .AnyAsync(x => x.Nombre.ToUpper() == nombre.ToUpper());

            return resultado;
        }

        public async Task<bool> ExisteAutor(string nombre, int id)
        {
            var query = this._context.Set<Autor>()
                           .Where(x => x.Id != id)
                           .Where(x => x.Nombre.ToUpper() == nombre.ToUpper())
                           ;

            var resultado = await query.AnyAsync();

            return resultado;
        }
    }
}
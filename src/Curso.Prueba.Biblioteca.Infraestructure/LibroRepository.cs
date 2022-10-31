using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso.Prueba.Biblioteca.Domain;
using Microsoft.EntityFrameworkCore;

namespace Curso.Prueba.Biblioteca.Infraestructure
{
    public class LibroRepository : EfRepository<Libro>, ILibroRepository
    {
        public LibroRepository(BibliotecaDbContext context) : base(context)
        {
        }

        public async Task<bool> ExisteTitulo(string titulo)
        {
            var resultado = await this._context.Set<Libro>()
                           .AnyAsync(x => x.Titulo.ToUpper() == titulo.ToUpper());

            return resultado;
        }

        public async Task<bool> ExisteTitulo(string titulo, int id)
        {
            var query = this._context.Set<Libro>()
                           .Where(x => x.Id != id)
                           .Where(x => x.Titulo.ToUpper() == titulo.ToUpper())
                           ;

            var resultado = await query.AnyAsync();

            return resultado;
        }
    }
}
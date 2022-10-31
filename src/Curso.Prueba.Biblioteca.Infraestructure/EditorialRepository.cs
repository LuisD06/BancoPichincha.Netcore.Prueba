using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso.Prueba.Biblioteca.Domain;
using Microsoft.EntityFrameworkCore;

namespace Curso.Prueba.Biblioteca.Infraestructure
{
    public class EditorialRepository : EfRepository<Editorial>, IEditorialRepository
    {
        public EditorialRepository(BibliotecaDbContext context) : base(context)
        {
        }

        public async Task<bool> ExisteEditorial(string nombre)
        {
            var resultado = await this._context.Set<Editorial>()
                           .AnyAsync(x => x.Nombre.ToUpper() == nombre.ToUpper());

            return resultado;
        }

        public async Task<bool> ExisteEditorial(string nombre, int id)
        {
            var query = this._context.Set<Editorial>()
                           .Where(x => x.Id != id)
                           .Where(x => x.Nombre.ToUpper() == nombre.ToUpper())
                           ;

            var resultado = await query.AnyAsync();

            return resultado;
        }
    }
}
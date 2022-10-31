using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso.Prueba.Biblioteca.Domain;

namespace Curso.Prueba.Biblioteca.Application
{
    public class LibroAppService : ILibroAppService
    {
        private readonly ILibroRepository repository;
        public LibroAppService(ILibroRepository repository)
        {
            this.repository = repository;

        }
        public async Task<LibroDto> CreateAsync(LibroCrearActualizarDto libro)
        {
            //Reglas Validaciones... 
            var existeLibro = await repository.ExisteTitulo(libro.Titulo);
            if (existeLibro)
            {
                throw new ArgumentException($"Ya existe un libro con el título {libro.Titulo}");
            }

            if (libro.Genero != Generos.NOVELA && libro.Genero != Generos.CIENCIA_FICCION) {
                throw new ArgumentException($"El género indicado no existe. Disponibles: 0(Novela), 1(Ciencia Ficcion)");
            }

            //Mapeo Dto => Entidad
            var libroEntidad = new Libro();
            libroEntidad.Titulo = libro.Titulo;
            libroEntidad.FechaPublicacion = libro.FechaPublicacion;
            libroEntidad.Genero = libro.Genero;
            libroEntidad.AutorId = libro.IdAutor;
            libroEntidad.EditorialId = libro.IdEditorial;

            

            //Persistencia objeto
            libroEntidad = await repository.AddAsync(libroEntidad);

            //Mapeo Entidad => Dto
            var listaLibrosConsulta = repository.GetAllIncluding(l => l.Autor, libro => libro.Editorial);
            var libroCreadoEntidad = listaLibrosConsulta.Where(l => l.Id == libroEntidad.Id).SingleOrDefault();
            var libroCreado = new LibroDto();
            libroCreado.Titulo = libroCreadoEntidad.Titulo;
            libroCreado.Id = libroCreadoEntidad.Id;
            libroCreado.FechaPublicacion = libroCreadoEntidad.FechaPublicacion;
            libroCreado.Genero = libroCreadoEntidad.Genero;
            libroCreado.IdAutor = libroCreadoEntidad.AutorId;
            libroCreado.IdEditorial = libroCreadoEntidad.EditorialId;
            libroCreado.Autor = libroCreadoEntidad.Autor.Nombre;
            libroCreado.Editorial = libroCreadoEntidad.Editorial.Nombre;

            //TODO: Enviar un correo electronica... 

            return libroCreado;
        }

        public async Task<bool> DeleteAsync(int libroId)
        {
            //Reglas Validaciones... 
            var libro = await repository.GetByIdAsync(libroId);
            if (libro == null)
            {
                throw new ArgumentException($"El libro con el id: {libroId}, no existe");
            }

            repository.Delete(libro);

            return true;
        }

        public ICollection<LibroDto> GetAll()
        {
            var listaLibrosConsulta = repository.GetAllIncluding(l => l.Autor, l => l.Editorial);
            var listaLibros = listaLibrosConsulta.Select(l => new LibroDto()
            {
                Autor = l.Autor.Nombre,
                Editorial = l.Editorial.Nombre,
                FechaPublicacion = l.FechaPublicacion,
                Genero = l.Genero,
                Id = l.Id,
                IdAutor = l.AutorId,
                IdEditorial = l.EditorialId,
                Titulo = l.Titulo
            });

            return listaLibros.ToList();
        }

        public async Task UpdateAsync(int id, LibroCrearActualizarDto libro)
        {
            var libroEntidad = await repository.GetByIdAsync(id);
            if (libroEntidad == null)
            {
                throw new ArgumentException($"El libro con el id: {id}, no existe");
            }

            var existeLibro = await repository.ExisteTitulo(libro.Titulo, id);
            if (existeLibro)
            {
                throw new ArgumentException($"Ya existe un libro con el nombre {libro.Titulo}");
            }

            if (libro.Genero != Generos.NOVELA && libro.Genero != Generos.CIENCIA_FICCION) {
                throw new ArgumentException($"El género indicado no existe. Disponibles: 0(Novela), 1(Ciencia Ficcion)");
            }

            //Mapeo Dto => Entidad
            libroEntidad.AutorId = libro.IdAutor;
            libroEntidad.EditorialId = libro.IdEditorial;
            libroEntidad.Titulo = libro.Titulo;
            libroEntidad.FechaPublicacion = libro.FechaPublicacion;
            libroEntidad.Genero = libro.Genero;
            //Persistencia objeto
            await repository.UpdateAsync(libroEntidad);

            return;
        }
    }
}
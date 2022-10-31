using Curso.Prueba.Biblioteca.Application.dto;
using Curso.Prueba.Biblioteca.Domain;
using Curso.Prueba.Biblioteca.Domain.models;

namespace Curso.Prueba.Biblioteca.Application
{
    public class AutorAppSerivce : IAutorAppService
    {
        private readonly IAutorRepository repository;
        public AutorAppSerivce(IAutorRepository repository)
        {
            this.repository = repository;

        }
        public async Task<AutorDto> CreateAsync(AutorCrearActualizarDto autor)
        {
            //Reglas Validaciones... 
            var existeAutor = await repository.ExisteAutor(autor.Nombre);
            if (existeAutor)
            {
                throw new ArgumentException($"Ya existe un autor con el nombre {autor.Nombre}");
            }

            //Mapeo Dto => Entidad
            var autorEntidad = new Autor();
            autorEntidad.Nombre = autor.Nombre;
            autorEntidad.Pais = autor.Pais;


            //Persistencia objeto
            autorEntidad = await repository.AddAsync(autorEntidad);


            //Mapeo Entidad => Dto
            var autorCreado = new AutorDto();
            autorCreado.Id = autorEntidad.Id;
            autorCreado.Nombre = autorEntidad.Nombre;
            autorCreado.Pais = autorEntidad.Pais;


            //TODO: Enviar un correo electronica... 

            return autorCreado;
        }

        public async Task<bool> DeleteAsync(int autorId)
        {
            //Reglas Validaciones... 
            var autorEntidad = await repository.GetByIdAsync(autorId);
            if (autorEntidad == null)
            {
                throw new ArgumentException($"El autor con el id: {autorId}, no existe");
            }

            repository.Delete(autorEntidad);

            return true;
        }

        public ICollection<AutorDto> GetAll()
        {
            var autorList = repository.GetAll();

            var autorListDto = from a in autorList
                               select new AutorDto()
                               {
                                   Id = a.Id,
                                   Nombre = a.Nombre,
                                   Pais = a.Pais,
                               };

            return autorListDto.ToList();
        }

        public async Task UpdateAsync(int id, AutorCrearActualizarDto autor)
        {
            var autorEntidad = await repository.GetByIdAsync(id);
            if (autorEntidad == null)
            {
                throw new ArgumentException($"El autoir con el id: {id}, no existe");
            }

            var existeAutor = await repository.ExisteAutor(autor.Nombre, id);
            if (existeAutor)
            {
                throw new ArgumentException($"Ya existe un autor con el nombre {autor.Nombre}");
            }

            //Mapeo Dto => Entidad
            autorEntidad.Nombre = autor.Nombre;
            autorEntidad.Pais = autor.Pais;

            //Persistencia objeto
            await repository.UpdateAsync(autorEntidad);

            return;
        }
    }
}
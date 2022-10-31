using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso.Prueba.Biblioteca.Application.dto;
using Curso.Prueba.Biblioteca.Domain;

namespace Curso.Prueba.Biblioteca.Application
{
    public class EditorialAppService : IEditorialAppService
    {
        private readonly IEditorialRepository repository;

        public EditorialAppService(IEditorialRepository repository)
        {
            this.repository = repository;

        }
        public async Task<EditorialDto> CreateAsync(EditorialCrearActualizarDto editorial)
        {
            //Reglas Validaciones... 
            var existeEditorial = await repository.ExisteEditorial(editorial.Nombre);
            if (existeEditorial)
            {
                throw new ArgumentException($"Ya existe una editorial con el nombre {editorial.Nombre}");
            }

            //Mapeo Dto => Entidad
            var editorialEntidad = new Editorial();
            editorialEntidad.Nombre = editorial.Nombre;
            editorialEntidad.Pais = editorial.Pais;
            editorialEntidad.Tipo = editorial.Tipo;


            //Persistencia objeto
            editorialEntidad = await repository.AddAsync(editorialEntidad);

            //Mapeo Entidad => Dto
            var editorialCreada = new EditorialDto();
            editorialCreada.Id = editorialEntidad.Id;
            editorialCreada.Nombre = editorialEntidad.Nombre;
            editorialCreada.Pais = editorialEntidad.Pais;
            editorialCreada.Tipo = editorialEntidad.Tipo;

            //TODO: Enviar un correo electronica... 

            return editorialCreada;
        }

        public async Task<bool> DeleteAsync(int editorialId)
        {
            //Reglas Validaciones... 
            var editorialentidad = await repository.GetByIdAsync(editorialId);
            if (editorialentidad == null)
            {
                throw new ArgumentException($"La entidad con el id: {editorialId}, no existe");
            }

            repository.Delete(editorialentidad);

            return true;
        }

        public ICollection<EditorialDto> GetAll()
        {
            var editorialList = repository.GetAll();

            var editoriaListDto = from e in editorialList
                               select new EditorialDto()
                               {
                                   Id = e.Id,
                                   Nombre = e.Nombre,
                                   Pais = e.Pais,
                                   Tipo = e.Tipo
                               };

            return editoriaListDto.ToList();
        }

        public async Task UpdateAsync(int id, EditorialCrearActualizarDto editorial)
        {
            var editorialEntidad = await repository.GetByIdAsync(id);
            if (editorialEntidad == null)
            {
                throw new ArgumentException($"La editorial con el id: {id}, no existe");
            }

            var existeEditorial = await repository.ExisteEditorial(editorial.Nombre, id);
            if (existeEditorial)
            {
                throw new ArgumentException($"Ya existe una editorial con el nombre {editorial.Nombre}");
            }

            //Mapeo Dto => Entidad
            editorialEntidad.Nombre = editorial.Nombre;
            editorialEntidad.Pais = editorial.Pais;
            editorialEntidad.Tipo = editorial.Tipo;

            //Persistencia objeto
            await repository.UpdateAsync(editorialEntidad);

            return;
        }
    }
}
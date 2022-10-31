using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso.Prueba.Biblioteca.Application;
using Curso.Prueba.Biblioteca.Application.dto;
using Microsoft.AspNetCore.Mvc;

namespace Curso.Prueba.Biblioteca.HttpApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EditorialController : ControllerBase
    {
        private readonly IEditorialAppService service;
        public EditorialController(IEditorialAppService service)
        {
            this.service = service;
        }
        [HttpGet]
        public ICollection<EditorialDto> GetAll()
        {

            return service.GetAll();
        }

        [HttpPost]
        public async Task<EditorialDto> CreateAsync(EditorialCrearActualizarDto editorial)
        {

            return await service.CreateAsync(editorial);

        }

        [HttpPut]
        public async Task UpdateAsync(int id, EditorialCrearActualizarDto editorial)
        {

            await service.UpdateAsync(id, editorial);

        }

        [HttpDelete]
        public async Task<bool> DeleteAsync(int editorialId)
        {

            return await service.DeleteAsync(editorialId);

        }
    }
}
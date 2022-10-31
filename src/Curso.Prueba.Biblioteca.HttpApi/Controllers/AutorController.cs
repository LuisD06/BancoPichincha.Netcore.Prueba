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
    public class AutorController : ControllerBase
    {
        private readonly IAutorAppService service;
        public AutorController(IAutorAppService service)
        {
            this.service = service;
        }
        [HttpGet]
        public ICollection<AutorDto> GetAll()
        {

            return service.GetAll();
        }

        [HttpPost]
        public async Task<AutorDto> CreateAsync(AutorCrearActualizarDto autor)
        {

            return await service.CreateAsync(autor);

        }

        [HttpPut]
        public async Task UpdateAsync(int id, AutorCrearActualizarDto autor)
        {

            await service.UpdateAsync(id, autor);

        }

        [HttpDelete]
        public async Task<bool> DeleteAsync(int autorId)
        {

            return await service.DeleteAsync(autorId);

        }
    }
}
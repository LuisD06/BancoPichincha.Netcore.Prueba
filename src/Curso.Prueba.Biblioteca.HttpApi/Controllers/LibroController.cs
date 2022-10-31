using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso.Prueba.Biblioteca.Application;
using Microsoft.AspNetCore.Mvc;

namespace Curso.Prueba.Biblioteca.HttpApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibroController : ControllerBase
    {
        private readonly ILibroAppService service;

        public LibroController(ILibroAppService service)
        {
            this.service = service;
        }
        [HttpGet]
        public ICollection<LibroDto> GetAll()
        {

            return service.GetAll();
        }

        [HttpPost]
        public async Task<LibroDto> CreateAsync(LibroCrearActualizarDto libro)
        {

            return await service.CreateAsync(libro);

        }

        [HttpPut]
        public async Task UpdateAsync(int id, LibroCrearActualizarDto libro)
        {

            await service.UpdateAsync(id, libro);

        }

        [HttpDelete]
        public async Task<bool> DeleteAsync(int libroId)
        {

            return await service.DeleteAsync(libroId);

        }
    }
}
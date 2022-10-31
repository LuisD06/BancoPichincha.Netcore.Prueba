using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso.Prueba.Biblioteca.Application.dto;

namespace Curso.Prueba.Biblioteca.Application
{
    public interface IAutorAppService
    {
        ICollection<AutorDto> GetAll();

        Task<AutorDto> CreateAsync(AutorCrearActualizarDto autor);

        Task UpdateAsync(int id, AutorCrearActualizarDto autor);

        Task<bool> DeleteAsync(int autorId);
    }
}
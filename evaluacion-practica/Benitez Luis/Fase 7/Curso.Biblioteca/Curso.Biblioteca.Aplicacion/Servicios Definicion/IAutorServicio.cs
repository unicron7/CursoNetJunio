using Curso.Biblioteca.Aplicacion.Dto;
using Curso.Biblioteca.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Aplicacion.Servicios_Definicion
{
    public interface IAutorServicio
    {
        IQueryable<AutorDto> GetAllAsync();
        Task CreateAsync(AutorDto autor);
        Task UpdateAsync(AutorDto autor);
        Task DeleteAsync(AutorDto autor);
    }
}

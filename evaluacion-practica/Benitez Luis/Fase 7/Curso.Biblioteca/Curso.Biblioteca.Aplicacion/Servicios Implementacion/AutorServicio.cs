using Curso.Biblioteca.Aplicacion.Dto;
using Curso.Biblioteca.Aplicacion.Servicios_Definicion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Aplicacion.Servicios_Implementacion
{
    internal class AutorServicio : IAutorServicio
    {
        public Task CreateAsync(AutorDto autor)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(AutorDto autor)
        {
            throw new NotImplementedException();
        }

        public IQueryable<AutorDto> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(AutorDto autor)
        {
            throw new NotImplementedException();
        }
    }
}

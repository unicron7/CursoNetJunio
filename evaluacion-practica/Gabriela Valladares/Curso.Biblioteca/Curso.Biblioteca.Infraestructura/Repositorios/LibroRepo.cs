using Curso.Biblioteca.Dominio.Entidades;
using Curso.Biblioteca.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Infraestructura.Repositorios
{
    public class LibroRepo : ILibroRepo
    {
        public Task CreateAsync(Libro libro)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Libro libro)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Libro> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Libro libro)
        {
            throw new NotImplementedException();
        }
    }
}

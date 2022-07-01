using Curso.Biblioteca.Dominio.Entidades;
using Curso.Biblioteca.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Infraestructura.Repositorios
{
    public class EditorialRepo : IEditorialRepo
    {
        public Task CreateAsync(Editorial editorial)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Editorial editorial)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Editorial> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Editorial editorial)
        {
            throw new NotImplementedException();
        }
    }
}

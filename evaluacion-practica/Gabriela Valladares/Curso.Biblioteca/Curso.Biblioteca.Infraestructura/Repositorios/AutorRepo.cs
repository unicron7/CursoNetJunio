using Curso.Biblioteca.Dominio.Entidades;
using Curso.Biblioteca.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Infraestructura.Repositorios
{
    public class AutorRepo : IAutorRepo
    {
        public Task CreateAsync(Autor autor)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Autor autor)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Autor> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Autor autor)
        {
            throw new NotImplementedException();
        }
    }
}

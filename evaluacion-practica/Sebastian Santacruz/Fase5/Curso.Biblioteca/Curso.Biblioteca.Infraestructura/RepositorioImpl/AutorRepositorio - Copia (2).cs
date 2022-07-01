using Curso.Biblioteca.Dominio.Entidades;
using Curso.Biblioteca.Dominio.RepositorioInterfaz;
using Curso.Biblioteca.Infraestructura.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Infraestructura.RepositorioImpl
{
    public class EditorialRepositorio : IEditorialRepositorio
    {
        private readonly BibliotecaContext context;

        public EditorialRepositorio(BibliotecaContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Editorial editorial)
        {
            await context.AddAsync(editorial);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Editorial editorial)
        {
            context.Remove(editorial);
            await context.SaveChangesAsync();
        }

        public IQueryable<Editorial> GetAll()
        {
            return context.editorials.AsQueryable();
        }

        public async Task UpdateAsync(Editorial editorial)
        {
            context.Update(editorial);
            await context.SaveChangesAsync();
        }
    }
}

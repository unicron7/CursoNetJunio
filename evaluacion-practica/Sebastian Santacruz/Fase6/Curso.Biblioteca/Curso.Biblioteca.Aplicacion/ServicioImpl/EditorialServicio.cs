using Curso.Biblioteca.Aplicacion.ServicioInterfaz;
using Curso.Biblioteca.Dominio.Entidades;
using Curso.Biblioteca.Dominio.RepositorioInterfaz;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Aplicacion.ServicioImpl
{
    public class EditorialServicio : IEditorialServicio
    {
        private readonly IEditorialRepositorio editorialRepositorio;

        public EditorialServicio(IEditorialRepositorio editorialRepositorio)
        {
            this.editorialRepositorio = editorialRepositorio;
        }

        public async Task<Editorial> AddAsync(Editorial editorial)
        {
            await editorialRepositorio.AddAsync(editorial);
            return editorial;
        }

        public async Task<bool> DeleteByIdAsync(int Id)
        {
            var editorial = await GetByIdAsync(Id);
            await editorialRepositorio.DeleteAsync(editorial);
            return true;
        }

        public async Task<ICollection<Editorial>> GetAllAsync()
        {
            var consulta = editorialRepositorio.GetAll();
            var lista = await consulta.ToListAsync();
            return lista;
        }

        public async Task<Editorial> GetByIdAsync(int Id)
        {
            var consulta = editorialRepositorio.GetAll();
            consulta = consulta.Where(x => x.Id == Id);
            var editorial = await consulta.FirstOrDefaultAsync();
            return editorial;
        }

        public async Task<Editorial> UpdateAsync(Editorial editorial)
        {
            await editorialRepositorio.UpdateAsync(editorial);
            return editorial;
        }
    }
}

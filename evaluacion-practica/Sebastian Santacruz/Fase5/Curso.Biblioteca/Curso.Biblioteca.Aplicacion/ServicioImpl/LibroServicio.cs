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
    public class LibroServicio : ILibroServicio
    {
        private readonly ILibroRepositorio libroRepositorio;

        public LibroServicio(ILibroRepositorio libroRepositorio)
        {
            this.libroRepositorio = libroRepositorio;
        }

        public async Task<Libro> AddAsync(Libro libro)
        {
            await libroRepositorio.AddAsync(libro);
            return libro;
        }

        public async Task<bool> DeleteByIdAsync(Libro libro)
        {
            await libroRepositorio.DeleteAsync(libro);
            return true;
        }

        public async Task<ICollection<Libro>> GetAllAsync()
        {
            var consulta = libroRepositorio.GetAll();
            var lista = await consulta.ToListAsync();
            return lista;
        }

        public async Task<Libro> GetByIdAsync(int Id)
        {
            var consulta = libroRepositorio.GetAll();
            consulta = consulta.Where(x => x.Id == Id);
            var libro = await consulta.FirstOrDefaultAsync();
            return libro;
        }

        public async Task<Libro> UpdateAsync(Libro libro)
        {
            await libroRepositorio.UpdateAsync(libro);
            return libro;
        }
    }
}

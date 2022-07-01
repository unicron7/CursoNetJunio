using Curso.Biblioteca.Aplicacion.Dto;
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

        public async Task<Libro> AddAsync(LibroDto libroDto)
        {
            var libro = new Libro
            {
                Id = libroDto.Id,
                Titulo = libroDto.Titulo,
                ISBN = libroDto.ISBN,
                AutorId = libroDto.AutorId,
                EditorialId = libroDto.EditorialId,
            };
            await libroRepositorio.AddAsync(libro);
            return libro;
        }

        public async Task<bool> DeleteByIdAsync(int Id)
        {
            var libro = await GetByIdAsync(Id); 
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

        public async Task<Libro> UpdateAsync(LibroDto libroDto)
        {
            var libro = new Libro
            {
                Id = libroDto.Id,
                Titulo = libroDto.Titulo,
                ISBN = libroDto.ISBN,
                AutorId = libroDto.AutorId,
                EditorialId = libroDto.EditorialId,
            };
            await libroRepositorio.UpdateAsync(libro);
            return libro;
        }
    }
}

using Curso.Biblioteca.Aplicacion.Dto;
using Curso.Biblioteca.Aplicacion.Servicios_Definicion;
using Curso.Biblioteca.Dominio.Entidades;
using Curso.Biblioteca.Dominio.IRepositoriosDefinicion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Aplicacion.Servicios_Implementacion
{
    public class LibroServicio : ILibroServicio
    {
        protected readonly ILibroRepositorio libroRepositorio;

        public LibroServicio(ILibroRepositorio libroRepositorio)
        {
            this.libroRepositorio = libroRepositorio;
        }

        public async Task<bool> CreateAsync(CrearLibroDto libroDto)
        {
            var libro = new Libro
            {
                Titulo = libroDto.Titulo,
                ISBN = libroDto.ISBN,
                AutorId = libroDto.AutorId,
                EditorialId = libroDto.EditorialId
            };
            await libroRepositorio.CreateAsync(libro);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var consulta = libroRepositorio.GetAll();
            consulta = consulta.Where(c => c.Id == id);
            var libro = consulta.SingleOrDefault();
            await libroRepositorio.DeleteAsync(libro);
            return true;
        }

        public async Task<ICollection<LibroDto>> GetAllAsync()
        {
            var consulta = libroRepositorio.GetAll();
            var listaLibros = await consulta.Select(x => new LibroDto
            {
                Id = x.Id,
                Titulo = x.Titulo,
                ISBN = x.ISBN,
                Autor = $"{x.Autor.Nombre} {x.Autor.Apellido}",
                Editorial = x.Editorial.Nombre
            }).ToListAsync();
            return listaLibros;
        }

        public async Task<LibroDto> GetByIdAsync(int id)
        {
            var consulta = libroRepositorio.GetAll();
            consulta = consulta.Where(c => c.Id == id);
            var libro = await consulta.Select(x => new LibroDto
            {
                Id = x.Id,
                Titulo = x.Titulo,
                ISBN = x.ISBN,
                Autor = $"{x.Autor.Nombre} {x.Autor.Apellido}",
                Editorial = x.Editorial.Nombre
            }).SingleOrDefaultAsync();
            return libro;
        }

        public async Task<bool> UpdateAsync(int id, CrearLibroDto libroDto)
        {
            var consulta = libroRepositorio.GetAll();
            consulta = consulta.Where(c => c.Id == id);
            var libro = consulta.SingleOrDefault();
            libro.Titulo = libroDto.Titulo;
            libro.ISBN = libroDto.ISBN;
            libro.AutorId = libroDto.AutorId;
            libro.EditorialId = libroDto.EditorialId;
            await libroRepositorio.UpdateAsync(libro);
            return true;
        }
    }
}

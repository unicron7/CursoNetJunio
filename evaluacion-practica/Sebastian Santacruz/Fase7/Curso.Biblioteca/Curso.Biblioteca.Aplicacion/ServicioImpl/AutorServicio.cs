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
    public class AutorServicio : IAutorServicio
    {
        private readonly IAutorRepositorio autorRepositorio;

        public AutorServicio(IAutorRepositorio autorRepositorio)
        {
            this.autorRepositorio = autorRepositorio;
        }

        public async Task<Autor> AddAsync(Autor autor)
        {
            await autorRepositorio.AddAsync(autor);
            return autor;
        }

        public async Task<bool> DeleteByIdAsync(int Id)
        {
            var autor = await GetByIdAsync(Id);
            await autorRepositorio.DeleteAsync(autor);
            return true;
        }

        public async Task<ICollection<Autor>> GetAllAsync()
        {
            var consulta = autorRepositorio.GetAll();
            var lista = await consulta.ToListAsync();
            return lista;
        }

        public async Task<Autor> GetByIdAsync(int Id)
        {
            var consulta = autorRepositorio.GetAll();
            consulta = consulta.Where(x => x.Id == Id);
            var autor = await consulta.FirstOrDefaultAsync();
            return autor;
        }

        public async Task<Autor> UpdateAsync(Autor autor)
        {
            await autorRepositorio.UpdateAsync(autor);
            return autor;
        }
    }
}

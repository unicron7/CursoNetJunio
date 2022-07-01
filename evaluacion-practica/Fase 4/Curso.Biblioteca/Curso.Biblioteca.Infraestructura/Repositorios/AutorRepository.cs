﻿using Curso.Biblioteca.Dominio.Entidades;
using Curso.Biblioteca.Dominio.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Infraestructura.Repositorios
{
    public class AutorRepository : IAutorRepository
    {

        private readonly BibliotecaDbContext context;

        public AutorRepository(BibliotecaDbContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(Autor entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Autor entity)
        {
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<ICollection<Autor>> GetAllAsync()
        {
            return await context.Autores.ToListAsync();
        }

        public async Task UpdateAsync(Autor entity)
        {
            context.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}

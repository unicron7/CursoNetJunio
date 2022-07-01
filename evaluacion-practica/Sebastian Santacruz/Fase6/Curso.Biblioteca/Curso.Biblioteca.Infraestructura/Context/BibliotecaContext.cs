using Curso.Biblioteca.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Infraestructura.Context
{
    public class BibliotecaContext : DbContext
    {
        private readonly DbContextOptions options;

        public BibliotecaContext(DbContextOptions options) : base(options)
        {
            this.options = options;
        }

        public DbSet<Autor> autors { get; set; }
        public DbSet<Editorial> editorials { get; set; }
        public DbSet<Libro> Libros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
            var path = @"Server=(localdb)\mssqllocaldb;Database=Biblioteca;Trusted_Connection=True";
            optionsBuilder.UseSqlServer(path);
        }

    }
}

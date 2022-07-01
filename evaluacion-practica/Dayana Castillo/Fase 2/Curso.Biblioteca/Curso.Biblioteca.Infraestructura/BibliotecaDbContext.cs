
using Curso.Biblioteca.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Curso.Biblioteca.Infraestructura
{
    public class BibliotecaDbContext:DbContext
    {
        public BibliotecaDbContext(DbContextOptions options):base(options)   //aqui creo mi clkase base
        {
        
        }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Editorial> Editoriales { get; set; }
        public DbSet<Libro> Libros { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            var conexion = @"server=(localdb)\mssqllocaldb;database=biblioteca;trusted_connection=true";
            optionsBuilder.UseSqlServer(conexion);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)//Configuracion de entidades
            //se separan las utilizando clases y se implementa la interfaz entitytypeconfigurartion
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());//asembly es parte de sistem se usa para llamar a  todas las conf de entitity tipe confi
        }



    }

   
}

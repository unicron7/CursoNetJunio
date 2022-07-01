using Curso.Biblioteca.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Aplicacion.ServicioInterfaz
{
    public interface ILibroServicio
    {
        Task<ICollection<Libro>> GetAllAsync();
        Task<Libro> GetByIdAsync(int Id);
        Task<Libro> UpdateAsync(Libro libro);
        Task<Libro> AddAsync(Libro libro);
        Task<bool> DeleteByIdAsync(int Id);
    }
}

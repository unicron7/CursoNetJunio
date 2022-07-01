using Curso.Biblioteca.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Aplicacion.ServicioInterfaz
{
    public interface IAutorServicio
    {
        Task<ICollection<Autor>> GetAllAsync();
        Task<Autor> GetByIdAsync(int Id);
        Task<Autor> UpdateAsync(Autor autor);
        Task<Autor> AddAsync(Autor autor);
        Task<bool> DeleteByIdAsync(int Id);
    }
}

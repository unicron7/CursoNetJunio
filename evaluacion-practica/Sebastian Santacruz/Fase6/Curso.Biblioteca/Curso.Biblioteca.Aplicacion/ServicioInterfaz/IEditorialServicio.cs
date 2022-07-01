using Curso.Biblioteca.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Aplicacion.ServicioInterfaz
{
    public interface IEditorialServicio
    {
        Task<ICollection<Editorial>> GetAllAsync();
        Task<Editorial> GetByIdAsync(int Id);
        Task<Editorial> UpdateAsync(Editorial editorial);
        Task<Editorial> AddAsync(Editorial editorial);
        Task<bool> DeleteByIdAsync(int Id);
    }
}

using Curso.Biblioteca.Aplicacion.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Aplicacion.Servicios_Definicion
{
    public interface IEditorialServicio
    {
        IQueryable<EditorialDto> GetAll();
        Task CreateAsync(EditorialDto editorial);
        Task UpdateAsync(EditorialDto editorial);
        Task DeleteAsync(EditorialDto editorial);
    }
}

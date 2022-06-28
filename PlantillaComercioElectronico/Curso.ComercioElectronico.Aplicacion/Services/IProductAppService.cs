using Curso.ComercioElectronico.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.ComercioElectronico.Aplicacion.Services
{
    public interface IProductAppService
    {
        Task<ICollection<Product>> GetAsync();
        Task<Product> GetAsync(Guid id);
    }
}

using Curso.ComercioElectronico.Aplicacion.Dtos;
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
        Task<ICollection<ProductDto>> GetAllAsync();
        
        Task<ProductDto> GetAsync(Guid id);

        Task CreateAsync(CreateUpdateProductDto productDto);

        Task UpdateAsync(Guid id, CreateUpdateProductDto productDto);

        Task DeleteAsync(Guid id);
    }
}

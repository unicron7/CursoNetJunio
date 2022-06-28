using Curso.ComercioElectronico.Aplicacion.Services;
using Curso.ComercioElectronico.Dominio.Entities;
using Curso.ComercioElectronico.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.ComercioElectronico.Aplicacion.ServicesImpl
{
    public class ProductAppService : IProductAppService
    {
        private readonly IGenericRepository<Product> repository;

        public ProductAppService(IGenericRepository<Product> repository)
        {
            this.repository = repository;
        }

        public async Task<ICollection<Product>> GetAsync()
        {
            return await repository.GetAsync();
        }

        public async Task<Product> GetAsync(Guid id)
        {
            return await repository.GetAsync(id);
        }
    }
}

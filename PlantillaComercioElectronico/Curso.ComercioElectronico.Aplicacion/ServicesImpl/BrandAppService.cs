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
    public class BrandAppService : IBrandAppService
    {
        private readonly IGenericRepository<Brand> repository;

        public BrandAppService(IGenericRepository<Brand> repository)
        {
            this.repository = repository;
        }

        public async Task<ICollection<Brand>> GetAsync()
        {
            return await repository.GetAsync();
        }

        public async Task<Brand> GetAsync(string id)
        {
            return await repository.GetAsync(id);
        }
    }
}

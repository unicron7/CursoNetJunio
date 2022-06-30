using Curso.ComercioElectronico.Aplicacion.Dtos;
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

        public async Task<ICollection<BrandDto>> GetAllAsync()
        {
            var query= await repository.GetAsync();

            var result = query.Select(x => new BrandDto { 
                Code = x.Code,
                Description = x.Description,
                CreationDate = x.CreationDate
            });

            return result.ToList();
        }

        public async Task<BrandDto> GetAsync(string code)
        {
            var entity = await repository.GetAsync(code);
            return new BrandDto
            {
                Code = entity.Code,
                Description = entity.Description,
                CreationDate = entity.CreationDate
            };
        }

        public async Task CreateAsync(CreateUpdateBrandDto brandDto)
        {
            var brand = new Brand {
                Code = brandDto.Code,
                Description = brandDto.Description,
                CreationDate = DateTime.Now
            };
            
            await repository.CreateAsync(brand);
        }

        public async Task UpdateAsync(CreateUpdateBrandDto brandDto)
        {
            var entity = await repository.GetAsync(brandDto.Code);
            if (entity == null)
            {
                throw new Exception($"La entidad con código: {brandDto.Code} no existe");
            }
            entity.Description = brandDto.Description;
            entity.ModifiedDate = DateTime.Now;

            await repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(string code)
        {
            var entity = await repository.GetAsync(code);
            if (entity == null)
            {
                throw new Exception($"La entidad con código: {code} no existe");
            }

            entity.IsDeleted = true;
            entity.ModifiedDate = DateTime.Now;

            await repository.UpdateAsync(entity);
        }
        
    }
}

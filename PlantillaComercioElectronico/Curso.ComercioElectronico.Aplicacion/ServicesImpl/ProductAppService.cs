using Curso.ComercioElectronico.Aplicacion.Dtos;
using Curso.ComercioElectronico.Aplicacion.Services;
using Curso.ComercioElectronico.Dominio.Entities;
using Curso.ComercioElectronico.Dominio.Repositories;
using Microsoft.EntityFrameworkCore;
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

        public async Task CreateAsync(CreateUpdateProductDto productDto)
        {
            var product = new Product {
                Id = Guid.NewGuid(),
                Name = productDto.Name,
                Description = productDto.Description,
                BrandId = productDto.BrandId,
                ProductTypeId = productDto.ProductTypeId,
                Price = productDto.Price,
                CreationDate = DateTime.Now
            };
            await repository.CreateAsync(product);
        }

        public async Task DeleteAsync(Guid id)
        {
            var product = await repository.GetAsync(id);

            product.IsDeleted = true;
            product.ModifiedDate = DateTime.Now;
            await repository.UpdateAsync(product);
        }

        public async Task<ICollection<ProductDto>> GetAllAsync()
        {
            var query = repository.GetQueryable();

            //Filtrando los no eliminados
            query = query.Where(x => x.IsDeleted == false);

            var result = query.Select(x=> new ProductDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                Brand = x.Brand.Description,
                ProductType = x.ProductType.Description
            });

            return await result.ToListAsync();
        }

        public async Task<ProductDto> GetAsync(Guid id)
        {
            var query = repository.GetQueryable();

            //Filtrando los no eliminados
            query = query.Where(x => x.IsDeleted == false);

            //Filtrando la informacion por el Id
            query = query.Where(x => x.Id == id);

            var result = query.Select(x => new ProductDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                Brand = x.Brand.Description,
                ProductType = x.ProductType.Description
            });

            return await result.SingleOrDefaultAsync();
        }

        public async Task UpdateAsync(Guid id, CreateUpdateProductDto productDto)
        {
            var product = await repository.GetAsync(id);

            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.Price = productDto.Price;
            product.BrandId = productDto.BrandId;
            product.ProductTypeId = productDto.ProductTypeId;
            product.ModifiedDate = DateTime.Now;
        
            await repository.UpdateAsync(product);
        }
    }
}

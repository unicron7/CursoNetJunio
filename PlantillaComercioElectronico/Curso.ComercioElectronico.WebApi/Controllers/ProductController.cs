using Curso.ComercioElectronico.Aplicacion.Dtos;
using Curso.ComercioElectronico.Aplicacion.Services;
using Curso.ComercioElectronico.Dominio.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Curso.ComercioElectronico.WebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase, IProductAppService
    {
        private readonly IProductAppService productAppService;

        public ProductController(IProductAppService productAppService)
        {
            this.productAppService = productAppService;
        }

        [HttpGet]
        public async Task<ICollection<ProductDto>> GetAllAsync()
        {
            return await productAppService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ProductDto> GetAsync(Guid id)
        {
            return await productAppService.GetAsync(id);
        }

        [HttpPost]
        public async Task CreateAsync(CreateUpdateProductDto productDto)
        {
            await productAppService.CreateAsync(productDto);
        }

        [HttpPut]
        public async Task UpdateAsync(Guid id, CreateUpdateProductDto productDto)
        {
            await productAppService.UpdateAsync(id, productDto);
        }

        [HttpDelete]
        public async Task DeleteAsync(Guid id)
        {
            await productAppService.DeleteAsync(id);
        }

    }
}

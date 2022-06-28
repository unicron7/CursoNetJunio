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
        public async Task<ICollection<Product>> GetAsync()
        {
            return await productAppService.GetAsync();
        }

        [HttpGet("{id}")]
        public async Task<Product> GetAsync(Guid id)
        {
            return await productAppService.GetAsync(id);
        }
    }
}

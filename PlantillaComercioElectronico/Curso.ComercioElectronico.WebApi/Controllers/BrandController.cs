using Curso.ComercioElectronico.Aplicacion.Services;
using Curso.ComercioElectronico.Dominio.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Curso.ComercioElectronico.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase, IBrandAppService
    {
        private readonly IBrandAppService brandAppService;

        public BrandController(IBrandAppService brandAppService)
        {
            this.brandAppService = brandAppService;
        }

        [HttpGet]
        public async Task<ICollection<Brand>> GetAsync()
        {
            return await brandAppService.GetAsync();
        }

        [HttpGet("{code}")]
        public async Task<Brand> GetAsync(string code)
        {
            return await brandAppService.GetAsync(code);
        }
    }
}

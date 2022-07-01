using Curso.Biblioteca.Aplicacion.ServicioInterfaz;
using Curso.Biblioteca.Dominio.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Curso.Biblioteca.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialController : ControllerBase, IEditorialServicio
    {
        private readonly IEditorialServicio servicio;

        public EditorialController(IEditorialServicio servicio)
        {
            this.servicio = servicio;
        }

        [HttpPost]
        public Task<Editorial> AddAsync(Editorial editorial)
        {
            return servicio.AddAsync(editorial);
        }

        [HttpDelete]
        public Task<bool> DeleteByIdAsync(int Id)
        {
            return servicio.DeleteByIdAsync(Id);
        }

        [HttpGet]
        public Task<ICollection<Editorial>> GetAllAsync()
        {
            return servicio.GetAllAsync();
        }

        [HttpGet("{Id}")]
        public Task<Editorial> GetByIdAsync(int Id)
        {
            return servicio.GetByIdAsync(Id);
        }

        [HttpPut]
        public Task<Editorial> UpdateAsync(Editorial editorial)
        {
            return servicio.UpdateAsync(editorial);
        }
    }
}

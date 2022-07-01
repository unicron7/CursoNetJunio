using Curso.Biblioteca.Aplicacion.ServicioInterfaz;
using Curso.Biblioteca.Dominio.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Curso.Biblioteca.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase, IAutorServicio
    {
        private readonly IAutorServicio servicio;

        public AutorController(IAutorServicio servicio)
        {
            this.servicio = servicio;
        }

        [HttpPost]
        public Task<Autor> AddAsync(Autor autor)
        {
            return servicio.AddAsync(autor);
        }

        [HttpDelete]
        public Task<bool> DeleteByIdAsync(int Id)
        {
            return servicio.DeleteByIdAsync(Id);
        }

        [HttpGet]
        public Task<ICollection<Autor>> GetAllAsync()
        {
            return servicio.GetAllAsync();
        }

        [HttpGet("{Id}")]
        public Task<Autor> GetByIdAsync(int Id)
        {
            return servicio.GetByIdAsync(Id);
        }

        [HttpPut]
        public Task<Autor> UpdateAsync(Autor autor)
        {
            return servicio.UpdateAsync(autor);
        }
    }
}

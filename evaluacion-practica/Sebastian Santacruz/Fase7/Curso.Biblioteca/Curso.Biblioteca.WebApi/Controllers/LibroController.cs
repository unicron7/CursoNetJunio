using Curso.Biblioteca.Aplicacion.ServicioInterfaz;
using Curso.Biblioteca.Dominio.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Curso.Biblioteca.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase, ILibroServicio
    {
        private readonly ILibroServicio servicio;

        public LibroController(ILibroServicio servicio)
        {
            this.servicio = servicio;
        }

        [HttpPost]
        public Task<Libro> AddAsync(Libro libro)
        {
            return servicio.AddAsync(libro);
        }

        [HttpDelete]
        public Task<bool> DeleteByIdAsync(int Id)
        {
            return servicio.DeleteByIdAsync(Id);
        }

        [HttpGet]
        public Task<ICollection<Libro>> GetAllAsync()
        {
            return servicio.GetAllAsync();
        }

        [HttpGet("{Id}")]
        public Task<Libro> GetByIdAsync(int Id)
        {
            return servicio.GetByIdAsync(Id);
        }

        [HttpPut]
        public Task<Libro> UpdateAsync(Libro libro)
        {
            return servicio.UpdateAsync(libro);
        }
    }
}

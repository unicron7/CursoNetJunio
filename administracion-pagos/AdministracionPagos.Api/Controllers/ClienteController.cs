using AdministracionPagos.Aplicacion.Dtos;
using AdministracionPagos.Aplicacion.ServicioDefinicion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionPagos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase, IClienteServicio
    {
        private readonly IClienteServicio clienteServicio;

        public ClienteController(IClienteServicio clienteServicio)
        {
            this.clienteServicio = clienteServicio;
        }

        [HttpPost]
        public async Task<bool> CreateAsync(CrearClienteDto cliente)
        {
            return await clienteServicio.CreateAsync(cliente);
        }

        [HttpDelete]
        public async Task<bool> DeleteAsync(int id)
        {
            return await clienteServicio.DeleteAsync(id);
        }

        [HttpGet]
        public async Task<ICollection<ClienteDto>> GetAllAsync()
        {
            return await clienteServicio.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ClienteDto> GetByIdAsync(int id)
        {
            return await clienteServicio.GetByIdAsync(id);
        }

        [HttpPut]
        public async Task<bool> UpdateAsync(int id, CrearClienteDto clientoDto)
        {
            return await clienteServicio.UpdateAsync(id, clientoDto);
        }
    }
}

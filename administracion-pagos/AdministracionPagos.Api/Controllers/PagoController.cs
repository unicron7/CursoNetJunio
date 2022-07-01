using AdministracionPagos.Aplicacion.Dtos;
using AdministracionPagos.Aplicacion.ServicioDefinicion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionPagos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase, IPagoServicio
    {
        private readonly IPagoServicio pagoServicio;

        public PagoController(IPagoServicio pagoServicio)
        {
            this.pagoServicio = pagoServicio;
        }

        [HttpPost]
        public async Task<bool> CreateAsync(CrearPagoDto pago)
        {
            return await pagoServicio.CreateAsync(pago);
        }

        [HttpDelete]
        public async Task<bool> DeleteAsync(int id)
        {
            return await pagoServicio.DeleteAsync(id);
        }

        [HttpGet]
        public async Task<ICollection<PagoDto>> GetAllAsync()
        {
            return await pagoServicio.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<PagoDto> GetByIdAsync(int id)
        {
            return await pagoServicio.GetByIdAsync(id);
        }

        [HttpPut]
        public async Task<bool> UpdateAsync(int id, CrearPagoDto clientoDto)
        {
            return await pagoServicio.UpdateAsync(id, clientoDto);
        }
    }
}

using AdministracionPagos.Aplicacion.Dtos;
using AdministracionPagos.Aplicacion.ServicioDefinicion;
using AdministracionPagos.Dominio.Modelo;
using AdministracionPagos.Dominio.RepositorioDefinicion;
using AdministracionPagos.Infraestructura.RepositorioImplementacion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministracionPagos.Aplicacion.ServicioImplementacion
{
    public class PagoServicio : IPagoServicio
    {
        private readonly IPagoRepositorio pagoRepositorio;

        public PagoServicio(IPagoRepositorio pagoRepositorio)
        {
            this.pagoRepositorio = pagoRepositorio;
        }

        public async Task<bool> CreateAsync(CrearPagoDto pagoDto)
        {
            var pago = new Pago { 
                NumeroComprobante = pagoDto.NumeroComprobante,
                FechaPago = DateTime.Now,
                ClienteId = pagoDto.ClienteId
            };
            await pagoRepositorio.CreateAsync(pago);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var consulta = pagoRepositorio.GetAll();
            consulta = consulta.Where(c => c.Id == id);
            var pago = consulta.SingleOrDefault();

            await pagoRepositorio.DeleteAsync(pago);
            return true;
        }

        public async Task<ICollection<PagoDto>> GetAllAsync()
        {
            var consulta = pagoRepositorio.GetAll();
            var listaPagos = await consulta.Select( x => new PagoDto
            {
                Id= x.Id,
                NumeroComprobante = x.NumeroComprobante,
                FechaPago = x.FechaPago,
                Cliente = $"{x.Cliente.Nombre} {x.Cliente.Apellido}"
            }).ToListAsync();

            return listaPagos;
        }

        public async Task<PagoDto> GetByIdAsync(int id)
        {
            var consulta = pagoRepositorio.GetAll();
            consulta = consulta.Where(c => c.Id == id);
            var pago = await consulta.Select(x => new PagoDto
            {
                Id = x.Id,
                NumeroComprobante = x.NumeroComprobante,
                FechaPago = x.FechaPago,
                Cliente = $"{x.Cliente.Nombre} {x.Cliente.Apellido}"
            }).SingleOrDefaultAsync();

            return pago;
        }

        public async Task<bool> UpdateAsync(int id, CrearPagoDto pagoDto)
        {
            var consulta = pagoRepositorio.GetAll();
            consulta = consulta.Where(c => c.Id == id);
            var pago = consulta.SingleOrDefault();

            //Establecer los nuevos valores
            pago.NumeroComprobante = pagoDto.NumeroComprobante;
            pago.ClienteId = pagoDto.ClienteId;

            await pagoRepositorio.UpdateAsync(pago);
            return true;
        }
    }
}

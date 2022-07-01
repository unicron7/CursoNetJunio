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
    public class ClienteServicio : IClienteServicio
    {
        private readonly IClienteRepositorio clienteRepositorio;

        public ClienteServicio(IClienteRepositorio clienteRepositorio)
        {
            this.clienteRepositorio = clienteRepositorio;
        }

        public async Task<bool> CreateAsync(CrearClienteDto clienteDto)
        {
            var cliente = new Cliente { 
                Nombre = clienteDto.Nombre,
                Apellido = clienteDto.Apellido
            };
            await clienteRepositorio.CreateAsync(cliente);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var consulta = clienteRepositorio.GetAll();
            consulta = consulta.Where(c => c.Id == id);
            var cliente = consulta.SingleOrDefault();

            await clienteRepositorio.DeleteAsync(cliente);
            return true;
        }

        public async Task<ICollection<ClienteDto>> GetAllAsync()
        {
            var consulta = clienteRepositorio.GetAll();
            var listaClientes = await consulta.Select( x => new ClienteDto
            {
                Id= x.Id,
                Nombre = x.Nombre,
                Apellido = x.Apellido
            }).ToListAsync();

            return listaClientes;
        }

        public async Task<ClienteDto> GetByIdAsync(int id)
        {
            var consulta = clienteRepositorio.GetAll();
            consulta = consulta.Where(c => c.Id == id);
            var cliente = await consulta.Select(x => new ClienteDto
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Apellido = x.Apellido
            }).SingleOrDefaultAsync();

            return cliente;
        }

        public async Task<bool> UpdateAsync(int id, CrearClienteDto clienteDto)
        {
            var consulta = clienteRepositorio.GetAll();
            consulta = consulta.Where(c => c.Id == id);
            var cliente = consulta.SingleOrDefault();

            //Establecer los nuevos valores
            cliente.Nombre = clienteDto.Nombre;
            cliente.Apellido = clienteDto.Apellido;

            await clienteRepositorio.UpdateAsync(cliente);
            return true;
        }
    }
}

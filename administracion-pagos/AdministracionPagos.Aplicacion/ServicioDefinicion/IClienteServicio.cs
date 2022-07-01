using AdministracionPagos.Aplicacion.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministracionPagos.Aplicacion.ServicioDefinicion
{
    public interface IClienteServicio
    {
        //GetAll
        Task<ICollection<ClienteDto>> GetAllAsync();

        //GetById
        Task<ClienteDto> GetByIdAsync(int id);

        //Create
        Task<bool> CreateAsync(CrearClienteDto cliente);

        //Update
        Task<bool> UpdateAsync(int id, CrearClienteDto clientoDto);

        //Delete
        Task<bool> DeleteAsync(int id);
    }
}

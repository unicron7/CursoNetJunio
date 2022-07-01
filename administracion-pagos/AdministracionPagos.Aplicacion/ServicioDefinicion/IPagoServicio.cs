using AdministracionPagos.Aplicacion.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministracionPagos.Aplicacion.ServicioDefinicion
{
    public interface IPagoServicio
    {
        //GetAll
        Task<ICollection<PagoDto>> GetAllAsync();

        //GetById
        Task<PagoDto> GetByIdAsync(int id);

        //Create
        Task<bool> CreateAsync(CrearPagoDto pagoDto);

        //Update
        Task<bool> UpdateAsync(int id, CrearPagoDto pagoDto);

        //Delete
        Task<bool> DeleteAsync(int id);
    }
}

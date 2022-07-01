using AdministracionPagos.Dominio.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministracionPagos.Dominio.RepositorioDefinicion
{
    public interface IPagoRepositorio
    {
        IQueryable<Pago> GetAll();

        Task CreateAsync(Pago pago);
        Task UpdateAsync(Pago pago);
        Task DeleteAsync(Pago pago);
    }
}

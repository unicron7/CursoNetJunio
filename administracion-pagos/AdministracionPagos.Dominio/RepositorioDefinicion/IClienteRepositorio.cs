using AdministracionPagos.Dominio.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministracionPagos.Dominio.RepositorioDefinicion
{
    public interface IClienteRepositorio
    {
        IQueryable<Cliente> GetAll();
        Task CreateAsync(Cliente cliente);
        Task UpdateAsync(Cliente cliente);
        Task DeleteAsync(Cliente cliente);
    }
}

using AdministracionPagos.Dominio.Modelo;
using AdministracionPagos.Dominio.RepositorioDefinicion;
using AdministracionPagos.Infraestructura.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministracionPagos.Infraestructura.RepositorioImplementacion
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly AdministracionPagosContexto contexto;

        public ClienteRepositorio(AdministracionPagosContexto contexto)
        {
            this.contexto = contexto;
        }

        public async Task CreateAsync(Cliente cliente)
        {
            await contexto.AddAsync(cliente);
            await contexto.SaveChangesAsync();
        }

        public async Task DeleteAsync(Cliente cliente)
        {
            contexto.Remove(cliente);
            await contexto.SaveChangesAsync();
        }

        public IQueryable<Cliente> GetAll()
        {
            return contexto.Clientes.AsQueryable();
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            contexto.Update(cliente);
            await contexto.SaveChangesAsync();
        }
    }
}

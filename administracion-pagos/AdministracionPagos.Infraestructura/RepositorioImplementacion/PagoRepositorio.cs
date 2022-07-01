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
    public class PagoRepositorio : IPagoRepositorio
    {
        private readonly AdministracionPagosContexto contexto;

        public PagoRepositorio(AdministracionPagosContexto contexto)
        {
            this.contexto = contexto;
        }

        public async Task CreateAsync(Pago pago)
        {
            await contexto.AddAsync(pago);
            await contexto.SaveChangesAsync();
        }

        public async Task DeleteAsync(Pago pago)
        {
            contexto.Remove(pago);
            await contexto.SaveChangesAsync();
        }

        public IQueryable<Pago> GetAll()
        {
            return contexto.Pagos.AsQueryable();
        }

        public async Task UpdateAsync(Pago pago)
        {
            contexto.Update(pago);
            await contexto.SaveChangesAsync();
        }
    }
}

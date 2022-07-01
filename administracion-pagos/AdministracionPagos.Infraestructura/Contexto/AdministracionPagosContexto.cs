using AdministracionPagos.Dominio.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministracionPagos.Infraestructura.Contexto
{
    public class AdministracionPagosContexto : DbContext
    {
        public AdministracionPagosContexto(DbContextOptions<AdministracionPagosContexto> options) : base(options)
        {
        }

        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder constructor)
        {
            var cadenaConexion = @"Server=(localdb)\mssqllocaldb;Database=Prudctos;Trusted_Connection=True";
            constructor.UseSqlServer(cadenaConexion);
        }
    }
}

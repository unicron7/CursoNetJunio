using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministracionPagos.Dominio.Modelo
{
    public class Pago
    {
        public int Id { get; set; }
        public string NumeroComprobante { get; set; }
        public DateTime FechaPago { get; set; }

        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }
    }
}

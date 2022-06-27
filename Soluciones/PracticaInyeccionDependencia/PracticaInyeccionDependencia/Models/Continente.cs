using System;
using System.Collections.Generic;

namespace PracticaInyeccionDependencia.Models
{
    public partial class Continente
    {
        public Continente()
        {
            Paises = new HashSet<Paise>();
        }

        public int ContinenteId { get; set; }
        public string? Nombre { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaModificacion { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<Paise> Paises { get; set; }
    }
}

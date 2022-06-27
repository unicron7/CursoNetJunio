using System;
using System.Collections.Generic;

namespace PracticaInyeccionDependencia.Models
{
    public partial class Paise
    {
        public Paise()
        {
            Personas = new HashSet<Persona>();
        }

        public int PaisId { get; set; }
        public string? Nombre { get; set; }
        public string? Capital { get; set; }
        public int Poblacion { get; set; }
        public int Establecido { get; set; }
        public int ContinenteId { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaModificacion { get; set; }
        public bool Estado { get; set; }

        public virtual Continente Continente { get; set; } = null!;
        public virtual ICollection<Persona> Personas { get; set; }
    }
}

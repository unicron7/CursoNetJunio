using System;
using System.Collections.Generic;

namespace PracticaInyeccionDependencia.Models
{
    public partial class Curso
    {
        public Curso()
        {
            PersonaPersonas = new HashSet<Persona>();
        }

        public int CursoId { get; set; }
        public string? Nombre { get; set; }
        public string? Idioma { get; set; }
        public double Precio { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaModificacion { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<Persona> PersonaPersonas { get; set; }
    }
}

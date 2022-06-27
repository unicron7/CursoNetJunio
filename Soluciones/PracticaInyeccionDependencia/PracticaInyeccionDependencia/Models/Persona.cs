using System;
using System.Collections.Generic;

namespace PracticaInyeccionDependencia.Models
{
    public partial class Persona
    {
        public Persona()
        {
            CursoCursos = new HashSet<Curso>();
        }

        public int PersonaId { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Genero { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Identificador { get; set; }
        public string? TipoPersona { get; set; }
        public int PaisId { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaModificacion { get; set; }
        public bool Estado { get; set; }

        public virtual Paise Pais { get; set; } = null!;

        public virtual ICollection<Curso> CursoCursos { get; set; }
    }
}

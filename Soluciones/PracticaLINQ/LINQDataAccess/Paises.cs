//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LINQDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Paises
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Paises()
        {
            this.Personas = new HashSet<Personas>();
        }
    
        public int PaisId { get; set; }
        public string Nombre { get; set; }
        public string Capital { get; set; }
        public int Poblacion { get; set; }
        public int Establecido { get; set; }
        public int ContinenteId { get; set; }
        public System.DateTime FechaRegistro { get; set; }
        public System.DateTime FechaModificacion { get; set; }
        public bool Estado { get; set; }
    
        public virtual Continentes Continentes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Personas> Personas { get; set; }
    }
}
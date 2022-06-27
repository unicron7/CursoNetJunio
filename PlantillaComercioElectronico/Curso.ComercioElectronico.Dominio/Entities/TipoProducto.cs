using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.ComercioElectronico.Dominio.Entities
{
    public class ProductType
    {
        [Key]
        [MaxLength(4)]
        public string Codigo { get; set; }

        public string Description { get; set; }

    }
}

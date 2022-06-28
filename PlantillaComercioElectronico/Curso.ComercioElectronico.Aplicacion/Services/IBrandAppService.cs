using Curso.ComercioElectronico.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.ComercioElectronico.Aplicacion.Services
{
    public interface IBrandAppService
    {
        Task<ICollection<Brand>> GetAsync();
        Task<Brand> GetAsync(string code);
    }
}

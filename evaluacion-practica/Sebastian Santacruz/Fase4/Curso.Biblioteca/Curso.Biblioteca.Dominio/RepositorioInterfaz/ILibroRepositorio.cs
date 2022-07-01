﻿using Curso.Biblioteca.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Dominio.RepositorioInterfaz
{
    public interface ILibroRepositorio
    {
        IQueryable<Libro> GetAll();
        Task AddAsync (Libro libro);
        Task UpdateAsync (Libro libro);
        Task DeleteAsync (Libro libro);

    }
}

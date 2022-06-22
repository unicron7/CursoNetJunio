using DataAccessLINQ;
using PracticaLINQ.Dtos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaLINQ
{
    public class Program
    {
        static void Main(string[] args)
        {

            using (var db = new CursosVirtualesEntities())
            {
                //IEnumerable<Cursos> cursos = from curso in db.Cursos
                //                             orderby curso.Nombre
                //                             select curso;

                //IEnumerable<Cursos> cursos = db.Cursos.OrderByDescending(p => p.Nombre).Select(p =>p);

                //IEnumerable<Cursos> cursos = from curso in db.Cursos
                //                             orderby curso.Idioma ascending, curso.Nombre ascending
                //                             select curso; //ordeby().thenby()

                //foreach (var curso in cursos)
                //{
                //    Console.WriteLine($"IDIOMA: {curso.Idioma}\tNOMBRE: {curso.Nombre}, {curso.Precio}");
                //}

                //IEnumerable<Continentes> continentes = db.Continentes;
                //foreach (var continente in continentes)
                //{
                //    Console.WriteLine($"ID: {continente.ContinenteId} NOMBRE: {continente.Nombre}");
                //}
                //Console.WriteLine("Reverse");
                //IEnumerable<Continentes> continentes2 = db.Continentes.AsEnumerable().Reverse();
                ////IQueriable
                //foreach (var continente in continentes2)
                //{
                //    Console.WriteLine($"ID: {continente.ContinenteId} NOMBRE: {continente.Nombre}");
                //}

                //Obtener solo el idioma
                //IEnumerable<string> idiomas = db.Cursos.OrderBy(p => p.Idioma).Select(p =>p.Idioma).Distinct();

                //foreach (var idioma in idiomas)
                //{
                //    Console.WriteLine($"{idioma}");
                //}

                //from p in paises
                //join c in continentes on //América


                //IEnumerable<Paises> paises= from p in db.Paises
                //                            join c in db.Continentes on p.ContinenteId equals c.ContinenteId
                //                            where c.Nombre == "América"
                //                            select p;

                IEnumerable<PaisDto> paises = from p in db.Paises
                                             join c in db.Continentes on p.ContinenteId equals c.ContinenteId
                                             where c.Nombre.ToUpper() == "AmérIca".ToUpper()
                                             select new PaisDto { 
                                                Nombre = p.Nombre,
                                                Continente = c.Nombre
                                             };


                foreach (var p in paises)
                {
                    Console.WriteLine($"Continente:{p.Continente}  Pais: {p.Nombre}");
                }
            }


            //1. Origen de datos
            //int[] numeros = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 12, 15, 17, 18, 22, 23, 28, 29 };

            ////2. Crear la consulta
            //IEnumerable<int> pares = from numero in numeros
            //                         where (numero % 2 == 0)
            //                         select numero;


            //IEnumerable<int> paresMetodo= numeros.Where(n => n % 2 == 0).Select(n => n);
            ////int resultado= (from numero in numeros
            ////                          where (numero % 2 == 0)
            ////                          select numero).Min();


            //int result= numeros.Where(n => n % 2 == 0).Min();

            ////Console.WriteLine(resultado);
            ////Console.WriteLine(result);

            ////3. Ejecutar la consulta
            ////pares.ToList();
            //foreach (var n in paresMetodo)
            //{
            //    Console.WriteLine($"Numero par {n}");
            //}

            //Console.WriteLine(paresMetodo.Average());


            Console.ReadKey();
        }

    }
}

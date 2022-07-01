using LINQConsola.Operadores;
using LINQDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new CursosVirtualesEntities())
            {
                IEnumerable<Continentes> continentes = from cont in db.Continentes
                                                       select cont;

                foreach (var continente in continentes)
                {
                    Console.WriteLine($" Id: {continente.ContinenteId}, Nombre: {continente.Nombre}");
                }

                IEnumerable<string> idiomas = db.Cursos.OrderBy(p => p.Idioma).Select(p => p.Idioma).ToList();

                foreach (var idioma in idiomas)
                {
                    Console.WriteLine($"{idioma}");
                }
            }

            //Console.ReadKey();


            //1. Origen de datos
            //int[] numeros = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 17, 21, 22, 23, 26 };

            ////2.Crear la consulta
            //IEnumerable<int> numerosPares = from numero in numeros
            //                                where (numero % 2 == 0)
            //                                select numero;

            ////3.Ejecutar la consulta
            //foreach (var num in numerosPares)
            //{
            //    Console.WriteLine($"{num}");
            //}


            //Ejecucion inmediata
            //1. Origen de datos
            //int[] numeros = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 17, 21, 22, 23, 26 };

            ////2. Crear la consulta
            //var resultado = (from numero in numeros
            //                                where (numero % 2 == 0)
            //                                select numero).Count();

            //Console.WriteLine(resultado);


            //Ejecucion aplazada

            new Proyeccion().Proyectar();

            Console.ReadKey();
        }
    }
}

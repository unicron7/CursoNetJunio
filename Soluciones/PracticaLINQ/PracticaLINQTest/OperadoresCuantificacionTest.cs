using LINQDataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaLINQTest
{
    [TestClass]
    public class OperadoresCuantificacionTest
    {
        [TestMethod]
        public void TestAny1()
        {
            //int[] numeros = new int[] { };
            int[] numeros = new int[] { 1, 5, 7, 5, 9, 3 };

            //Validar si esta vacio
            //Assert.AreEqual(false, numeros.Any());

            if (numeros.Any())
            {
                Console.WriteLine("el arreglo contiene datos: " + (numeros.Any()));
            }
            else
            {
                Console.WriteLine("el arreglo no contiene datos: " + (numeros.Any()));
            }

        }

        [TestMethod]
        public void TestAny2()
        {
            int[] numeros = new int[] { 1, 5, 7, 5, 9, 3 };
            var numero = 8;

            if (numeros.Any(n => n==numero))
            {
                Console.WriteLine($"el arreglo contiene {numero}: " + (numeros.Any(n => n == numero)));
            }
            else
            {
                Console.WriteLine($"el arreglo no contiene {numero}: " + (numeros.Any(n => n == numero)));
            }

        }

        [TestMethod]
        public void TestAny3()
        {
            using (var db = new CursosVirtualesEntities())
            {
                string idioma = "frances"; //ingles, frances

                bool existenCursos = db.Cursos.Any(curso => curso.Idioma == idioma);

                if (existenCursos)
                {
                    Console.WriteLine("Existen cursos.");
                }
                else
                {
                    Console.WriteLine("No existen cursos.");
                }


            }

        }

        [TestMethod]
        public void TestAll1()
        {
            string[] palabras = new string[] { "casa", "mesa", "silla" };
            //string[] palabras = new string[] { "casa", "cocina", "cuarto" };

            var consulta = palabras
                .All(palabra => palabra.StartsWith("c")) 
                    ? "todas las palabras empiezan con C" 
                    : "no todas las palabras empiezan con C";

            Console.WriteLine(consulta);

        }

        [TestMethod]
        public void TestAll2()
        {
            //determinar si todos los cursos tienen un precio mayor a $5.00
            using (var db = new CursosVirtualesEntities())
            {
                var precio = db.Cursos.All(curso => curso.Precio >= 5)
                    ? "correcto" : "incorrecto";

                Console.WriteLine("¿Todos los cursos cuestan mas de $5.00? " + precio);
            }
        }

        [TestMethod]
        public void TestAll3()
        {
            //determinar si todos los cursos tienen un precio mayor a $10.00
            using (var db = new CursosVirtualesEntities())
            {
                
                var precio = db.Cursos.All(curso => curso.Precio >= 10)
                    ? "correcto" : "incorrecto";

                Console.WriteLine("¿Todos los cursos cuestan mas de $10.00? " + precio);
            }
        }

        [TestMethod]
        public void TestAll4()
        {
            //validar si todos los cursos de ingles tienen un precio mayor o igual a 20
            using (var db = new CursosVirtualesEntities())
            {

                var idiomaPrecio = db.Cursos.All(
                    curso => curso.Precio >= 20
                    && curso.Idioma == "ingles"
                    );

                Console.WriteLine("¿todos los cursos de ingles son >= $20.00?: " + idiomaPrecio);
            }
        }

        [TestMethod]
        public void TestAll5()
        {
            //comprobar si todos los paises fueron establecidos despues de 1800
            using (var db = new CursosVirtualesEntities())
            {

                var paisesEstablecidos = db.Paises.All(pais => pais.Establecido > 1800);

                Console.WriteLine(paisesEstablecidos);
            }
        }

        [TestMethod]
        public void TestContains1()
        {
            //determinar cual cliente tiene en su listado de frutas: manzana

            List<Cliente> clientes = new List<Cliente>() {
                    new Cliente{ Nombre = "Juan Perez", Fruta = new string[] { "manzana", "pera", "naranja" } },
                    new Cliente{ Nombre = "Mario Vera", Fruta = new string[] { "limon", "mandarina", "platano" } },
                    new Cliente{ Nombre = "Carmen Andrade", Fruta = new string[] { "pera", "platano", "piña" } },
                    new Cliente{ Nombre = "Fabiola Gonzalez", Fruta = new string[] { "uvas", "sandia", "manzana" } },
                    new Cliente{ Nombre = "Carlos Ramon", Fruta = new string[] { "kiwi", "melon", "fresa" } }
                };

            string fruta = "manzana"; //"uvas", "manzana";
            string fruta2 = "melon";

            //var listadoClientes = from client in clientes
            //                      where client.Fruta.Contains(fruta) || client.Fruta.Contains(fruta2)
            //                      select client.Nombre;

            var listadoClientes = clientes.Where(c => c.Fruta.Contains(fruta) || c.Fruta.Contains(fruta2))
                                    .Select(c => c.Nombre);


            listadoClientes.ToList().ForEach(cliente => {
                Console.WriteLine(cliente);
            });
        }

        [TestMethod]
        public void TestContains2()
        {
            //determinar cuales personas contienen un curso especifico
            using (var db = new CursosVirtualesEntities())
            {
                var curso = db.Cursos.FirstOrDefault(c => c.Nombre == "Programación estructurada");

                var personas = from persona in db.Personas
                               where persona.Cursos.AsEnumerable().Contains(curso)
                               select persona;

                personas.ToList().ForEach(persona => {
                    Console.WriteLine(persona.Nombre);
                });
            }
        }

        class Cliente
        {
            public string Nombre { get; set; }
            public string[] Fruta { get; set; }
        }
    }
}

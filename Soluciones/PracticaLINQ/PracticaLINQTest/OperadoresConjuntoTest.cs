using LINQDataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticaLINQTest
{
    [TestClass]
    public class OperadoresConjuntoTest
    {

        [TestMethod]
        public void TestDistinct()
        {
            var dias = new string[] { "lunes", "sabado", "martes", "miercoles", "lunes", "jueves", "martes", "lunes", "viernes", "domingo", "sabado", "viernes" };

            IEnumerable<string> diasDistinct= from dia in dias.Distinct()
                                             select dia;

            foreach (var item in diasDistinct)
            {
                Console.WriteLine($"{item}");
            }
        }

        [TestMethod]
        public void TestExcept()
        {
            var meses1 = new string[] { "Enero", "Febrero", "Marzo", "Abril", "Agosto", "Mayo", "Junio" };
            var meses2 = new string[] { "Febrero", "Agosto", "Marzo", "Abril", "Mayo", "Junio", "Diciembre" };

            IEnumerable<string> meses = from mes in meses1.Except(meses2)
                                               select mes;

            foreach (var item in meses)
            {
                Console.WriteLine($"{item}");
            }
        }


        [TestMethod]
        public void TestIntersect()
        {
            var meses1 = new string[] { "Enero", "Febrero", "Marzo", "Abril", "Agosto", "Mayo", "Junio" };
            var meses2 = new string[] { "Febrero", "Agosto", "Marzo", "Abril", "Mayo", "Junio", "Diciembre" };

            IEnumerable<string> meses = from mes in meses1.Intersect(meses2)
                                        select mes;

            foreach (var item in meses)
            {
                Console.WriteLine($"{item}");
            }
        }

        [TestMethod]
        public void TestUnion()
        {
            var meses1 = new string[] { "Enero", "Febrero", "Marzo", "Abril", "Agosto", "Mayo", "Junio", "Septiembre" };
            var meses2 = new string[] { "Febrero", "Agosto", "Marzo", "Abril", "Mayo", "Junio", "Octubre", "Diciembre" };

            IEnumerable<string> meses = from mes in meses1.Union(meses2)
                                        select mes;

            foreach (var item in meses)
            {
                Console.WriteLine($"{item}");
            }
        }

        [TestMethod]
        public void TestWhere()
        {
            string[] palabras = new string[] {
                "mesa",
                "escritorio",
                "silla",
                "casa",
                "patio",
                "cocina",
                "cuarto",
                "habitación",
                "escalera"
            };

            IEnumerable<string> consulta = from palabra in palabras
                                           where palabra.Length > 4 && palabra.Length <= 8
                                           select palabra;

            //IEnumerable<string> consulta = palabras.Where(p => p.Length > 4 && p.Length <= 8).Select(p => p);


            foreach (var item in consulta)
            {
                Console.WriteLine($"{item}");
            }
        }

        [TestMethod]
        public void TestFiltrado1()
        {
            using (var db = new CursosVirtualesEntities())
            {
                //var paisesAmerica =
                //    from pais in db.Paises
                //    where pais.Continentes.Nombre.Contains("América")
                //    && pais.Poblacion > 10000000
                //    && pais.Establecido >= 1930
                //    orderby pais.ContinenteId ascending, pais.Nombre ascending
                //    select pais;

                var paisesAmerica = db.Paises.Where(p => p.Continentes.Nombre.Contains("América"))
                    .Where(p => p.Poblacion > 10000000)
                    .Where(p => p.Establecido >= 1930)
                    .OrderBy(p => p.ContinenteId).ThenBy(p => p.Nombre)
                    .Select(p => p);

                //var paisesAmericaOEuropa =
                //    from pais in db.Paises
                //    where pais.Continentes.Nombre.Contains("América") || pais.Continentes.Nombre.Contains("Europa")
                //    orderby pais.ContinenteId ascending, pais.Nombre ascending
                //    select pais;

                paisesAmerica.ToList().ForEach(pais =>
                {
                    Console.WriteLine($"" +
                        $"CONTINENTE: {pais.Continentes.Nombre}, " +
                        $"PAIS: {pais.Nombre}, " +
                        $"CAPITAL: {pais.Capital}, " +
                        $"POBLACIÓN: {pais.Poblacion}, " +
                        $"ESTABLECIDO: {pais.Establecido}");
                });


            }
        }

    }
}

using LINQDataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticaLINQTest
{
    [TestClass]
    public class OperadoresProyeccionTest
    {
        
        [TestMethod]
        public void TestSelect1()
        {
            using (var db = new CursosVirtualesEntities())
            {
                //de la tabla personas obtener los campos id, nombre, apellido, correo electronico, pais
                var personas = (from persona in db.Personas
                                where persona.Paises.Nombre.Equals("Ecuador")
                                select new
                                {
                                    Id = persona.PersonaId,
                                    Nombres = persona.Nombre + " " + persona.Apellido,
                                    Email = persona.CorreoElectronico,
                                    Pais = persona.Paises.Nombre
                                }).ToList();

                personas.ForEach(persona =>
                {
                    Console.WriteLine($"ID: {persona.Id}\t\t" +
                        $"NOMBRES: {persona.Nombres,-20}\t" +
                        $"PAIS: {persona.Pais,-15}" +
                        $"CORREO ELECTRÓNICO: {persona.Email,-10}");
                });
            }
        }

        [TestMethod]
        public void TestSelect2()
        {
            using (var db = new CursosVirtualesEntities())
            {
                //de la tabla personas obtener los campos id, nombre, apellido, correo electronico, pais
                var personas = (from persona in db.Personas
                                where persona.Paises.Nombre.Equals("Ecuador")
                                select new
                                {
                                    Id = persona.PersonaId,
                                    Nombres = persona.Nombre + " " + persona.Apellido,
                                    Email = persona.CorreoElectronico,
                                    Pais = persona.Paises.Nombre
                                }).ToList()
                                .Select(x => new Personas
                                {
                                    PersonaId = x.Id,
                                    Nombre = x.Nombres,
                                    CorreoElectronico = x.Email
                                }).ToList();

                personas.ForEach(persona =>
                {
                    Console.WriteLine($"ID: {persona.PersonaId}\t\t" +
                        $"NOMBRES: {persona.Nombre,-20}\t" +
                        $"CORREO ELECTRÓNICO: {persona.CorreoElectronico,-10}");
                });
            } 
        }

    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using TrabajoInterno_Api.Controllers;
using TrabajoInterno_Api.Data;
using TrabajoInterno_Api.Models;
using TrabajoInterno_Api.Services;
using Xunit;

namespace TrabajoInterno_Test
{
    public class PersonasTest
    {
        [Fact(DisplayName = "Devolver una lista de todas las personas")]
        public void GetAllPersonas()
        {
            using (var context = GetContextWithData())
            {
                var service = new PersonaService(context);

                var controller = new PersonasController(service);
                var result =  (List<Persona>?)controller.GetPersonas().Result.Value;

                Assert.NotNull(result);
                Assert.True(result?.Count != 0);
            }
        }

        [Fact(DisplayName = "Devolver una persona creada")]
        public void PostPersona()
        {
            using (var context = GetContextWithData())
            {
                var service = new PersonaService(context);
                var controller = new PersonasController(service);
                var _persona = new Persona()
                {
                    Nombre = "Nombre Test",
                    Apellido = "Apellido Test",
                    Identificacion = "CC 00000004",
                    Edad = 30,
                    CiudadNacimiento = "Ciudad Test",
                    Correo = "Correo Test"
                };

                var result = controller.PostPersona(_persona).Result.Value;

                Assert.NotNull(result);
                Assert.Equal(_persona.Identificacion, result?.Identificacion);
            }
        }

        private MySqlDbContext GetContextWithData()
        {
            var options = new DbContextOptionsBuilder<MySqlDbContext>()
                              .UseInMemoryDatabase(Guid.NewGuid().ToString())
                              .Options;
            var context = new MySqlDbContext(options);

            context.Database.ExecuteSqlRaw(@"CREATE PROCEDURE `SP_CREATE_PERSONA`(
                IN nombreP VARCHAR(30),
                IN apellidoP VARCHAR(30),
                IN identificacionP VARCHAR(30),
                IN edadP int,
                IN ciudad_NacimientoP VARCHAR(30),
                IN correoP VARCHAR(50)
                )
                INSERT INTO PERSONA(nombre, apellido, identificacion, edad, ciudad_Nacimiento, correo, activo, fecha_creacion, fecha_actualizacion)
                VALUES(nombreP, apellidoP, identificacionP, edadP, ciudad_NacimientoP, correoP, 0, now(), now())");

            context.Personas.Add(new Persona
            {
                IdPersona = 1,
                Nombre = "Test Nombre",
                Apellido = "Test Apellido",
                Edad = 30,
                Correo = "Test Correo",
                Identificacion = "CC 00000001",
                CiudadNacimiento = "Test Ciudad Nacimiento",
                Activo = false,
                FechaActualizacion = DateTime.Now,
                FechaCreacion = DateTime.Now
            });
            context.Personas.Add(new Persona
            {
                IdPersona = 2,
                Nombre = "Test Nombre2",
                Apellido = "Test Apellido2",
                Edad = 25,
                Correo = "Test Correo2",
                Identificacion = "CC 00000002",
                CiudadNacimiento = "Test Ciudad Nacimiento2",
                Activo = false,
                FechaActualizacion = DateTime.Now,
                FechaCreacion = DateTime.Now
            });
            context.Personas.Add(new Persona
            {
                IdPersona = 3,
                Nombre = "Test Nombre3",
                Apellido = "Test Apellido3",
                Edad = 20,
                Correo = "Test Correo3",
                Identificacion = "CC 00000003",
                CiudadNacimiento = "Test Ciudad Nacimiento3",
                Activo = false,
                FechaActualizacion = DateTime.Now,
                FechaCreacion = DateTime.Now
            });

           


            context.SaveChanges();

            return context;
        }
    }
}
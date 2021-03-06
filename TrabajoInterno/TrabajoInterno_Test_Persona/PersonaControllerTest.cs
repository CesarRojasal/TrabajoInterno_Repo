using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrabajoInterno_Api_Persona.Controllers;
using TrabajoInterno_Api_Persona.DTOs;
using TrabajoInterno_Api_Persona.Interfaces;
using TrabajoInterno_Api_Persona.Model;
using Xunit;

namespace TrabajoInterno_Test_Persona
{
    public class PersonaControllerTest
    {
        #region Property
        private readonly PersonaController personaController;
        private readonly Mock<IPersonaService> mockService;
        private readonly PersonaDto persona = new()
        {
            Nombre = "Nombre", Apellido = "Apellido", Edad = 50, Correo = "Correo",
                CiudadNacimiento = "Ciudad Nacimiento", Identificacion = "CC 01"
            };
        private readonly PersonaDto personaRes = new()
        {
            IdPersona = 1, Nombre = "Nombre", Apellido = "Apellido", Edad = 50, Correo = "Correo",
                CiudadNacimiento = "Ciudad Nacimiento", Identificacion = "CC 01"
            };
        #endregion

        public PersonaControllerTest()
        {
            mockService = new Mock<IPersonaService>();
            personaController = new PersonaController(mockService.Object);
        }
        [Fact]
        public async Task GetAllPersona()
        {
            var list = new List<PersonaDto>{personaRes};
            mockService.Setup(s => s.GetAll().Result).Returns(list);

            var resCall = await personaController.GetAll();
            var res = resCall.Result as OkObjectResult;
            var listres = res?.Value;

            mockService.Verify(s => s.GetAll());
            Assert.Equal(200, res?.StatusCode);
            Assert.NotNull(listres);
        }

        [Fact]
        public async Task GetByIdPersona()
        {
            mockService.Setup(s => s.GetById("1").Result).Returns(personaRes);

            var resCall = await personaController.GetById("1");
            var res = resCall.Result as OkObjectResult;

            mockService.Verify(s => s.GetById("1"));
            Assert.Equal(200, res?.StatusCode);

        }

        [Fact]
        public async Task GetByIdentificacion()
        {
            mockService.Setup(s => s.PersonaExistsByIdentificacion(persona.Identificacion).Result).Returns(true);
            mockService.Setup(s => s.GetPersonaByIdentificacion(persona.Identificacion).Result).Returns(personaRes);

            var resCall = await personaController.GetPersonaByIdentificacion(personaRes.Identificacion);
            var res = resCall.Result as OkObjectResult;

            mockService.Verify(s => s.GetPersonaByIdentificacion(persona.Identificacion));
            Assert.Equal(200, res?.StatusCode);

        }

        [Fact]
        public async Task GetPersonaByEdadMayorIgual()
        {
            var list = new List<PersonaDto>{personaRes};
            mockService.Setup(s => s.GetPersonaByEdadMayorIgual(persona.Edad).Result).Returns(list);

            var resCall = await personaController.GetPersonaByEdadMayorIgual(personaRes.Edad);
            var res = resCall.Result as OkObjectResult;

            mockService.Verify(s => s.GetPersonaByEdadMayorIgual(persona.Edad));
            Assert.Equal(200, res?.StatusCode);
        }

        [Fact]
        public async Task PostPersona()
        {
            mockService.Setup(s => s.Insert(persona).Result).Returns(personaRes);
            mockService.Setup(s => s.PersonaExistsByIdentificacion(persona.Identificacion).Result).Returns(false);

            PersonaDto personaDto = new()
            {
                Nombre = "Nombre",
                Apellido = "Apellido",
                Edad = 50,
                Correo = "Correo",
                CiudadNacimiento = "Ciudad Nacimiento",
                Identificacion = "CC 01"
            };

            var resCall = await personaController.Post(personaDto);
            var res = resCall.Result as OkObjectResult;

            Assert.Equal(200, res?.StatusCode);
        }

        [Fact]
        public async Task PutPersona()
        {
            mockService.Setup(s => s.Insert(persona).Result).Returns(personaRes);
            mockService.Setup(s => s.Update(persona).Result).Returns(personaRes);
            mockService.Setup(s => s.PersonaExists(1).Result).Returns(true);

            PersonaDto personaDto = new()
            {
                IdPersona = 1,
                Nombre = "Nombre Up",
                Apellido = "Apellido",
                Edad = 50,
                Correo = "Correo",
                CiudadNacimiento = "Ciudad Nacimiento",
                Identificacion = "CC 01"
            };

            var resCall = await personaController.Put(personaDto, 1);
            var res = resCall.Result as OkObjectResult;

            Assert.Equal(200, res?.StatusCode);
            
        }

        [Fact]
        public async Task DeletePersona()
        {
            mockService.Setup(s => s.GetById(personaRes.IdPersona.ToString()).Result).Returns(personaRes);
            mockService.Setup(s => s.Delete(personaRes.IdPersona.ToString()).Result).Returns((true, 0));

            var resCall = await personaController.Delete(personaRes.IdPersona.ToString());
            var res = resCall.Result as OkObjectResult;

            mockService.Verify(s => s.Delete(personaRes.IdPersona.ToString()));
            Assert.Equal(200, res?.StatusCode);

        }
    }
}
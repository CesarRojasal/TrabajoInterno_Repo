using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrabajoInterno_Api.Controllers;
using TrabajoInterno_Api.DTOs;
using TrabajoInterno_Api.Interfaces;
using TrabajoInterno_Api.Models;
using Xunit;

namespace TrabajoInterno_Test
{
    public class PersonasTest
    {
        #region Property  
        private readonly PersonaController personaController;
        private readonly Mock<IPersonaService> mockService;
        private readonly Persona persona = new Persona()
        {
            Nombre = "Nombre", Apellido = "Apellido", Edad = 50, Correo = "Correo",
                CiudadNacimiento = "Ciudad Nacimiento", Identificacion = "CC 01"
            };
        private readonly Persona personaRes = new Persona()
        {
            IdPersona = 1, Nombre = "Nombre", Apellido = "Apellido", Edad = 50, Correo = "Correo",
                CiudadNacimiento = "Ciudad Nacimiento", Identificacion = "CC 01"
            };
        #endregion

        public PersonasTest()
        {
            mockService = new Mock<IPersonaService>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();

            personaController = new PersonaController(mockMapper.Object, mockService.Object);
        }
        [Fact]
        public async Task GetAllPersona()
        {
            var list = new List<Persona>();
            list.Add(personaRes);
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
            var res = resCall as OkObjectResult;

            mockService.Verify(s => s.GetById("1"));
            Assert.Equal(200, res?.StatusCode);

        }

        [Fact]
        public async Task GetByIdentificacion()
        {
            mockService.Setup(s => s.PersonaExistsByIdentificacion(persona.Identificacion).Result).Returns(true);
            mockService.Setup(s => s.GetPersonaByIdentificacion(persona.Identificacion).Result).Returns(personaRes);

            var resCall = await personaController.GetPersonaByIdentificacion(personaRes.Identificacion);
            var res = resCall as OkObjectResult;

            mockService.Verify(s => s.GetPersonaByIdentificacion(persona.Identificacion));
            Assert.Equal(200, res?.StatusCode);

        }

        [Fact]
        public async Task GetPersonaByEdadMayorIgual()
        {
            var list = new List<Persona>();
            list.Add(personaRes);
            mockService.Setup(s => s.GetPersonaByEdadMayorIgual(persona.Edad).Result).Returns(list);

            var resCall = await personaController.GetPersonaByEdadMayorIgual(personaRes.Edad);
            var res = resCall as OkObjectResult;

            mockService.Verify(s => s.GetPersonaByEdadMayorIgual(persona.Edad));
            Assert.Equal(200, res?.StatusCode);
        }

        [Fact]
        public async Task PostPersona()
        {
            mockService.Setup(s => s.Insert(this.persona).Result).Returns(personaRes);
            mockService.Setup(s => s.PersonaExistsByIdentificacion(persona.Identificacion).Result).Returns(false);

            PersonaDto personaDto = new PersonaDto()
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
            mockService.Setup(s => s.Insert(this.persona).Result).Returns(personaRes);
            mockService.Setup(s => s.PersonaExists(1).Result).Returns(true);
            mockService.Setup(s => s.Update(persona).Result).Returns(personaRes);

            PersonaDto personaDto = new PersonaDto()
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
            var res = resCall as OkObjectResult;

            Assert.Equal(200, res?.StatusCode);
            
        }

        [Fact]
        public async Task DeletePersona()
        {
            mockService.Setup(s => s.GetById(personaRes.IdPersona.ToString()).Result).Returns(personaRes);
            mockService.Setup(s => s.Delete(personaRes.IdPersona.ToString()).Result).Returns(true);

            var resCall = await personaController.Delete(personaRes.IdPersona.ToString());
            var res = resCall as OkObjectResult;

            mockService.Verify(s => s.Delete(personaRes.IdPersona.ToString()));
            Assert.Equal(200, res?.StatusCode);

        }
    }
}
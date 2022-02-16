#nullable disable
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrabajoInterno_Api_Persona.DTOs;
using TrabajoInterno_Api_Persona.Interfaces;

namespace TrabajoInterno_Api_Persona.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaService personaService;
        public PersonaController(IPersonaService personaService)
        {
            this.personaService = personaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonaDto>>> GetAll()
        {
            try { return new OkObjectResult(await personaService.GetAll()); }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonaDto>> GetById(string id)
        {
            try { return new OkObjectResult(await personaService.GetById(id)); }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

        [HttpGet("ByEdadMayorIgual/{Edad}")]
        public async Task<ActionResult<IEnumerable<PersonaDto>>> GetPersonaByEdadMayorIgual(int edad)
        {
            try { return new OkObjectResult(await personaService.GetPersonaByEdadMayorIgual(edad)); }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

        [HttpGet("ByIdentificacion/{identificacion}")]
        public async Task<ActionResult<PersonaDto>> GetPersonaByIdentificacion(string identificacion)
        {
            try
            {
                if (!await personaService.PersonaExistsByIdentificacion(identificacion))
                    return BadRequest(string.Format("no existe la identificacion {0}", identificacion));
                return new OkObjectResult(await personaService.GetPersonaByIdentificacion(identificacion));
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(string id)
        {
            try { 
                 var result = await personaService.Delete(id); 
                return new OkObjectResult(result);
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<ActionResult<PersonaDto>> Post(PersonaDto personaDto)
        {
            try
            {
                if (await personaService.PersonaExistsByIdentificacion(personaDto.Identificacion))
                    return BadRequest(string.Format("Por favor validar la identificacion {0}", personaDto.Identificacion));
                return new OkObjectResult(await personaService.Insert(personaDto));
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<ActionResult<PersonaDto>> Put(PersonaDto personaDto, int id)
        {
            try
            {
                if (personaDto.IdPersona != id)
                    return BadRequest("Por favor validar id");
                if (!await personaService.PersonaExists(id))
                    return NotFound(string.Format("La persona {0} no existe", id));

                return new OkObjectResult(await personaService.Update(personaDto));
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

    }
}

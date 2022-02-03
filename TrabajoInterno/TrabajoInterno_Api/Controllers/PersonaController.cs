#nullable disable
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrabajoInterno_Api.DTOs;
using TrabajoInterno_Api.Interfaces;
using TrabajoInterno_Api.Models;

namespace TrabajoInterno_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaService personaService;
        public readonly IMapper mapper;
        public PersonaController(IMapper mapper, IPersonaService personaService)
        {
            this.mapper = mapper;
            this.personaService = personaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonaDto>>> GetAll()
        {
            try { return new OkObjectResult((await personaService.GetAll()).Select(x => mapper.Map<PersonaDto>(x))); }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonaDto>> GetById(string id)
        {
            try { return new OkObjectResult(mapper.Map<PersonaDto>(await personaService.GetById(id))); }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

        [HttpGet("ByEdadMayorIgual/{Edad}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<ActionResult<IEnumerable<PersonaDto>>> GetPersonaByEdadMayorIgual(int edad)
        {
            try { return new OkObjectResult((await personaService.GetPersonaByEdadMayorIgual(edad)).Select(x => mapper.Map<PersonaDto>(x))); }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

        [HttpGet("ByIdentificacion/{identificacion}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator,Standard")]
        public async Task<ActionResult<PersonaDto>> GetPersonaByIdentificacion(string identificacion)
        {
            try
            {
                if (!await personaService.PersonaExistsByIdentificacion(identificacion))
                    return BadRequest(string.Format("no existe la identificacion {0}", identificacion));
                return new OkObjectResult(mapper.Map<PersonaDto>(await personaService.GetPersonaByIdentificacion(identificacion)));
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(string id)
        {
            try { return new OkObjectResult(await personaService.Delete(id)); }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

        [HttpPost]
        public async Task<ActionResult<PersonaDto>> Post(PersonaDto personaDto)
        {
            try
            {
                if (await personaService.PersonaExistsByIdentificacion(personaDto.Identificacion))
                    return BadRequest(string.Format("Por favor validar la identificacion {0}", personaDto.Identificacion));
                return new OkObjectResult(mapper.Map<PersonaDto>(await personaService.Insert(mapper.Map<Persona>(personaDto))));
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PersonaDto>> Put(PersonaDto personaDto, int id)
        {
            try
            {
                if (personaDto.IdPersona != id)
                    return BadRequest("Por favor validar id");
                if (!await personaService.PersonaExists(id))
                    return NotFound(string.Format("La persona {0} no existe", id));

                return new OkObjectResult(mapper.Map<PersonaDto>(await personaService.Update(mapper.Map<Persona>(personaDto))));
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

    }
}

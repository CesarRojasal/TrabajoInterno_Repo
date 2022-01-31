#nullable disable
using AutoMapper;
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

        private readonly IPersonaService _personaService;
        public readonly IMapper _mapper;
        public PersonaController(IMapper mapper, IPersonaService personaService)
        {
            _mapper = mapper;
            _personaService = personaService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var personas = await _personaService.GetAll();
            return Ok(personas.Select(x => _mapper.Map<PersonaDto>(x)));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(string id)
        {
            var persona = await _personaService.GetById(id);
            if(persona == null)
                return NotFound();
            return Ok(_mapper.Map<PersonaDto>(persona));
        }

        [HttpPost]
        public async Task<ActionResult> Post(PersonaDto personaDto)
        {
            if(!ModelState.IsValid)
                return BadRequest("Por favor validar los datos");
            if (await _personaService.PersonaExistsByIdentificacion(personaDto.Identificacion))
                return BadRequest(string.Format("Por favor validar la identificacion {0}", personaDto.Identificacion));

            try
            {
                var persona = await _personaService.Insert(_mapper.Map<Persona>(personaDto));
                return Ok(persona);
            }
            catch (Exception ex) {return StatusCode(500, ex.Message);}
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(PersonaDto personaDto, int id)
        {
            if(!ModelState.IsValid)
                return BadRequest("Por favor validar los datos");
            if (personaDto.IdPersona != id)
                return BadRequest("Por favor validar id");
            if (!await _personaService.PersonaExists(id))
                return NotFound(string.Format("La persona {0} no existe", id));

            try
            {
                var persona = await _personaService.Update(_mapper.Map<Persona>(personaDto));
                return Ok(persona);
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var persona = await _personaService.GetById(id);
            if (persona == null)
                return NotFound(string.Format("Persona {0} no encontrada", id));

            var resp = await _personaService.Delete(id);

            return Ok(string.Format("Persona Eliminada: {0}", resp));
        }

        [HttpGet("ByEdadMayorIgual/{Edad}")]
        public async Task<ActionResult> GetPersonaByEdadMayorIgual(int edad)
        {
            var personas = await _personaService.GetPersonaByEdadMayorIgual(edad);
            if (personas == null)
                return NotFound();
            return Ok(personas.Select(x => _mapper.Map<PersonaDto>(x)));
        }

        [HttpGet("ByIdentificacion/{identificacion}")]
        public async Task<ActionResult> GetPersonaByIdentificacion(string identificacion)
        {
            if (!await _personaService.PersonaExistsByIdentificacion(identificacion))
                return BadRequest(string.Format("no existe la identificacion {0}", identificacion));

            var persona = await _personaService.GetPersonaByIdentificacion(identificacion);
            if (persona == null)
                return NotFound();
            return Ok(_mapper.Map<PersonaDto>(persona));
        }


    }
}

#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrabajoInterno_Api.Data;
using TrabajoInterno_Api.Models;
using TrabajoInterno_Api.Services;

namespace TrabajoInterno_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {

        private readonly PersonaService _personaService;
        public PersonasController(PersonaService personaService)
        {
            _personaService = personaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persona>>> GetPersonas()
           => await _personaService.GetPersonas();

        [HttpPost]
        public async Task<ActionResult<Persona>> PostPersona(Persona persona)
            => !(await _personaService.PersonaExistsByIdentificacion(persona.Identificacion))
            ? await _personaService.PostPersona(persona)
            : NotFound(String.Format("No se logró crear la persona {0}!!, por favor valide su Identificacion.",persona.Identificacion));
       
        [HttpPut("{id}")]
        public async Task<ActionResult<Persona>> PutPersona(int id, Persona persona) 
            => (id == persona.IdPersona && await _personaService.PersonaExists(id)) 
            ? await _personaService.PutPersona(id, persona)
            : NotFound(String.Format("No se logró Actualizar la persona {0}!!.", id));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersona(int id)
            => await _personaService.DeletePersona(id)? NoContent() : NotFound();

        [HttpGet("{id}")]
        public async Task<ActionResult<Persona>> GetPersonaById(int id)
            => await _personaService.GetPersonaById(id);

        [HttpGet("ByEdadMayorIgual/{Edad}")]
        public async Task<List<Persona>> GetPersonaByEdadMayorIgual(int edad) 
            => await _personaService.GetPersonaByEdadMayorIgual(edad);

        [HttpGet("ByIdentificacion/{identificacion}")]
        public async Task<Persona> GetPersonaByIdentificacion(string identificacion)
            => await _personaService.GetPersonaByIdentificacion(identificacion);



    }
}

using Microsoft.EntityFrameworkCore;
using TrabajoInterno_Api.Data;
using TrabajoInterno_Api.Models;

namespace TrabajoInterno_Api.Services
{
    public class PersonaService
    {
        private readonly MySqlDbContext _context;
        public PersonaService(MySqlDbContext context)
        {
            _context = context;
        }

        public async Task<Persona?> PostPersona(Persona persona)
        {
            var resp = await _context.Database.ExecuteSqlRawAsync("CALL SP_CREATE_PERSONA({0},{1},{2},{3},{4},{5})",
                persona.Nombre,
                persona.Apellido,
                persona.Identificacion,
                persona.Edad,
                persona.CiudadNacimiento,
                persona.Correo);

            if (resp != 1)
                return null;

            return _context.Personas.OrderBy(p => p.IdPersona).LastAsync().Result;
        }

        public async Task<Persona?> PutPersona(int id, Persona persona)
        {
            var resp = await _context.Database.ExecuteSqlRawAsync("CALL SP_UPDATE_PERSONA({0},{1},{2},{3},{4},{5},{6})",
                persona.IdPersona,
                persona.Nombre,
                persona.Apellido,
                persona.Identificacion,
                persona.Edad,
                persona.CiudadNacimiento,
                persona.Correo);

            if (resp != 1)
                return null;

            return _context.Personas.Where(p => p.IdPersona == id).First();
        }

        public async Task<bool> DeletePersona(int id)
        {
            var res = await _context.Database.ExecuteSqlRawAsync(@"CALL SP_DELETE_PERSONA({0})", id);
            await _context.SaveChangesAsync();
            return res == 1;
        }

        public async Task<List<Persona>> GetPersonaByEdadMayorIgual(int edad)
            //=> await _context.Personas.FromSqlRaw("CALL SP_SELECT_PERSONA_BY_EDAD_MAYORIGUAL({0})", edad).ToListAsync();
            => await _context.Personas.Where(p => p.Edad >= edad).ToListAsync();

        public async Task<Persona> GetPersonaByIdentificacion(string identificacion)
            => await _context.Personas.Where(p => p.Identificacion ==  identificacion).FirstAsync();

        public async Task<List<Persona>> GetPersonas()
            => await _context.Personas.FromSqlRaw("CALL SP_SELECT_PERSONA_ALL").ToListAsync();

        public async Task<Persona> GetPersonaById(int id)
        {
            var persona = await _context.Personas.Where(p => p.IdPersona == id).FirstAsync();
            return persona;
        }
        public Task<bool> PersonaExists(int id)
            => _context.Personas.Where(e => e.IdPersona == id).AnyAsync();

        public Task<bool> PersonaExistsByIdentificacion(string identificacion)
            => _context.Personas.Where(e => e.Identificacion == identificacion).AnyAsync();
    }
}

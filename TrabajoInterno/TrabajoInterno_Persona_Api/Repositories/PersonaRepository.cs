using Microsoft.EntityFrameworkCore;
using TrabajoInterno_Api.Data;
using TrabajoInterno_Api.Interfaces;
using TrabajoInterno_Api.Models;

namespace TrabajoInterno_Api.Repositories
{
    public class PersonaRepository : GenericRepository<Persona>, IPersonaRepository
    {
        public PersonaRepository(MySqlDbContext context) : base(context)
        {

        }

        public async Task<bool> PersonaExists(int id)
            => await mySqlDbContext.Personas.Where(e => e.IdPersona == id).AnyAsync();

        public async Task<bool> PersonaExistsByIdentificacion(string identificacion)
            => await mySqlDbContext.Personas.Where(e => e.Identificacion == identificacion).AnyAsync();

        public async Task<List<Persona>> GetPersonaByEdadMayorIgual(int edad)
            => await mySqlDbContext.Personas.Where(e => e.Edad >= edad).ToListAsync();

        public async Task<Persona> GetPersonaByIdentificacion(string identificacion)
            => await mySqlDbContext.Personas.Where(e => e.Identificacion == identificacion).FirstAsync();
    }
}

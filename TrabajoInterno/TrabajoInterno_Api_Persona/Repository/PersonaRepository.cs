using Microsoft.EntityFrameworkCore;
using TrabajoInterno_Api_Persona.Data;
using TrabajoInterno_Api_Persona.Interfaces;
using TrabajoInterno_Api_Persona.Model;
//using TrabajoInterno_RabbitMq_Bus.BusRabbit;
//using TrabajoInterno_RabbitMq_Bus.EventoQueue;

namespace TrabajoInterno_Api_Persona.Repository
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly MySqlDbContext mySqlDbContext;
        
        public PersonaRepository(MySqlDbContext mySqlDbContext)
        {
            this.mySqlDbContext = mySqlDbContext;
        }

        public virtual async Task<IEnumerable<Persona>> GetAll() => await mySqlDbContext.Set<Persona>().ToListAsync();
        
        public virtual async Task<Persona?> GetById(string id) => await mySqlDbContext.Set<Persona>().FindAsync(keyValues: Convert.ToInt32(id));

        public virtual async Task<Persona> Insert(Persona entity)
        {
            mySqlDbContext.Set<Persona>().Add(entity);
            await mySqlDbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<Persona> Update(Persona entity)
        {
            mySqlDbContext.Set<Persona>().Update(entity);
            await mySqlDbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<bool> Delete(string id)
        {
            var entity = await GetById(id);

            if (entity == null)
                return false;

            mySqlDbContext.Set<Persona>().Remove(entity);
            await mySqlDbContext.SaveChangesAsync();
            return true;
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

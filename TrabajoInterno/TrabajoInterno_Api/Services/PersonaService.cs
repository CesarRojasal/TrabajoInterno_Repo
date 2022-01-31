using TrabajoInterno_Api.Interfaces;
using TrabajoInterno_Api.Models;

namespace TrabajoInterno_Api.Services
{
    public class PersonaService : GenericService<Persona>, IPersonaService
    {
        private readonly IPersonaRepository personaRepository;

        public PersonaService(IPersonaRepository personaRepository) : base(personaRepository)
        {
            this.personaRepository = (IPersonaRepository)genericRepository;
        }

        public async Task<bool> PersonaExists(int id)
            => await personaRepository.PersonaExists(id);

        public async Task<bool> PersonaExistsByIdentificacion(string identificacion)
            => await personaRepository.PersonaExistsByIdentificacion(identificacion);

        public async Task<List<Persona>> GetPersonaByEdadMayorIgual(int edad)
            => await personaRepository.GetPersonaByEdadMayorIgual(edad);

        public async Task<Persona> GetPersonaByIdentificacion(string identificacion)
            => await personaRepository.GetPersonaByIdentificacion(identificacion);

    }
}

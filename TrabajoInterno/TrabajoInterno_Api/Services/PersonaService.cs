using TrabajoInterno_Api.Interfaces;
using TrabajoInterno_Api.Models;

namespace TrabajoInterno_Api.Services
{
    public class PersonaService : GenericService<Persona>, IPersonaService
    {
        private readonly IPersonaRepository personaRepository;
        private readonly IImagenRepository imagenRepository;

        public PersonaService(IPersonaRepository personaRepository,
            IImagenRepository imagenRepository) : base(personaRepository)
        {
            this.personaRepository = personaRepository;
            this.imagenRepository = imagenRepository;
        }

        public override async Task<bool> Delete(string id)
        {
            var persona = await personaRepository.GetById(id);
            if (persona == null)
                return false;
            var imagenDeleteRes = await imagenRepository.DeleteImagenByIdPersona(persona.IdPersona);
            if (imagenDeleteRes)
                return await personaRepository.Delete(id);
            else
                return false;
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

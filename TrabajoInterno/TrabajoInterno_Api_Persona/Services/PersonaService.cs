using AutoMapper;
using TrabajoInterno_Api_Persona.DTOs;
using TrabajoInterno_Api_Persona.Interfaces;
using TrabajoInterno_Api_Persona.Model;
using TrabajoInterno_Api_Persona.Remote.RemoteInterfaces;

namespace TrabajoInterno_Api_Persona.Services
{ 
    public class PersonaService : IPersonaService
    {
        private readonly IPersonaRepository personaRepository;
        private readonly IRemoteImagenService imagenService;
        public readonly IMapper mapper;

        public PersonaService(IPersonaRepository personaRepository, IRemoteImagenService imagenService, IMapper mapper) 
        {
            this.personaRepository = personaRepository;
            this.imagenService = imagenService;
            this.mapper = mapper;
        }


        public async Task<IEnumerable<PersonaDto>> GetAll() 
            => (await personaRepository.GetAll()).Select(x => mapper.Map<PersonaDto>(x));

        public async Task<PersonaDto?> GetById(string id) 
            => mapper.Map<PersonaDto>(await personaRepository.GetById(id));

        public async Task<PersonaDto> Insert(PersonaDto personaDto) 
            => mapper.Map<PersonaDto>(await personaRepository.Insert(mapper.Map<Persona>(personaDto)));

        public async Task<PersonaDto> Update(PersonaDto personaDto) 
            => mapper.Map<PersonaDto>(await personaRepository.Update(mapper.Map<Persona>(personaDto)));

        public async Task<(bool resultado, int totalImagenes)> Delete(string id)
        {
            var persona = await personaRepository.GetById(id);
            if (persona == null)
                throw new Exception("Persona No Encontrada");
            var totalImagenes = await imagenService.DeleteImagenByIdPersona(persona.IdPersona);
            var result = await personaRepository.Delete(id);
            return (result, totalImagenes);
        }

        public async Task<bool> PersonaExists(int id)
            => await personaRepository.PersonaExists(id);

        public async Task<bool> PersonaExistsByIdentificacion(string identificacion)
            => await personaRepository.PersonaExistsByIdentificacion(identificacion);

        public async Task<IEnumerable<PersonaDto>> GetPersonaByEdadMayorIgual(int edad)
            => (await personaRepository.GetPersonaByEdadMayorIgual(edad)).Select(x => mapper.Map<PersonaDto>(x));

        public async Task<PersonaDto> GetPersonaByIdentificacion(string identificacion)
            => mapper.Map<PersonaDto>(await personaRepository.GetPersonaByIdentificacion(identificacion));

    }
}

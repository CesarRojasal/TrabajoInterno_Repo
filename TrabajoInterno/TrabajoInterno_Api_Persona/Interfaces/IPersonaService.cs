using TrabajoInterno_Api_Persona.DTOs;
using TrabajoInterno_Api_Persona.Model;

namespace TrabajoInterno_Api_Persona.Interfaces
{
    public interface IPersonaService
    {
        Task<IEnumerable<PersonaDto>> GetAll();
        Task<PersonaDto?> GetById(string id);
        Task<PersonaDto> Insert(PersonaDto personaDto);
        Task<PersonaDto> Update(PersonaDto personaDto);
        Task<(bool resultado, int totalImagenes)> Delete(string id);
        Task<bool> PersonaExists(int id);
        Task<bool> PersonaExistsByIdentificacion(string identificacion);
        Task<IEnumerable<PersonaDto>> GetPersonaByEdadMayorIgual(int edad);
        Task<PersonaDto> GetPersonaByIdentificacion(string identificacion);
    }
}

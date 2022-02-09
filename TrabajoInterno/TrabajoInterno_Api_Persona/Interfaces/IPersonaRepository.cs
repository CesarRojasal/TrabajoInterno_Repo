using TrabajoInterno_Api_Persona.Model;

namespace TrabajoInterno_Api_Persona.Interfaces
{
    public interface IPersonaRepository
    {
        Task<IEnumerable<Persona>> GetAll();
        Task<Persona?> GetById(string id);
        Task<Persona> Insert(Persona entity);
        Task<Persona> Update(Persona entity);
        Task<bool> Delete(string id);
        Task<bool> PersonaExists(int id);
        Task<bool> PersonaExistsByIdentificacion(string identificacion);
        Task<List<Persona>> GetPersonaByEdadMayorIgual(int edad);
        Task<Persona> GetPersonaByIdentificacion(string identificacion);
    }
}

namespace TrabajoInterno_Api_Persona.Remote.RemoteInterface
{
    public interface IRemoteImagenService
    {
        Task<int> DeleteImagenByIdPersona(int idPersona);
    }
}

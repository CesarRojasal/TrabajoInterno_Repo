namespace TrabajoInterno_Api_Persona.Remote.RemoteInterfaces
{
    public interface IRemoteImagenService
    {
        Task<int> DeleteImagenByIdPersona(int idPersona);
    }
}

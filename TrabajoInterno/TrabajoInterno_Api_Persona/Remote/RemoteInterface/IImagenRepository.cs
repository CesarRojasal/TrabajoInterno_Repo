namespace TrabajoInterno_Api_Persona.RemoteInterfaces
{
    public interface IImagenRepository
    {
        Task<int> DeleteImagenByIdPersona(int idPersona);
    }
}

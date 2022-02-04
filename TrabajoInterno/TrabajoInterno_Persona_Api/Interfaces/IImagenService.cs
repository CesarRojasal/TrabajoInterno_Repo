using TrabajoInterno_Api.Models;

namespace TrabajoInterno_Api.Interfaces
{
    public interface IImagenService : IGenericService<Imagen>
    {
        Task<bool> DeleteImagenByIdPersona(int idPersona);
    }
}

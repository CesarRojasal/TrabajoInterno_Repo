using TrabajoInterno_Api.Models;

namespace TrabajoInterno_Api.Interfaces
{
    public interface IImagenRepository : IGenericRepository<Imagen>
    {
        Task<bool> DeleteImagenByIdPersona(int idPersona);
    }
}

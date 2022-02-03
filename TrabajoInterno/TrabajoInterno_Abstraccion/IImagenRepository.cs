using TrabajoInterno_Entities;

namespace TrabajoInterno_Abstraccion
{
    public interface IImagenRepository : IGenericRepository<Imagen>
    {
        Task<bool> DeleteImagenByIdPersona(int idPersona);
    }
}

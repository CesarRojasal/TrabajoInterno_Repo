using TrabajoInterno_Entities;

namespace TrabajoInterno_Abstraccion
{
    public interface IImagenService : IGenericService<Imagen>
    {
        Task<bool> DeleteImagenByIdPersona(int idPersona);
    }
}

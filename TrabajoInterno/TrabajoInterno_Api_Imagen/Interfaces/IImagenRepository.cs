using TrabajoInterno_Api_Imagen.Models;

namespace TrabajoInterno_Api_Imagen.Interfaces
{
    public interface IImagenRepository
    {
        Task<IEnumerable<Imagen>> GetAll();
        Task<Imagen?> GetById(string id);
        Task<Imagen> Insert(Imagen imagen);
        Task<Imagen> Update(Imagen imagen);
        Task<bool> Delete(string id);
        Task<int> DeleteImagenByIdPersona(int idPersona);
    }
}

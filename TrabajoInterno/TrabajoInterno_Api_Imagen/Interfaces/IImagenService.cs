using TrabajoInterno_Api_Imagen.DTOs;

namespace TrabajoInterno_Api_Imagen.Interfaces
{
    public interface IImagenService
    {
        Task<IEnumerable<ImagenDto>> GetAll();
        Task<ImagenDto?> GetById(string id);
        Task<ImagenDto> Insert(ImagenDto imagenDto);
        Task<ImagenDto> Update(ImagenDto imagenDto);
        Task<bool> Delete(string id);
        Task<int> DeleteImagenByIdPersona(int idPersona);
    }
}

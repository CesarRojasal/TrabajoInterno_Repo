using TrabajoInterno_Abstraccion;
using TrabajoInterno_Entities;

namespace TrabajoInterno_Services
{
    public class ImagenService : GenericService<Imagen>, IImagenService
    {
        private readonly IImagenRepository imagenRepository;
        public ImagenService(IImagenRepository imagenRepository) : base(imagenRepository)
        {
            this.imagenRepository = imagenRepository;
        }

        public async Task<bool> DeleteImagenByIdPersona(int idPersona)
        {
            return await imagenRepository.DeleteImagenByIdPersona(idPersona);
        }
    }
}

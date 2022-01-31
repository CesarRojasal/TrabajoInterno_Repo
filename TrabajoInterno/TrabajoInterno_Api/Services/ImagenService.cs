using TrabajoInterno_Api.Interfaces;
using TrabajoInterno_Api.Models;

namespace TrabajoInterno_Api.Services
{
    public class ImagenService : GenericService<Imagen>, IImagenService
    {
        public ImagenService(IImagenRepository genericRepository) : base(genericRepository)
        {
        }
    }
}

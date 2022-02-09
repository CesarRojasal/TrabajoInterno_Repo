using AutoMapper;
using TrabajoInterno_Api_Imagen.DTOs;
using TrabajoInterno_Api_Imagen.Interfaces;
using TrabajoInterno_Api_Imagen.Models;

namespace TrabajoInterno_Services
{
    public class ImagenService : IImagenService
    {
        private readonly IImagenRepository imagenRepository;
        public readonly IMapper mapper;
        public ImagenService(IImagenRepository imagenRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.imagenRepository = imagenRepository;
        }

        public virtual async Task<bool> Delete(string id) 
            => await imagenRepository.Delete(id);

        public async Task<IEnumerable<ImagenDto>> GetAll() 
            => (await imagenRepository.GetAll()).Select(x => mapper.Map<ImagenDto>(x));

        public async Task<ImagenDto?> GetById(string id) 
            => mapper.Map<ImagenDto>(await imagenRepository.GetById(id));

        public async Task<ImagenDto> Insert(ImagenDto imagenDto) 
            => mapper.Map<ImagenDto>(await imagenRepository.Insert(mapper.Map<Imagen>(imagenDto)));

        public async Task<ImagenDto> Update(ImagenDto imagenDto) 
            => mapper.Map<ImagenDto>(await imagenRepository.Update(mapper.Map<Imagen>(imagenDto)));

        public async Task<int> DeleteImagenByIdPersona(int idPersona)
        {
            return await imagenRepository.DeleteImagenByIdPersona(idPersona);
        }
    }
}

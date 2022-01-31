using AutoMapper;
using TrabajoInterno_Api.Models;
using TrabajoInterno_Api.DTOs;

namespace TrabajoInterno_Api.Common
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Persona, PersonaDto>();
            CreateMap<PersonaDto, Persona>();

            CreateMap<Imagen, ImagenDto>();
            CreateMap<ImagenDto, Imagen>();
        }
    }
}

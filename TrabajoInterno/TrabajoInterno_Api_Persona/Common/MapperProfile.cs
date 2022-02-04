using AutoMapper;
using TrabajoInterno_Api_Persona.DTOs;
using TrabajoInterno_Entities;

namespace TrabajoInterno_Api_Persona.Common
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Persona, PersonaDto>();
            CreateMap<PersonaDto, Persona>();
        }
    }
}

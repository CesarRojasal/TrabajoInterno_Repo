using AutoMapper;
using TrabajoInterno_Api.Models;
using TrabajoInterno_Api.DTOs;

namespace TrabajoInterno_Api.Common
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Persona, PersonaDto>();//Get
            CreateMap<PersonaDto, Persona>();//POST-PU
        }
    }
}

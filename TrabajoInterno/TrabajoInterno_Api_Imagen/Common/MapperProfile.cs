﻿using AutoMapper;
using TrabajoInterno_Api_Imagen.DTOs;
using TrabajoInterno_Entities;

namespace TrabajoInterno_Api_Imagen.Common
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Imagen, ImagenDto>();
            CreateMap<ImagenDto, Imagen>();
        }
    }
}

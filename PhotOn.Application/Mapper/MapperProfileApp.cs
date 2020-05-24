using AutoMapper;
using PhotOn.Application.Dto;
using PhotOn.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotOn.Application.Mapper
{
    public class MapperProfileApp : Profile
    {
        public MapperProfileApp()
        {
            CreateMap<Equipment, EquipmentDto>().ReverseMap();

            CreateMap<Publication, PublicationDto>()
                .ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();

            CreateMap<User, String>().ConvertUsing(u => u.UserName);

            CreateMap<Event, EventDto>().ReverseMap();

        }
    }
}

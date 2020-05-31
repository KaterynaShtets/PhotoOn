using AutoMapper.QueryableExtensions;
using AutoMapper;
using PhotOn.Application.Models;
using PhotOn.Core.Entities;
using System;
using System.Linq;
using PhotOn.Application.Dtos;

namespace PhotOn.Application.Mapper
{
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<AspnetRunDtoMapper>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });
        public static IMapper Mapper => Lazy.Value;
    }

    public class AspnetRunDtoMapper : Profile
    {
        public AspnetRunDtoMapper()
        {
            // Single mapping

            CreateMap<Equipment, EquipmentDto>().ReverseMap();
            CreateMap<Tag, TagDto>().ReverseMap();
            CreateMap<ApplicationUser, UserDto>()
                .ReverseMap();
            CreateMap<PublicationCreationDto, Publication>()
                .ForMember(x => x.ImageLink, options => options.Ignore());
            CreateMap<Publication, PublicationDetailsDto>()
               .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
               .ForMember(dest => dest.EquipmentModels, opt => opt.MapFrom(src => src.PublicationEquipments.Select(e => e.Equipment)))
               .ForMember(dest => dest.TagModels, opt => opt.MapFrom(src => src.PublicationTags.Select(e => e.Tag))).ReverseMap();

        }
    }
}

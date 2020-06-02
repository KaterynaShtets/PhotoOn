using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PhotOn.Application.Dtos;
using PhotOn.Core.Entities;
using PhotOn.Web.ViewModels;
using PhotOn.Web.ViewModels.Account;
using PhotOn.Web.ViewModels.Publications;
using System;

namespace PhotOn.Web.Mapper
{
    public static class WebMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<PhotOnProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });
        public static IMapper Mapper => Lazy.Value;
    }

    public class PhotOnProfile : Profile
    {
        public PhotOnProfile()
        {
            CreateMap<PublicationDetailsDto, PublicationViewModel>().ReverseMap();
            CreateMap<PublicationCreationDto, PublicationViewModel>().ReverseMap();
            CreateMap<ApplicationUser, UserViewModel>()
                .ForMember(m => m.Password, opt => opt.MapFrom(src => src.PasswordHash))
                .ReverseMap();
            CreateMap<IdentityRole, RoleViewModel>().ReverseMap();
            CreateMap<UserDto, ApplicationUser>().ReverseMap();
            CreateMap<PublicationDetailsDto, PublicationViewModel>()
                .ReverseMap();
            CreateMap<PublicationCreationDto, PublicationViewModel>().ReverseMap();
        }
    }
}
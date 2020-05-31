using AutoMapper;
using PhotOn.Application.Dtos;
using PhotOn.Application.Models;
using PhotOn.Core.Entities;

namespace PhotOn.Web.Mapper
{
    public class PhotOnProfile : Profile
    {
        public PhotOnProfile()
        {
            CreateMap<UserDto, ApplicationUser>().ReverseMap();
        }
    }
}

using AutoMapper;
using PhotOn.Application.Models;
using PhotOn.Core.Entities;

namespace PhotOn.Web.Mapper
{
    public class PhotOnProfile : Profile
    {
        public PhotOnProfile()
        {
            CreateMap<UserModel, ApplicationUser>().ReverseMap();
        }
    }
}

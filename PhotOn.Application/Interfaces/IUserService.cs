
using Microsoft.AspNetCore.Identity;
using PhotOn.Application.Dtos;
using PhotOn.Application.Models;
using PhotOn.Core.Entities;
using System.Threading.Tasks;

namespace PhotOn.Application.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUser> GetCurrentUser();
        UserToken CreateToken(string email);
        //Task<IEnumerable<UserModel>> GetUserList(PagginationModel pagination);
    }
}


using Microsoft.AspNetCore.Identity;
using PhotOn.Application.Dtos;
using PhotOn.Application.Models;
using System.Threading.Tasks;

namespace PhotOn.Application.Interfaces
{
    public interface IUserService
    {
        UserToken CreateToken(string email);
        //Task<IEnumerable<UserModel>> GetUserList(PagginationModel pagination);
    }
}

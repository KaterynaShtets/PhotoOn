
using Microsoft.AspNetCore.Identity;
using PhotOn.Application.Dtos;
using PhotOn.Application.Models;
using PhotOn.Core.Entities;
using System;
using System.Threading.Tasks;

namespace PhotOn.Application.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUser> GetCurrentUser();
        string GetCurrentUserId();
        UserToken CreateToken(string email);

        bool CheckUserAge(DateTime dob);
        bool CheckUserBalance(int balance, int sum);
        //Task<IEnumerable<UserModel>> GetUserList(PagginationModel pagination);
    }
}

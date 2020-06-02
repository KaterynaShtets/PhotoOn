using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PhotOn.Application.Interfaces;
using PhotOn.Application.Dtos;
using PhotOn.Application.Models;
using PhotOn.Core.Entities;
using PhotOn.Core.Repositories;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PhotOn.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public UserToken CreateToken(string email)
        {
            var issuer = _configuration["Tokens:Issuer"];
            var audience = _configuration["Tokens:Audience"];
            var key = _configuration["Tokens:Key"];

            var claims = new[]
            {
                new Claim(ClaimTypes.Name,email),
                new Claim(ClaimTypes.Email,email),
            };

            var keyBytes = Encoding.UTF8.GetBytes(key);
            var theKey = new SymmetricSecurityKey(keyBytes);
            var creds = new SigningCredentials(theKey, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.Now.AddDays(1);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: issuer,
                audience,
                claims,
                expires : expiration,
                signingCredentials: creds);

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }

        public bool CheckUserBalance(int balance, int sum)
        {
            if (balance < sum)
            {
                return false;
            }

            return true;
        }

        public bool CheckUserAge(DateTime dob)
        {
            var today = DateTime.Today;
            var age = today.Year - dob.Year;

            if (age > 16)
            {
                return true;
            }

            return false;
        }


        public string GetCurrentUserId()
        {
            return _httpContextAccessor.HttpContext.User
                .FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        public  async Task<ApplicationUser> GetCurrentUser() 
        {
            return  await _userManager.FindByIdAsync(GetCurrentUserId());
        }
    }
}

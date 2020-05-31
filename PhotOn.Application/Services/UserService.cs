﻿using AutoMapper;
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

namespace PhotOn.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(IConfiguration configuration, IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
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

        
    }
}

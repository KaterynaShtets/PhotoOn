using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using PhotOn.Application.Interfaces;
using PhotOn.Core.Entities;
using PhotOn.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PhotOn.Application.Services
{
    public class UtilService : IUtilService
    {
        private readonly IUnitOfWork _db;
        private readonly ILogger<UtilService> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;

        public UtilService(IUnitOfWork unitOfWork, IUserService userService, ILogger<UtilService> logger, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager)
        {
            _db = unitOfWork;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _userService = userService;
        }

        public bool CheckBalance(int balance, int sum) 
        {
            if (balance < sum) 
            {
                return false;
            }

            return true;
        }

       
        public async void DebitFromAccout(int sum)
        {
            var user = await _userService.GetCurrentUser();
            user.Balance -= sum;
            await _userManager.UpdateAsync(user);
            _db.Save();
        }

        public async void ReplenishBalance(int sum)
        {
            var user = await _userService.GetCurrentUser();
            user.Balance += sum;
            await _userManager.UpdateAsync(user);
            _db.Save();
        }
    }
}

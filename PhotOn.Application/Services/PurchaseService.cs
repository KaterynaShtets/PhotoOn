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

namespace PhotOn.Application.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IUnitOfWork _db;
        private readonly ILogger<PurchaseService> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PurchaseService(IUnitOfWork unitOfWork, ILogger<PurchaseService> logger, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager)
        {
            _db = unitOfWork;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }
        public void DebitFromAccout(decimal sum)
        {
           
            
        }

        public void ReplenishBalance(decimal sum)
        {
            throw new NotImplementedException();
        }
    }
}

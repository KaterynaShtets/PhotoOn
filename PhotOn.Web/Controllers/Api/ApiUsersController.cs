using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PhotOn.Application.Interfaces;
using PhotOn.Core.Entities;

namespace PhotOn.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiUsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public ApiUsersController(IUserService userService, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> manager, SignInManager<ApplicationUser> signInManager, IMapper mapper)
        {
            _userService = userService;
            _userManager = manager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhotOn.Application.Dtos;
using PhotOn.Application.Interfaces;
using PhotOn.Application.Model.Dtos;
using PhotOn.Application.Models;
using PhotOn.Core.Entities;
using PhotOn.Web.Helpers;
using PhotoOn.Application.Models;

namespace PhotOn.Web.Controllers.Api
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public AccountController(IUserService userService, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> manager, SignInManager<ApplicationUser> signInManager, IMapper mapper)
        {
            _userService = userService;
            _userManager = manager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        [HttpPost("signup")]
        public async Task<ActionResult<UserToken>> Create([FromBody] UserCreationDto registrationModel)
        {
            var userEntity = new ApplicationUser
            {
                Email = registrationModel.Email,
                UserName = registrationModel.Email,
                DOB = registrationModel.DOB,
            };

            var result = await _userManager.CreateAsync(userEntity, registrationModel.Password);
            
            if (result.Succeeded)
            {
                var roleId =  _roleManager.Roles.SingleOrDefault(R => R.Name == "User").Id;
                await _userManager.AddToRoleAsync(userEntity, "USER");
                
                return _userService.CreateToken(registrationModel.Email);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserToken>> Login([FromBody] UserCreationDto loginModel)
        {
            var result = await _signInManager.PasswordSignInAsync(
                loginModel.Email,
                loginModel.Password,
                isPersistent: false,
                lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return _userService.CreateToken(loginModel.Email);
            }
            else
            {
                return BadRequest("Invalid Login Attempt");
            }
        }

        [HttpPost("renewtoken")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<UserToken> Renew()
        {
            return _userService.CreateToken(HttpContext.User.Identity.Name);
        }

        [HttpGet("Users")]
        public ActionResult<IEnumerable<UserDto>> Get([FromQuery] PaginationModel pagination)
        {
            var usersList = _userManager.Users.ToList();
            HttpContext.InsertPaginationParametersInRepsonse(usersList, pagination.RecordsPerPage);
            var padinatesList = usersList.Paginate(pagination);
            return Ok(_mapper.Map<IEnumerable<UserDto>>(padinatesList));
        }


        [HttpGet("roles")]
        public async Task<ActionResult<IEnumerable<string>>> GetRoles()
        {
            List<string> roles = new List<string>();
            await _roleManager.Roles.ForEachAsync(r => roles.Add(r.Name));
            return roles;
        }

        [HttpGet("assignRole")]
        public async Task<ActionResult> AssignRole(EditRoleDto editRoleModel)
        {
            var user = await _userManager.FindByIdAsync(editRoleModel.UserId);
            if (user == null)
            {
                return NotFound();
            }

            await _userManager.RemoveClaimAsync(user, new Claim(ClaimTypes.Role, editRoleModel.RoleName));
            return NoContent();

        }
    }
}

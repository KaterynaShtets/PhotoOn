using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PhotOn.Application.Interfaces;
using PhotOn.Core.Entities;
using PhotOn.Web.Mapper;
using PhotOn.Web.Service;
using PhotOn.Web.ViewModels.Account;

    public class AdminController : Controller
    {

    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IEmailSender _emailSender;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IUserService _userService;

    public AdminController(IUserService userService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, IEmailSender emailSender)
    {
        _userManager = userManager;
        _emailSender = emailSender;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _userService = userService;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    //[Authorize(Roles = RoleName.Admin)]
    public ActionResult ChangeRole(ChangeRoleViewModel changeRoleModel)
    {
        var userId = changeRoleModel.UserViewModel.Id;

        var user = _userManager.Users
            .SingleOrDefault(u => u.Id == userId);

        var roleInDbName = _userManager
            .GetRolesAsync(user).Result.First();

        var newRoleName = _roleManager.Roles
            .SingleOrDefault(r => r.Id == changeRoleModel.UserViewModel.RoleId).Name;

        try
        {
            if (user == null)
                throw new ArgumentException("No user exists with such id");

            if (roleInDbName == null)
                throw new ArgumentException("No role exists with such name");

            var noRoleIdentity = _userManager.RemoveFromRoleAsync(user, roleInDbName).Result;

            var newRoleIdentity = _userManager.AddToRoleAsync(user, newRoleName).Result;
        }
        catch (ArgumentException e)
        {
            throw new Exception(e.Message);
        }

        return RedirectToAction("GetUsers");
    }

    //[Authorize(Roles = RoleName.Admin)]
    public ActionResult GetUsers()
    {
        var usersInDb = _userManager.Users.ToList();
        var userViewModels =
            WebMapper.Mapper.Map<IEnumerable<UserViewModel>>(usersInDb);

        foreach (var user in userViewModels)
        {
            var appUser = WebMapper.Mapper.Map<ApplicationUser>(user);
            var role = _userManager.GetRolesAsync(appUser);
            user.RoleName = role.Result.First();
        }

        var usersViewModel = new UsersViewModel();
        usersViewModel.UserViewModels = userViewModels;

        return View(usersViewModel);
    }

    //[Authorize(Roles = RoleName.Admin)]
    public ActionResult GetUser(string userId)
    {
        ApplicationUser user;
        string roleName;
        try
        {
            user = _userManager.Users.SingleOrDefault(u => u.Id == userId);
            roleName = _userManager.GetRolesAsync(user).Result.First();
        }
        catch (ArgumentException e)
        {
            throw new Exception(e.Message);
        }

        // только админ может изменять других пользователей
        //var principal = HttpContext.User;
        //if (principal.IsInRole(RoleName.Admin))
        //{
        var userViewModel =
            WebMapper.Mapper.Map<UserViewModel>(user);

        var roles = _roleManager.Roles;
        var roleViewModels =
            WebMapper.Mapper.Map<List<RoleViewModel>>(roles);

        var userRole = roleViewModels.SingleOrDefault(r => r.Name == roleName);
        userViewModel.RoleId = userRole.Id;
        userViewModel.RoleName = roleName;

        var viewModel = new ChangeRoleViewModel();
        viewModel.UserViewModel = userViewModel;
        viewModel.RoleViewModels = roleViewModels;

        return View("GetUser", viewModel);
        //}
        //else
        //{
        //    return View();
        //}
    }
}

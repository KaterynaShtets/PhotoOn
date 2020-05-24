using PhotOn.Application.Dto;
using PhotOn.Application.Interfaces;
using PhotOn.Core.Entities;
using PhotOn.Core.Repositories;
using PhotOn.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PhotOn.Application.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public Task<OperationDetails> Create(UserDto userDto)
        {
            throw new NotImplementedException();
        }

        public Task<ClaimsIdentity> Authenticate(UserDto userDto)
        {
            throw new NotImplementedException();
        }

        public Task SetInitialData(IEnumerable<UserDto> userDtos, List<string> roles)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public UserDto GetUser(string userId)
        {
            throw new NotImplementedException();
        }

        public UserDto GetUserByName(string userName)
        {
            throw new NotImplementedException();
        }

        public void ChangeRole(string userId, RoleDto roleDto)
        {
            throw new NotImplementedException();
        }

        public RoleDto GetRole(string roleId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RoleDto> GetRoles()
        {
            throw new NotImplementedException();
        }
    }
}

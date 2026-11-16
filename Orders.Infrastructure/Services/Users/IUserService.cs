using Orders.Core.Dto;
using Orders.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Orders.Infrastructure.Services.Users
{
    public interface IUserService
    {
        Task<List<UserViewModel>> GetAll(string searchKey);
        Task<string> Delete(string id);
        Task<UserViewModel> Get(string id);
        Task<string> Create(CreateUserDto dto);
        Task<string> Update(UpdateUserDto dto);
    }
}

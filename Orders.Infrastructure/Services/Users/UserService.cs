using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Orders.API.Data;
using Orders.Core.Dto;
using Orders.Core.ViewModels;
using Orders.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Orders.Infrastructure.Services.Users
{
    public class UserService : IUserService
    {
        private readonly OrdersDbContext _db;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public UserService(OrdersDbContext db, IMapper mapper, UserManager<User> userManager)
        {
            _db = db;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<List<UserViewModel>> GetAll(string searchKey)
        {
            var users = _db.Users.Where(x => x.FullName.Contains(searchKey) || x.PhoneNumber.Contains(searchKey) || string.IsNullOrEmpty(searchKey));
            var userVms = _mapper.Map<List<UserViewModel>>(users);
            return userVms;
        }

        public async Task<string> Delete(string id)
        {
            var user = _db.Users.SingleOrDefault(x => x.Id == id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            user.IsDelete = true;
            _db.Users.Update(user);
            _db.SaveChanges();
            return user.Id;
        }

        public async Task<UserViewModel> Get(string id)
        {
            var user = _db.Users.SingleOrDefault(x => x.Id == id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            var userVm = _mapper.Map<UserViewModel>(user);
            return userVm;
        }

        public async Task<string> Create(CreateUserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            user.UserName = dto.PhoneNumber;
            await _userManager.CreateAsync(user, dto.Password);
            return user.Id;
        }

        public async Task<string> Update(UpdateUserDto dto)
        {
            var user = _db.Users.SingleOrDefault(x => x.Id == dto.Id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            var updatedUser = _mapper.Map(dto, user);
            _db.Update(user);
            _db.SaveChanges();
            return user.Id;
        }


    }
}

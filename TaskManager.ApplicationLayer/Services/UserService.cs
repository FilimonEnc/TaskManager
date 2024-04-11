﻿using TaskManager.ApplicationLayer.Interfaces.IServices;
using TaskManager.ApplicationLayer.Interfaces.IRepositories;
using TaskManager.Core.Entities;
using TaskManager.ApplicationLayer.Models;

namespace TaskManager.ApplicationLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task AddUser(User user)
        {
            await _userRepository.Add(user);
        }

        public async Task UpdateUser(User user)
        {
            await _userRepository.Update(user);
        }

        public async Task DeleteUser(User user)
        {
            await _userRepository.Delete(user);
        }

        public async Task<UserModel> Authorization(string login, string password)
        {
            return await _userRepository.Login(login, password);
        }


    }
}
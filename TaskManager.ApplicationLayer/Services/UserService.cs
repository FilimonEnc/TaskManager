using Mapster;
using TaskManager.ApplicationLayer.Exceptions;
using TaskManager.ApplicationLayer.Exceptions.User;
using TaskManager.ApplicationLayer.Interfaces.IServices;
using TaskManager.ApplicationLayer.Interfaces.IRepositories;
using TaskManager.Core.Entities;
using TaskManager.ApplicationLayer.Models;
using System.Collections.Generic;

namespace TaskManager.ApplicationLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result> AddUser(User user)
        {
            await _userRepository.Add(user);
            return Result.Success();
        }

        public async Task<Result> UpdateUser(User user)
        {
            await _userRepository.Update(user);
            return Result.Success();
        }

        public async Task<Result> DeleteUser(User user)
        {
            await _userRepository.Delete(user);
            return Result.Success();
        }

        public async Task<Result<List<UserModel>>> GetUsers()
        {
            var users = await _userRepository.GetAll();
            return Result<List<UserModel>>.Success(users.Adapt<List<UserModel>>());
        }

        public async Task<Result> Authorization(string login, string password)
        {
            var user =  await _userRepository.Login(login, password);
            return user == null ? Result.Failure(UserError.UserIncorrect) : Result.Success();
        }


    }
}
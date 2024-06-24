using System.Security.Cryptography;
using System.Text;
using Mapster;
using TaskManager.ApplicationLayer.Exceptions;
using TaskManager.ApplicationLayer.Exceptions.User;
using TaskManager.ApplicationLayer.Interfaces.IServices;
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

        public async Task<Result> AddUser(User user)
        {
            user.Password = MakeHash(user.Password);
            var userFinal = await _userRepository.Add(user);
            if (userFinal == null)
                return Result.Failure(UserError.UserAllReadyHave);
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
            string hashPassword = MakeHash(password);
            var user =  await _userRepository.Login(login, hashPassword);
            return user == null ? Result.Failure(UserError.UserIncorrect) : Result.Success();
        }
        
        private static string MakeHash(string password)
        {
            byte[] data = Encoding.Default.GetBytes(password);
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] result = sha256.ComputeHash(data);
                return Convert.ToBase64String(result);
            }
        }


    }
}
using System.Threading.Tasks;

using TaskManager.Entities;
using TaskManager.Interfaces.IRepositories;
using TaskManager.Interfaces.IServices;
using TaskManager.Models;

namespace TaskManager.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async void AddUser(User user)
        {
            await _userRepository.Add(user);
        }

        public async void UpdateUser(User user)
        {
            await _userRepository.Update(user);
        }

        public async void DeleteUser(User user)
        {
            await _userRepository.Delete(user);
        }

        public async Task<UserModel> Authorization(string login, string password)
        {
          return await _userRepository.Login(login, password);
        }


    }
}
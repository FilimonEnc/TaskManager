using TaskManager.Entities;
using TaskManager.Interfaces;
using TaskManager.Repositories;

namespace TaskManager.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async void AddUser(User user)
        {
            await _userRepository.Add(user);
        }



    }
}
using System.Collections.Generic;
using System.Threading.Tasks;

using TaskManager.Entities;
using TaskManager.Models;

namespace TaskManager.Repositories
{
    public interface IUserRepository
    {
        Task<UserModel> CreateUser(User User);
        Task<bool> DeleteUser(int userId);
        Task<List<UserModel>> GetUsers();
        Task<UserModel> GetUser(int UserId);
        Task<UserModel> UpdateUser(User user);
        Task<UserModel> Login(string login, string password);
    }
}
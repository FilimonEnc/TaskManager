using TaskManager.ApplicationLayer.Models;
using TaskManager.Core.Entities;

namespace TaskManager.ApplicationLayer.Interfaces.IServices
{
    public interface IUserService
    {
        Task AddUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(User user);
        Task<List<UserModel>> GetUsers();
        Task<UserModel> Authorization(string login, string password);
    }
}
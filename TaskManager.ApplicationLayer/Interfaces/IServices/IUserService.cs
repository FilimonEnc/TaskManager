using TaskManager.ApplicationLayer.Exceptions;
using TaskManager.ApplicationLayer.Models;
using TaskManager.Core.Entities;

namespace TaskManager.ApplicationLayer.Interfaces.IServices
{
    public interface IUserService
    {
        Task<Result> AddUser(User user);
        Task<Result> UpdateUser(User user);
        Task<Result> DeleteUser(User user);
        Task<Result<List<UserModel>>> GetUsers();
        Task<Result> Authorization(string login, string password);
    }
}
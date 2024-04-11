using TaskManager.Core.Entities;
using TaskManager.ApplicationLayer.Models;

namespace TaskManager.ApplicationLayer.Interfaces.IRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<UserModel> Login(string login, string password);
    }
}
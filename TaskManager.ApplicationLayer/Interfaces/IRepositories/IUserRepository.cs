using TaskManager.Core.Entities;
using TaskManager.ApplicationLayer.Models;

namespace TaskManager.ApplicationLayer.Interfaces.IRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> Login(string login, string password);

        new Task<User?> Add(User entity);
    }
}
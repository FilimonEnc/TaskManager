using System.Threading.Tasks;
using TaskManager.Entities;
using TaskManager.Models;

namespace TaskManager.Interfaces.IRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<UserModel> Login(string login, string password);
    }
}
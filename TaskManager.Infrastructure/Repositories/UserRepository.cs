using Mapster;

using Microsoft.EntityFrameworkCore;

using System.Security.Cryptography;
using System.Text;

using TaskManager.ApplicationLayer.Interfaces.IRepositories;
using TaskManager.ApplicationLayer.Models;
using TaskManager.Core.Entities;
using TaskManager.Infrastructure.DbContexts;
using TaskManager.Infrastructure.Exceptions;

namespace TaskManager.Infrastructure.Repositories
{
    public class UserRepository : DbRepository<User>, IUserRepository
    {
        private TaskManagerDbContext DbContext { get; init; }

        public UserRepository(TaskManagerDbContext dbContext) : base(dbContext)
        {
            DbContext = dbContext;
        }
        
        public async Task<User?> Login(string login, string password)
        {
            var user = await DbContext.Users.FirstOrDefaultAsync(
                u => 
                    u.Login == login && 
                    u.Password == HashPassword(password));
            return user;
        }

        public override async Task Add(User entity)
        {
            User? user = await DbContext.Users.FirstOrDefaultAsync(u => u.Login == entity.Login || u.Name == entity.Name);
            if (user != null)
                throw new ForbiddenException("Пользователь с такими данными уже существует");

            await base.Add(entity);
        }

        private static string HashPassword(string password)
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

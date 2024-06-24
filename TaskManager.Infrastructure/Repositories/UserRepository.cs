using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Logging.Abstractions;
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
                    u.Password == password);
            return user;
        }

        public override async Task<User?> Add(User entity)
        {
            User? user =
                await DbContext.Users.FirstOrDefaultAsync(u => u.Login == entity.Login || u.Name == entity.Name);

            if (user != null)
                return null;

            await base.Add(entity);
            return entity;
        }
    }
}
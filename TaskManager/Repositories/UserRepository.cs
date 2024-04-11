using Mapster;

using Microsoft.EntityFrameworkCore;

using MsBox.Avalonia.Enums;
using MsBox.Avalonia;

using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using TaskManager.DbContexts;
using TaskManager.Entities;
using TaskManager.Exceptions;
using TaskManager.Models;
using TaskManager.Interfaces.IRepositories;

namespace TaskManager.Repositories
{
    public class UserRepository : DbRepository<User>, IUserRepository
    {
        private TaskManagerDbContext DbContext { get; init; }

        public UserRepository(TaskManagerDbContext dbContext) : base(dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<UserModel> Login(string login, string password)
        {
            var user = await DbContext.Users.SingleOrDefaultAsync(u => u.Login == login && u.Password == HashPassword(password));
            if (user == null)
                throw new ForbiddenException("Не верные данные авторизации");

            return user.Adapt<UserModel>();
        }

        public override async Task Add(User entity)
        {
            var user = DbContext.Users.First(u => u.Login == entity.Login || u.Name == entity.Name);
            if (user != null)
                throw new ForbiddenException("Пользователь с такими данными уже существует");

            await base.Add(entity);

            var box = MessageBoxManager
            .GetMessageBoxStandard("Успех", "Пользователь успешно создан!",
                ButtonEnum.Ok);

            await box.ShowAsync();

        }

        private string HashPassword(string password)
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

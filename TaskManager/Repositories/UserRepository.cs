using Mapster;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

using TaskManager.DbContexts;
using TaskManager.Entities;
using TaskManager.Exceptions;
using TaskManager.Models;

namespace TaskManager.Repositories
{
    /// <summary>
    /// Репозиторий взаимодействия с пользователем
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private TaskManagerDbContext DbContext { get; init; }

        public UserRepository(TaskManagerDbContext dbContext)
        {
            DbContext = dbContext;
        }

        /// <summary>
        /// Создать пользователя
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        public async Task<UserModel> CreateUser(User User)
        {
            await DbContext.Users.AddAsync(User);

            await DbContext.SaveChangesAsync();

            return User.Adapt<UserModel>();
        }

        /// <summary>
        /// Получить данные всех пользователей
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserModel>> GetUsers()
        {
            return (await DbContext.Users
                .OrderByDescending(v => v.Id)
                .ToListAsync()).Adapt<List<UserModel>>();
        }

        /// <summary>
        /// Получить данные пользователя
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<UserModel> GetUser(int UserId)
        {
            return (await DbContext.Users
                .Where(v => v.Id == UserId)
                .SingleAsync()).Adapt<UserModel>();
        }

        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task<UserModel> Login(string login, string password)
        {
            User? user = await DbContext.Users
                .Where(v => v.Login == login && v.Password == password)
                .SingleAsync();

            if (user == null)
                throw new NotFoundException("Пользователя с таким логином и паролем не найдено");

            return user.Adapt<UserModel>();
        }

        /// <summary>
        /// Обновление данных пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<UserModel> UpdateUser(User user)
        {
            DbContext.Users.Attach(user);

            await DbContext.SaveChangesAsync();

            return user.Adapt<UserModel>();
        }

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteUser(int userId)
        {
            User user = await DbContext.Users
                .SingleAsync(t => t.Id == userId);

            if (user == null)
                return false;

            DbContext.Remove(user);
            await DbContext.SaveChangesAsync();

            return true;

        }
    }
}
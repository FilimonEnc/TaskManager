using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Threading.Tasks;

using TaskManager.DbContexts;
using TaskManager.Exceptions;
using TaskManager.Interfaces.IRepositories;

namespace TaskManager.Repositories
{
    public abstract class DbRepository<T> : IRepository<T> where T : class
    {
        private TaskManagerDbContext DbContext { get; init; }

        public DbRepository(TaskManagerDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public virtual async Task Add(T entity)
        {
            await DbContext.Set<T>().AddAsync(entity);
        }

        public async Task<T> Update(T entity)
        {
            DbContext.Set<T>().Attach(entity);

            await DbContext.SaveChangesAsync();

            return entity;
        }

        public async Task Delete(T entity)
        {
            T? TEntity = await DbContext.Set<T>().FindAsync(entity);

            if (TEntity == null)
                throw new NotFoundException("Не возможно удалить, т.к. эта запись отсутствует в базе");

            DbContext.Set<T>().Remove(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task<T> GetById(int id)
        {
            T? TEntity = await DbContext.Set<T>().FindAsync(id);

            if (TEntity == null)
                throw new NotFoundException("Запись не найдена");

            return TEntity;
        }

        public async Task<List<T>> GetAll()
        {
            return await DbContext.Set<T>().ToListAsync();
        }
    }
}
using Microsoft.EntityFrameworkCore;

using TaskManager.Core.Entities;

namespace TaskManager.Infrastructure.DbContexts
{
    public class TaskManagerDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=TaskManagerApp.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
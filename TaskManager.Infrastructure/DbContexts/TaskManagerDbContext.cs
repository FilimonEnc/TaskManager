using Microsoft.EntityFrameworkCore;

using TaskManager.Core.Entities;

namespace TaskManager.Infrastructure.DbContexts
{
    public class TaskManagerDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Reminder> Reminders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=TaskManagerApp.db");
        }
    }
}
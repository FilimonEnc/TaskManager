using Microsoft.EntityFrameworkCore;

using TaskManager.Entities;

namespace TaskManager.DbContexts
{
    public class TaskManagerDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }


        //public TaskManagerDbContext()
        //{
        //    ChangeTracker.StateChanged += UpdateTimestamps;
        //    ChangeTracker.Tracked += UpdateTimestamps;
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=TaskManagerApp.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //foreach (IMutableForeignKey fk in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            //{
            //    fk.DeleteBehavior = DeleteBehavior.Restrict;
            //}
        }
        //protected void UpdateTimestamps(object sender, EntityEntryEventArgs e)
        //{
        //    if (e.Entry.Entity.GetType().GetProperty("Updated") is System.Reflection.PropertyInfo prop)
        //        prop.SetValue(e.Entry.Entity, DateTime.UtcNow);
        //}
    }
}
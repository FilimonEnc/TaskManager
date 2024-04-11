using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;

using TaskManager.Core.Entities;
using TaskManager.Infrastructure.Exceptions;
using TaskManager.Interfaces;

namespace TaskManager.Infrastructure.Data
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        public DbSet<User> Users { get; set; } = null!;

        protected readonly IConfiguration Configuration;

        public ApplicationContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //public ApplicationContext(DbContextOptions<ApplicationContext> options, bool migrate = true) : base(options)
        //{
        //    if (migrate)
        //        Database.Migrate();
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=TaskManagerApp.db");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdatedDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedDate = DateTime.Now;
                }
            }

            try
            {
                return base.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new InfrastructureException($"При сохранении в базу данных возникла ошибка. {ex.Message}");
            }

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdatedDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedDate = DateTime.Now;
                }
            }
            try
            {
                return base.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new InfrastructureException($"При сохранении в базу данных возникла ошибка. {ex.Message}");
            }
            catch (DbUpdateException ex)
            {
                throw new InfrastructureException($"При сохранении в базу данных возникла ошибка. {ex.Message}");
            }
            catch (OperationCanceledException ex)
            {
                throw new InfrastructureException($"При сохранении в базу данных возникла ошибка. {ex.Message}");
            }
        }

        public Task<IDbContextTransaction> BeginTransaction()
        {
            return Database.BeginTransactionAsync();
        }
    }
}

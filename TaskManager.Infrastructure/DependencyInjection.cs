using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using TaskManager.Infrastructure.Data;
using TaskManager.Interfaces;

namespace TaskManager.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DbConnection");

            services.AddDbContext<ApplicationContext>(option =>
            {
                option.UseSqlite(connectionString);
            });

            services.AddScoped<IApplicationContext, ApplicationContext>();
            return services;
        }

    }
}

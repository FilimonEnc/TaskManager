using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;

using TaskManager.Presentation.ViewModels;
using TaskManager.Presentation.Views;
using TaskManager.Infrastructure.DbContexts;
using TaskManager.Infrastructure.Repositories;
using TaskManager.ApplicationLayer.Interfaces.IRepositories;
using TaskManager.ApplicationLayer.Interfaces.IServices;
using TaskManager.ApplicationLayer.Services;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;

namespace TaskManager.Presentation
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            IHostBuilder builder = new HostBuilder()
               .ConfigureServices((hostContext, services) =>
               {
                   services.AddDbContext<TaskManagerDbContext>();

                   //services.AddScoped(typeof(IRepository<>), typeof(DbRepository<>));

                   services.AddScoped<IUserRepository, UserRepository>();
                   services.AddScoped<IUserService, UserService>();
               });

            Program.Host = builder.Build();

            Scoped.Run((TaskManagerDbContext dbContext) =>
            {
                try
                {
                    dbContext.Database.Migrate();
                }
                catch
                {
                    Environment.Exit(1);
                }
            });



            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                // Line below is needed to remove Avalonia data validation.
                // Without this line you will get duplicate validations from both Avalonia and CT
                BindingPlugins.DataValidators.RemoveAt(0);
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel(),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;

using TaskManager.ViewModels;
using TaskManager.Views;

using Microsoft.Extensions.Hosting;
using TaskManager.DbContexts;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.Repositories;
using TaskManager.Services;
using System;
using Microsoft.EntityFrameworkCore;

namespace TaskManager
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

                   services.AddScoped<IUserRepository, UserRepository>();
                   services.AddScoped<ITaskManagerService, TaskManagerService>();
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
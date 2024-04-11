using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System;

using TaskManager.ApplicationLayer.Interfaces.IRepositories;
using TaskManager.ApplicationLayer.Interfaces.IServices;
using TaskManager.ApplicationLayer.Services;
using TaskManager.Infrastructure.DbContexts;
using TaskManager.Infrastructure.Repositories;
using TaskManager.Presentation.ViewModels;
using TaskManager.Presentation.Views;

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

                   services.AddScoped<MainWindowViewModel>();
               });

            Program.Host = builder.Build();
            var mainVm = Program.Host.Services.GetRequiredService<MainWindowViewModel>();

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
                    DataContext = mainVm,
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
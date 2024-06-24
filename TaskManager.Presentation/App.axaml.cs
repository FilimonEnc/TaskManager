using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System;
using Avalonia.Controls;
using TaskManager.ApplicationLayer.Interfaces.IRepositories;
using TaskManager.ApplicationLayer.Interfaces.IServices;
using TaskManager.ApplicationLayer.Services;
using TaskManager.Infrastructure.DbContexts;
using TaskManager.Infrastructure.Repositories;
using TaskManager.Presentation.ViewModels;
using TaskManager.Presentation.ViewModels.Tasks;
using TaskManager.Presentation.Views;
using TaskManager.Presentation.Views.Tasks;

namespace TaskManager.Presentation
{
    public partial class App : Application
    {
        /// <summary>
        /// �������� ������������ ���������
        /// </summary>
        public static CurrentUser CurrentUser { get; private set; } = new CurrentUser();


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
                   services.AddScoped<IUserService, UserService>();
                   services.AddScoped<TaskManagerDbContext>();

                   services.AddSingleton<MainWindowViewModel>();
                   services.AddSingleton<MainWindow>();
                   services.AddScoped<UserListPageViewModel>();
                   services.AddScoped<NotesListPageViewModel>();
                   services.AddScoped<ReminderWidgetViewModel>();
                   services.AddScoped<ReminderWidget>();
                   services.AddScoped<RegistrationPage>();
                   services.AddScoped<RegistrationPageViewModel>();
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
                BindingPlugins.DataValidators.RemoveAt(0);

                desktop.ShutdownMode = ShutdownMode.OnMainWindowClose;
                var mainWindow = new MainWindow()
                {
                    DataContext = mainVm
                };
                desktop.MainWindow = mainWindow;
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
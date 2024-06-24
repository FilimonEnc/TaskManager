using Avalonia.Controls.ApplicationLifetimes;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Microsoft.Extensions.DependencyInjection;

using MsBox.Avalonia;
using MsBox.Avalonia.Enums;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using TaskManager.ApplicationLayer.Interfaces.IServices;
using TaskManager.ApplicationLayer.Models;
using TaskManager.Core.Entities;
using TaskManager.Presentation.Views;

namespace TaskManager.Presentation.ViewModels
{
    public partial class UserListPageViewModel : ViewModelBase
    {
        private IUserService UserService { get; init; }

        [ObservableProperty] private string _password = string.Empty;

        [ObservableProperty] private List<UserModel> _users = new();

        [ObservableProperty] private UserModel? _selectedUser;

        private readonly Func<Task> _getUsers;

        public UserListPageViewModel(IUserService userService)
        {
            UserService = userService;
            
            _getUsers = GetUsers;
            _getUsers.Invoke();
        }

        [RelayCommand]
        private async Task GetUsers()
        {
            var result = await UserService.GetUsers();
            Users = result.Value;
        }

        [RelayCommand]
        public virtual async Task Auth()
        {
            if (SelectedUser == null || string.IsNullOrEmpty(Password))
            {
                await MessageBoxManager
                    .GetMessageBoxStandard("Ошибка", "Вы не выбрали пользователя / Не ввели пароль", ButtonEnum.Ok, Icon.Error)
                    .ShowAsync();
                return;
            }
            var result = await UserService.Authorization(SelectedUser.Login, Password);
            if (result.IsSuccess)
            {
                App.CurrentUser.LogIn(SelectedUser);
                await MessageBoxManager
                    .GetMessageBoxStandard("Успех", "Вы успешно авторизовались!", ButtonEnum.Ok, Icon.Success)
                    .ShowAsync();
            }
            else
                await MessageBoxManager
                    .GetMessageBoxStandard(result.Error.Code, result.Error.Description, ButtonEnum.Ok, Icon.Error)
                    .ShowAsync();
        }

        [RelayCommand]
        public void OpenRegistrationPage()
        {
            MainWindowViewModel mainVM = Program.Host.Services.GetRequiredService<MainWindowViewModel>();
            mainVM.SetActivePage<RegistrationPageViewModel, RegistrationPage>();
        }
    }
}
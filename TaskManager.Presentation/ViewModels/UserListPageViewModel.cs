using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using TaskManager.ApplicationLayer.Interfaces.IServices;
using TaskManager.ApplicationLayer.Models;

namespace TaskManager.Presentation.ViewModels
{
    public partial class UserListPageViewModel : ViewModelBase
    {
        private IUserService UserService { get; init; }

        [ObservableProperty] private List<UserModel> _users = new();

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
            Users = new(result.Value);
        }

        [RelayCommand]
        private async Task SelectUser()
        {
        }
    }
}
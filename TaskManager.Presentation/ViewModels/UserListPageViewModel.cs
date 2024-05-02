using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TaskManager.ApplicationLayer.Interfaces.IServices;
using TaskManager.ApplicationLayer.Models;

namespace TaskManager.Presentation.ViewModels
{
    public partial class UserListPageViewModel : ViewModelBase
    {
        private IUserService UserService { get; init; }

        [ObservableProperty] private List<UserModel> _users = new();

        private readonly Func<Task> getUsers;

        public UserListPageViewModel(IUserService userService)
        {
            UserService = userService;

            getUsers = GetUsers;
            getUsers.Invoke();
        }

        private async Task GetUsers()
        {
            Users = new(await UserService.GetUsers());
        }

        [RelayCommand]
        private async Task SelectUser()
        {
        }
    }
}
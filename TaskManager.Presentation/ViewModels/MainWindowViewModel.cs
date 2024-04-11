using System;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TaskManager.ApplicationLayer.Interfaces.IServices;
using TaskManager.Core.Entities;
using TaskManager.Infrastructure.Exceptions;
using TaskManager.Presentation.Views;

namespace TaskManager.Presentation.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private IUserService UserService { get; init; }

        [ObservableProperty] private object _activePage = null!;

        public MainWindowViewModel(IUserService userService)
        {
            UserService = userService;
        }


        [RelayCommand]
        public void OpenNotesListPage()
        {
            ActivePage = new NotesListPage();
        }

        [RelayCommand]
        private async Task OpenUserListPage(CancellationToken cancellationToken)
        {
            ActivePage = new UserListPage();
                await UserService.AddUser(new User()
                {
                    Login = "user",
                    Name = "user",
                    Password = "user",
                    IconPath = "user"
                });
            

        }
    }
}
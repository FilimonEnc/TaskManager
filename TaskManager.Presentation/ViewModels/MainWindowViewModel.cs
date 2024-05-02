using System;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using TaskManager.ApplicationLayer.Interfaces.IServices;
using TaskManager.Core.Entities;
using TaskManager.Infrastructure.Exceptions;
using TaskManager.Presentation.Views;

namespace TaskManager.Presentation.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private IUserService UserService { get; init; }

        [ObservableProperty] private UserControl _activePage = null!;

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
        private Task OpenUserListPage()
        {
            ActivePage = new UserListPage(new UserListPageViewModel(UserService));
            return null!;
        }
    }
}
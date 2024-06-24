using Avalonia.Controls;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Microsoft.Extensions.DependencyInjection;

using TaskManager.ApplicationLayer.Interfaces.IServices;
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

        protected internal void SetActivePage<TViewModel, TPage>()
        where TViewModel : ViewModelBase
        where TPage : UserControl, new()
        {
            var vm = Program.Host.Services.GetRequiredService<TViewModel>();
            ActivePage = new TPage
            {
                DataContext = vm
            };
        }

        [RelayCommand]
        private void OpenNotesListPage() => SetActivePage<NotesListPageViewModel, NotesListPage>();

        [RelayCommand]
        private void OpenUserListPage() => SetActivePage<UserListPageViewModel, UserListPage>();





    }
}
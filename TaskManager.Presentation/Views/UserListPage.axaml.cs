using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using TaskManager.Presentation.ViewModels;

namespace TaskManager.Presentation;

public partial class UserListPage : UserControl
{
    public UserListPage(UserListPageViewModel userListPageViewModel)
    {
        InitializeComponent();
        DataContext = userListPageViewModel;
    }
}
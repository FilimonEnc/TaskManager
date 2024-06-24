using CommunityToolkit.Mvvm.ComponentModel;

using TaskManager.ApplicationLayer.Models;

namespace TaskManager.Presentation.ViewModels.Tasks
{
    public partial class ReminderWidgetViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string _name = string.Empty;
        [ObservableProperty]
        private string _description = string.Empty;

        public ReminderWidgetViewModel(ReminderModel reminder)
        {
            Name = reminder.Name;
            Description = reminder.Description;
        }


    }
}

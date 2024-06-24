using Avalonia;
using Avalonia.Controls;

namespace TaskManager.Presentation.Views.Tasks
{
    public partial class ReminderWidget : Window
    {
        public ReminderWidget()
        {
            InitializeComponent();

            // Настройте свойства окна здесь
            this.CanResize = false; // Окно нельзя изменять по размеру
            //this.HasSystemDecorations = false; // Без системных украшений (границы и кнопки управления)
            this.Topmost = false; // Всегда поверх других окон
            this.ShowInTaskbar = false; // Не показывать в панели задач

            // Задайте дополнительные свойства
            this.WindowStartupLocation = WindowStartupLocation.Manual; // Позиционирование вручную
            this.Position = new PixelPoint(100, 100); // Пример позиционирования на экране
        }

        // Перекрытие метода для предотвращения закрытия окна
        protected override void OnClosing(WindowClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}

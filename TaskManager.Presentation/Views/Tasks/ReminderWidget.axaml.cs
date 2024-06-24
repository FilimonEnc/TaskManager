using Avalonia;
using Avalonia.Controls;

namespace TaskManager.Presentation.Views.Tasks
{
    public partial class ReminderWidget : Window
    {
        public ReminderWidget()
        {
            InitializeComponent();

            // ��������� �������� ���� �����
            this.CanResize = false; // ���� ������ �������� �� �������
            //this.HasSystemDecorations = false; // ��� ��������� ��������� (������� � ������ ����������)
            this.Topmost = false; // ������ ������ ������ ����
            this.ShowInTaskbar = false; // �� ���������� � ������ �����

            // ������� �������������� ��������
            this.WindowStartupLocation = WindowStartupLocation.Manual; // ���������������� �������
            this.Position = new PixelPoint(100, 100); // ������ ���������������� �� ������
        }

        // ���������� ������ ��� �������������� �������� ����
        protected override void OnClosing(WindowClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}

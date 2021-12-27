using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace GraphStudy.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            this.Activated += MainWindow_Activated;
        }

        private void MainWindow_Activated(object? sender, System.EventArgs e)
        {
            GraphStudy.Models.Settings.Instance.Width = this.Width;
            GraphStudy.Models.Settings.Instance.Height = this.Height;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}

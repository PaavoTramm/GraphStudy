using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace GraphStudy.Views
{
    public partial class VerticeView : UserControl
    {
        public VerticeView()
        {
            InitializeComponent();

            PointerPressed += VerticeView_PointerPressed;
        }

        private void VerticeView_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e)
        {
            
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}

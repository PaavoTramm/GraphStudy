using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace GraphStudy.Views
{
    public partial class MatrixView : UserControl
    {
        public MatrixView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}

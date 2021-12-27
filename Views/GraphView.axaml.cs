using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using GraphStudy.Models;

namespace GraphStudy.Views
{
    public partial class GraphView : UserControl
    {
        public GraphView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}

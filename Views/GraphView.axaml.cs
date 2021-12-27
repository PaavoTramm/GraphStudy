using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using GraphStudy.Models;
using System;

namespace GraphStudy.Views
{
    public partial class GraphView : UserControl
    {
        public GraphView()
        {
            InitializeComponent();

            this.LayoutUpdated += GraphView_LayoutUpdated;
        }

        private void GraphView_LayoutUpdated(object? sender, System.EventArgs e)
        {
            Control panel = this.FindControl<Control>("ThePanel");
            if(panel != null)
            {
                if (Double.IsNormal(panel.Bounds.Width))
                    Settings.Instance.Width = panel.Bounds.Width;
                if (Double.IsNormal(panel.Bounds.Height))
                    Settings.Instance.Height = panel.Bounds.Height;
            }
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}

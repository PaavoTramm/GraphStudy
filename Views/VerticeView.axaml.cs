using System;
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
            PointerMoved += VerticeView_PointerMoved;
            PointerReleased += VerticeView_PointerReleased;
        }

        bool m_down = false;

        private void VerticeView_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e)
        {
            if (null != Visual && null != Self)
            {
                m_down = Tools.Tool.Current.PointerPressed(Visual, Self, e);
            }
        }

        private void VerticeView_PointerMoved(object? sender, Avalonia.Input.PointerEventArgs e)
        {
            if (m_down && null != Visual && null != Self)
            {
                Tools.Tool.Current.PointerMoved(Visual, Self, e);
            }
        }

        private void VerticeView_PointerReleased(object? sender, Avalonia.Input.PointerReleasedEventArgs e)
        {
            if (m_down && null != Visual && null != Self)
            {
                Tools.Tool.Current.PointerReleased(Visual, Self, e);
                
                m_down = false;
            }
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        Canvas? Visual
        {
            get 
            {
                return Avalonia.VisualTree.VisualExtensions.FindAncestorOfType<Canvas>(this);
            }
        }

        Control? Self
        {
            get { return (Control?)this.Parent; }
        }
    }
}

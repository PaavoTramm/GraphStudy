using Avalonia;
using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphStudy.Tools
{
    internal class ToolMove : Tool
    {
        bool m_down = false;
        Point m_start = new Point();
        Point m_orig = new Point();

        public override string Name { get => "Move"; }

        public override bool PointerPressed(Canvas canvas, Control sender, Avalonia.Input.PointerEventArgs e)
        {
            m_down = true;
            m_start = e.GetPosition(canvas);
            m_orig = GetPosition(sender);
            return true;
        }

        public override bool PointerMoved(Canvas canvas, Control sender, Avalonia.Input.PointerEventArgs e)
        {
            if (m_down)
            {
                Point current = e.GetPosition(canvas);
                Point altered = m_orig + current - m_start;

                SetPosition(sender, altered);
            }
            return false;
        }
        
        public override bool PointerReleased(Canvas canvas, Control sender, Avalonia.Input.PointerEventArgs e)
        {
            if (m_down)
            {
                GraphStudy.ViewModels.GraphVertice? vm = (sender.DataContext as GraphStudy.ViewModels.GraphVertice);
                if (vm != null)
                {
                    Point current = e.GetPosition(canvas);
                    Point altered = m_orig + current - m_start;

                    vm.X = altered.X;
                    vm.Y = altered.Y;

                    vm.UpdatePosition();
                }
                m_down = false;
                return true;
            }
            return false;
        }

        Point GetPosition(Control c)
        {
            return new Point
            (
                Canvas.GetLeft(c),
                Canvas.GetTop(c)
            );
        }

        void SetPosition(Control c, Point p)
        {
            Canvas.SetLeft(c, p.X);
            Canvas.SetTop(c, p.Y);
        }
    }
}

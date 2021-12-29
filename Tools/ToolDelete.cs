using Avalonia;
using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphStudy.Tools
{
    internal class ToolDelete : Tool
    {
        public override string Name { get => "Delete"; }

        public override bool PointerPressed(Canvas canvas, Control sender, Avalonia.Input.PointerEventArgs e)
        {
            return false;
        }
        public override bool PointerMoved(Canvas canvas, Control sender, Avalonia.Input.PointerEventArgs e)
        {
            return false;
        }
        public override bool PointerReleased(Canvas canvas, Control sender, Avalonia.Input.PointerEventArgs e)
        {
            return false;
        }
    }
}

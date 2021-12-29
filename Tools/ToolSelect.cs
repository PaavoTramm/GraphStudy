using Avalonia;
using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphStudy.Tools
{
    internal class ToolSelect : Tool
    {
        public override string Name { get => "Select"; }

        public override bool PointerPressed(Canvas canvas, Control sender, Avalonia.Input.PointerEventArgs e)
        {
            GraphStudy.ViewModels.GraphVertice? vm = (sender.DataContext as GraphStudy.ViewModels.GraphVertice);
            if (vm != null)
            {
                if (null == GraphStudy.Models.State.Instance.Start)
                    GraphStudy.Models.State.Instance.Start = vm.Node;
                else if (null == GraphStudy.Models.State.Instance.End)
                    GraphStudy.Models.State.Instance.End = vm.Node;

                vm.Update();
            }
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

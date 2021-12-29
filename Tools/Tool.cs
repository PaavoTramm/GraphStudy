using Avalonia;
using Avalonia.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphStudy.Tools
{
    internal abstract class Tool
    {
        static Tool( )
        {
            m_tools = new Tool[]
            {
                new ToolSelect( ),
                new ToolMove( ),
                // new ToolDelete( ),
            };

            Selected = 0;
        }

        static Tool[] m_tools;

        public static Tool[] Tools
        {
            get { return m_tools; }
        }

        public static int Selected
        {
            get; set; 
        }

        public static Tool Current
        {
            get { return m_tools[Selected]; }
        }

        public abstract string Name { get; }
        public abstract bool PointerPressed(Canvas canvas, Control sender, Avalonia.Input.PointerEventArgs e);
        public abstract bool PointerMoved(Canvas canvas, Control sender, Avalonia.Input.PointerEventArgs e);
        public abstract bool PointerReleased(Canvas canvas, Control sender, Avalonia.Input.PointerEventArgs e);
    }
}

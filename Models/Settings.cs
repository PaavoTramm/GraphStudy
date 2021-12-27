using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace GraphStudy.Models
{
    public class Settings : ReactiveObject
    {
        private int m_count = 20;
        public int Nodes
        {
            get => m_count;
            set => this.RaiseAndSetIfChanged(ref m_count, value);
        }

        private int m_branches = 5;
        public int Edges
        {
            get => m_branches;
            set => this.RaiseAndSetIfChanged(ref m_branches, value);
        }

        private double m_width = 100;

        public double Width
        {
            get => m_width;
            set
            {
                if (value != Double.NaN)
                    this.RaiseAndSetIfChanged(ref m_width, value);
            }
        }

        private double m_height = 100;

        public double Height
        {
            get => m_height;
            set
            { 
                if (value != Double.NaN) 
                    this.RaiseAndSetIfChanged(ref m_height, value); 
            }
        }

        public static Settings Instance
        {
            get;
        } 
        = new Settings();
    }
}

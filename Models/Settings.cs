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
                if (Double.IsNormal(value) && value > 0)
                    this.RaiseAndSetIfChanged(ref m_width, value);
            }
        }

        private double m_height = 100;

        public double Height
        {
            get => m_height;
            set
            {
                if (Double.IsNormal(value) && value > 0)
                    this.RaiseAndSetIfChanged(ref m_height, value); 
            }
        }

        private double m_diameter = 20;

        public double Diameter
        {
            get => m_diameter;
            set
            {
                if (value != Double.NaN)
                {
                    this.RaiseAndSetIfChanged(ref m_diameter, value);
                    this.RaisePropertyChanged("Offset");
                }
            }
        }

        public double Offset
        {
            get => -m_diameter / 2;
            set { }
        }

        static List<String> m_algorithms = new List<string>()
        {
            "Dijkstra",
            "Random"
        };

        int m_index = 0;
        public String Algorithm
        {
            get
            {
                return m_algorithms[AlgorithmIndex];
            }
            set
            {
                int index = m_algorithms.IndexOf(value);
                if (index >= 0)
                    AlgorithmIndex = index;
            }
        }

        public int AlgorithmIndex
        {
            get
            {
                return m_index;
            }
            set
            {
                if (value >= 0 && value < m_algorithms.Count)
                    this.RaiseAndSetIfChanged(ref m_index, value); 
            }
        }

        public IEnumerable<String> Algorithms
        {
            get
            {
                return m_algorithms;
            }
        }

        public int ToolIndex
        {
            get
            {
                return GraphStudy.Tools.Tool.Selected;
            }
            set
            {
                if (GraphStudy.Tools.Tool.Selected != value)
                {
                    GraphStudy.Tools.Tool.Selected = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        List<String>? m_tools;

        public IEnumerable<String> Tools
        {
            get
            {
                if(m_tools== null)
                {
                    m_tools = new List<String>();
                    foreach(GraphStudy.Tools.Tool tool in GraphStudy.Tools.Tool.Tools)
                        m_tools.Add(tool.Name);
                }
                return m_tools;
            }
        }

        public static Settings Instance
        {
            get;
        } 
        = new Settings();
    }
}

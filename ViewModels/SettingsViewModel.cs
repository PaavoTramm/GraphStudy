using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphStudy.Models;

namespace GraphStudy.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        public int Count
        {
            get { return Models.Settings.Instance.Nodes; }
            set { Models.Settings.Instance.Nodes = value; }
        }
        public int Edges
        {
            get { return Models.Settings.Instance.Edges; }
            set { Models.Settings.Instance.Edges = value; }
        }
        public int Diameter
        {
            get { return (int)Models.Settings.Instance.Diameter; }
            set { Models.Settings.Instance.Diameter = (double)value; }
        }
        public String Algorithm
        {
            get { return Models.Settings.Instance.Algorithm; }
        }
        public IEnumerable<String> Algorithms
        {
            get { return Models.Settings.Instance.Algorithms; }
        }
        public int AlgorithmIndex
        {
            get { return Models.Settings.Instance.AlgorithmIndex; }
            set { Models.Settings.Instance.AlgorithmIndex = value; }
        }
        public IEnumerable<String> Tools
        {
            get { return Models.Settings.Instance.Tools; }
        }
        public int ToolIndex
        {
            get { return Models.Settings.Instance.ToolIndex; }
            set { Models.Settings.Instance.ToolIndex = value; }
        }
    }
}

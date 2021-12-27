using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using GraphStudy.Models;

namespace GraphStudy.ViewModels
{
    public class GraphViewModel : ViewModelBase
    {
        public GraphViewModel(IEnumerable<Node> nodes)
        {
            Nodes = new ObservableCollection<Node>(nodes);
        }

        ObservableCollection<Node> m_nodes = new ObservableCollection<Node>();
        public ObservableCollection<Node> Nodes
        {
            get { return m_nodes; }
            set { if (value != m_nodes) { this.RaiseAndSetIfChanged(ref m_nodes, value); ReCreatePresentation(); } }
        }

        ObservableCollection<ReactiveObject> m_elements = new ObservableCollection<ReactiveObject>();
        public ObservableCollection<ReactiveObject> Elements
        {
            get { return m_elements; }
            set { if (value != m_elements) { this.RaiseAndSetIfChanged(ref m_elements, value); } }
        }

        void ReCreatePresentation()
        {
            List<ReactiveObject> elements = new List<ReactiveObject>();
            foreach(Node node in m_nodes)
            {
                foreach (Edge edge in node.Edges)
                    elements.Add(new GraphEdge(node, edge));
            }

            foreach (Node node in m_nodes)
            {
                elements.Add(new GraphVertice(node));
            }
            
            Elements = new ObservableCollection<ReactiveObject>(elements);
        }
    }
}

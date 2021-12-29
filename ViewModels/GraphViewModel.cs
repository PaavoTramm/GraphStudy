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

        public void Refresh()
        {
            foreach (GraphElement element in Elements)
                element.Update();
        }

        ObservableCollection<Node> m_nodes = new ObservableCollection<Node>();
        public ObservableCollection<Node> Nodes
        {
            get { return m_nodes; }
            set { if (value != m_nodes) { this.RaiseAndSetIfChanged(ref m_nodes, value); ReCreatePresentation(); } }
        }

        ObservableCollection<GraphElement> m_elements = new ObservableCollection<GraphElement>();
        public ObservableCollection<GraphElement> Elements
        {
            get { return m_elements; }
            set { if (value != m_elements) { this.RaiseAndSetIfChanged(ref m_elements, value); } }
        }

        void ReCreatePresentation()
        {
            List<GraphElement> elements = new List<GraphElement>();
            foreach(Node node in m_nodes)
            {
                foreach (Edge edge in node.Edges)
                    elements.Add(new GraphEdge(this, node, edge));
            }

            foreach (Node node in m_nodes)
            {
                elements.Add(new GraphVertice(this, node));
            }
            
            Elements = new ObservableCollection<GraphElement>(elements);
        }

        public void UpdatePosition(GraphVertice node)
        {
            foreach (GraphElement element in Elements)
            {
                GraphEdge? edge = element as GraphEdge;
                if(edge != null)
                {
                    if(edge.Node == node.Node || edge.Edge.Node == node.Node)
                        edge.UpdatePosition();
                }
            }
        }
    }
}

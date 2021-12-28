using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphStudy.Models
{
    public class State
    {
        public State()
        {

        }

        public void Reset()
        {
            Start = null;
            End = null;
            
            m_nodes.Clear();
            m_edges.Clear();
        }

        public Node? Start
        {
            get;
            set;
        }

        public Node? End
        {
            get;
            set;
        }

        public int Nodes
        {
            get { return m_nodes.Count; }  
        }

        public int Edges
        {
            get { return m_edges.Count; }
        }

        HashSet<Node> m_nodes = new HashSet<Node>();
        public bool Selected(Node node)
        {
            return m_nodes.Contains(node);
        }
        
        public void Select(Node node)
        {
            if (!m_nodes.Contains(node))
                m_nodes.Add(node);
        }

        public void DeSelect(Node node)
        {
            if (m_nodes.Contains(node))
                m_nodes.Remove(node);
        }

        HashSet<Edge> m_edges = new HashSet<Edge>();
        public bool Selected(Edge edge)
        {
            return m_edges.Contains(edge);
        }

        public void Select(Edge edge)
        {
            if (!m_edges.Contains(edge))
                m_edges.Add(edge);
        }

        public void DeSelect(Edge edge)
        {
            if (m_edges.Contains(edge))
                m_edges.Remove(edge);
        }

        public void DeSelect()
        {
            m_nodes.Clear();
            m_edges.Clear();
        }

        Random m_random = new Random(Guid.NewGuid().GetHashCode());

        public Random Random
        {
            get { return m_random; }
        }

        static readonly State m_instance = new State();
        public static State Instance
        {
            get { return m_instance; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphStudy.Models
{
    public class AlgorithmDijkstra : Algorithm
    {

        public AlgorithmDijkstra(State state)
            : base(state)
        {

        }

        Dictionary<Node, Node> m_nearest = new Dictionary<Node, Node>();
        Dictionary<Node, double> m_distances = new Dictionary<Node, double>();
        Dictionary<Node, bool> m_visited = new Dictionary<Node, bool>();

        public override bool Prepare(IEnumerable<Node> nodes)
        {
            if (m_state.Start == null)
                m_state.Start = GetRandom(nodes);

            if(m_state.End != null)
            {
                if(object.ReferenceEquals(m_state.End, m_state.Start))
                    m_state.End = null;
            }

            return m_state.Start != null;
        }


        public override bool Execute(IEnumerable<Node> nodes)
        {
            Clear();

            Prepare(nodes);

            if (m_state.Start == null)
                return false;

            // build shortest path tree

            Distance(m_state.Start, 0);

            List<Node> queue = new List<Node>();
            queue.Add(m_state.Start);

            do
            {
                queue = queue.OrderBy(x => Distance(x)).ToList();
                Node node = queue.First();
                queue.Remove(node);

                foreach (Edge edge in node.Edges.OrderBy(x => x.Cost))
                {
                    Node next = edge.Node;
                    if (Visited(next))
                        continue;

                    if (Distance(next) == Infinity || (Distance(node) + edge.Cost) < Distance(next))
                    {
                        Distance(next, Distance(node) + edge.Cost);
                        Nearest(next, node);

                        if (!queue.Contains(next))
                            queue.Add(next);
                    }
                }

                Visited(node, true);
                
                // end reached
                if (node == m_state.End)
                    break;
            }
            while (queue.Any());

            // end node was defined
            if (m_state.End != null)
            {
                // failed to reach the end node
                if (!Visited(m_state.End))
                    return false;

                return SelectPath(nodes);
            }

            // highlight all possibilities
            foreach (Node n in nodes)
            {
                Node? n2 = Nearest(n);
                if (n2 != null)
                    Select(n, n2);
            }
            return true;
        }

        bool SelectPath(IEnumerable<Node> nodes)
        {
            Node? start = m_state.Start;

            Node? node = m_state.End;
            if (node == null)
                return false;

            m_state.Select(node);

            Node? next = null;
            do
            {
                next = Nearest(node);
                if (null == next)
                    return false;
                
                Select(node, next);

                if (ReferenceEquals(next, start))
                    return true;

                node = next;
            }
            while (null != next);

            return true;
        }

        void Clear()
        {
            m_nearest.Clear();
            m_distances.Clear();
            m_visited.Clear();
        }

        // distance to start
        double Distance(Node node)
        {
            if (m_distances.ContainsKey(node))
                return m_distances[node];

            return Infinity;
        }

        void Distance(Node node, double value)
        {
            m_distances[node] = value;
        }

        // nearest to start
        Node? Nearest(Node node)
        {
            if (m_nearest.ContainsKey(node))
                return m_nearest[node];

            return null;
        }

        void Nearest(Node node, Node other)
        {
            m_nearest[node] = other;
        }

        // visited
        bool Visited(Node node)
        {
            if (m_visited.ContainsKey(node))
                return m_visited[node];
            return false;
        }

        void Visited(Node node, bool n)
        {
            m_visited[node] = n;
        }

        static double Infinity
        {             
            get => Double.PositiveInfinity;
        }

    }
}

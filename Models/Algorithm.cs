using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphStudy.Models
{
    public abstract class Algorithm
    {
        protected State m_state;

        public Algorithm(State state)
        {
            m_state = state;
        }

        public abstract bool Prepare(IEnumerable<Node> nodes);
        public abstract bool Execute(IEnumerable<Node> nodes);

        public static Algorithm? Create(State state, String name)
        {
            if (name == "Random")
                return new AlgorithmRandom(state);

            if (name == "Dijkstra")
                return new AlgorithmDijkstra(state);

            return null;
        }

        protected Node? GetRandom(IEnumerable<Node> nodes)
        {
            int count = nodes.Count();
            if (count == 0)
                return null;

            int index = m_state.Random.Next(0, count);
            foreach (Node node in nodes)
            {
                if (index == 0)
                    return node;
                index--;
            }
            return null;
        }

        protected Node? GetRandom(Node? node)
        {
            if (null == node)
                return null;

            List<Node> targets = new List<Node>();

            foreach (Edge edge in node.Edges)
            {
                if (edge.Node == null)
                    continue;

                if (!State.Instance.Selected(edge.Node))
                    targets.Add(edge.Node);
            }
            return GetRandom(targets);
        }

        protected void Select(Node from, Node to)
        {
            Edge e1 = from.Edges.First(e => e.Node == to);
            Edge e2 = to.Edges.First( e => e.Node == from);
            if (e1 == null && e2 == null)
                return;

            if (e1 != null)
                m_state.Select(e1);
            if (e2 != null)
                m_state.Select(e2);

            m_state.Select(from);
            m_state.Select(to);
        }
    }
}

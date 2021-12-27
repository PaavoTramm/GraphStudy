using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphStudy.Models
{
    public class AlgorithmRandom : Algorithm
    {
        Random m_random = new Random(Guid.NewGuid().GetHashCode());

        public AlgorithmRandom()
        {

        }

        public override bool Execute(State state, IEnumerable<Node> nodes)
        {
            if (state.Start == null)
                state.Start = GetRandom(nodes);

            while (state.End == null || object.ReferenceEquals(state.End, state.Start))
            {
                state.End = GetRandom(nodes);
            }

            if (state.Start == null || state.End == null)
                return false;

            state.Select(state.Start);
            state.Select(state.End);

            Node? node = state.Start;
            while(null != (node = GetRandom(node)))
            {
                // blind luck!
                if (object.ReferenceEquals(state.End, node))
                    break;
                
                State.Instance.Select(node);
            }
            return true;
        }

        Node? GetRandom(IEnumerable<Node> nodes)
        {
            int count = nodes.Count();
            if (count == 0)
                return null;

            int index = m_random.Next(0, count);
            foreach (Node node in nodes)
            {
                if (index == 0)
                    return node;
                index--;
            }
            return null;
        }

        Node? GetRandom(Node? node)
        {
            if (null == node)
                return null;

            List<Node> targets = new List<Node>();

            foreach (Edge edge in node.Edges)
            {
                if (edge.Node == null)
                    continue;

                if(!State.Instance.Selected(edge.Node))
                    targets.Add(edge.Node);
            }
            return GetRandom(targets);
        }
    }
}

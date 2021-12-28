using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphStudy.Models
{
    public class AlgorithmRandom : Algorithm
    {
        public AlgorithmRandom(State state)
            : base(state)
        {

        }

        public override bool Prepare(IEnumerable<Node> nodes)
        {
            if (m_state.Start == null)
                m_state.Start = GetRandom(nodes);

            while (m_state.End == null || object.ReferenceEquals(m_state.End, m_state.Start))
            {
                m_state.End = GetRandom(nodes);
            }

            if (m_state.Start == null || m_state.End == null)
                return false;

            return true;
        }

        public override bool Execute(IEnumerable<Node> nodes)
        {
            Prepare(nodes);
            
            if (m_state.Start == null || m_state.End == null)
                return false;

            m_state.Select(m_state.Start);
            m_state.Select(m_state.End);

            Node? node = m_state.Start;
            Node? next = node;
            while (null != (next = GetRandom(node)))
            {
                Select(node, next);
                
                // blind luck!
                if (object.ReferenceEquals(m_state.End, next))
                    break;
                
                node = next;
            }
            return true;
        }
    }
}

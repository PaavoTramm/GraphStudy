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

        public override bool Execute(IEnumerable<Node> nodes)
        {
            Prepare(nodes);
            
            if (m_state.Start == null || m_state.End == null)
                return false;

            m_state.Select(m_state.Start);
            m_state.Select(m_state.End);

            Node? node = m_state.Start;
            while(null != (node = GetRandom(node)))
            {
                // blind luck!
                if (object.ReferenceEquals(m_state.End, node))
                    break;
                
                State.Instance.Select(node);
            }
            return true;
        }
    }
}

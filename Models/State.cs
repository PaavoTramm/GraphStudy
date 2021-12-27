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
            m_selected.Clear();
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

        HashSet<Node> m_selected = new HashSet<Node>();
        public bool Selected(Node node)
        {
            return m_selected.Contains(node);
        }
        
        public void Select(Node node)
        {
            if (!m_selected.Contains(node))
                m_selected.Add(node);
        }

        public void DeSelect(Node node)
        {
            if (m_selected.Contains(node))
                m_selected.Remove(node);
        }

        public void DeSelect()
        {
            m_selected.Clear();
        }

        static readonly State m_instance = new State();
        public static State Instance
        {
            get { return m_instance; }
        }
    }
}

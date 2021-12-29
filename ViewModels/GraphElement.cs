using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using GraphStudy.Models;

namespace GraphStudy.ViewModels
{
    public class GraphElement : ReactiveObject
    {
        readonly GraphViewModel m_parent;

        public GraphElement(GraphViewModel parent)
        {
            m_parent = parent;
        }

        public GraphViewModel Parent
        {
            get { return m_parent; }
        }

        public virtual void Update()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using GraphStudy.Models;

namespace GraphStudy.ViewModels
{
    public class GraphVertice : ReactiveObject
    {
        Node? m_node;
        public GraphVertice(Node node)
        {
            m_node = node;
        }

        public double X
        {
            get { return m_node != null ? m_node.Location.X : 0; }
            set 
            {
                if (m_node != null)
                {
                    Point p = new Point() { X = value, Y = m_node.Location.Y };
                    m_node.Location = p;
                    this.RaisePropertyChanged();
                }
            }
        }

        public double Y
        {
            get { return m_node != null ? m_node.Location.Y : 0; }
            set
            {
                if (m_node != null)
                {
                    Point p = new Point() { X = m_node.Location.X, Y = value };
                    m_node.Location = p;
                    this.RaisePropertyChanged();
                }
            }
        }

        public String Name
        {
            get { return "Node"; }
            set { }
        }

    }
}

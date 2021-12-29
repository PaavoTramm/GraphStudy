using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Media;
using ReactiveUI;
using GraphStudy.Models;

namespace GraphStudy.ViewModels
{
    public class GraphVertice : GraphElement
    {
        Node m_node;

        public GraphVertice(GraphViewModel parent, Node node)
            : base(parent)
        {
            m_node = node;
        }

        public override void Update()
        {
            this.RaisePropertyChanged("Fill");
            this.RaisePropertyChanged("Description");
        }

        public void UpdatePosition()
        {
            Parent.UpdatePosition(this);
        }

        public Node Node
        {
            get { return m_node; }
        }

        public String Description
        {
            get 
            { 
                if(IsStart)
                    return "This is start node";

                if (IsEnd)
                    return "This is end node";

                return $"This is node {m_node.Name}"; 
            }
        }

        public bool Selected
        {
            get 
            {
                return Models.State.Instance.Selected(m_node); 
            }
            set
            {
                if(value)
                    Models.State.Instance.Select(m_node);
                else
                    Models.State.Instance.DeSelect(m_node);

                this.RaisePropertyChanged("Fill");
            }
        }

        public bool IsStart
        {
            get
            {
                return object.ReferenceEquals(Models.State.Instance.Start, m_node);
            }
            set
            {
                if (value)
                {
                    Models.State.Instance.Start = m_node;
                }
                else
                {
                    if (object.ReferenceEquals(Models.State.Instance.Start, m_node))
                        Models.State.Instance.Start = null;
                }

                this.RaisePropertyChanged("Fill");
            }
        }

        public bool IsEnd
        {
            get
            {
                return object.ReferenceEquals(Models.State.Instance.End, m_node);
            }
            set
            {
                if (value)
                {
                    Models.State.Instance.End = m_node;
                }
                else
                {
                    if (Models.State.Instance.End == m_node)
                        Models.State.Instance.End = null;
                }

                this.RaisePropertyChanged("Fill");
            }
        }

        public IBrush Fill
        {
            get
            {
                if (IsStart)
                    return Brushes.LightCoral;

                if (IsEnd)
                    return Brushes.Red;

                if (Selected)
                    return Brushes.Green;

                return Brushes.LightGreen;
            }
        }

        public double X
        {
            get { return m_node != null ? m_node.Location.X : 0; }
            set 
            {
                m_node.Location = new Point() { X = value, Y = m_node.Location.Y };
                this.RaisePropertyChanged();
            }
        }

        public double Y
        {
            get { return m_node != null ? m_node.Location.Y : 0; }
            set
            {
                m_node.Location = new Point() { X = m_node.Location.X, Y = value };
                this.RaisePropertyChanged();
            }
        }

        public String Name
        {
            get { return "Node"; }
            set { }
        }

    }
}

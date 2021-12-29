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
    public class GraphEdge : GraphElement
    {
        Node m_node;
        Edge m_edge;
        public GraphEdge(GraphViewModel parent, Node node, Edge edge)
            : base(parent)
        {
            m_node = node;
            m_edge = edge;
        }

        public override void Update()
        {
            this.RaisePropertyChanged("Stroke");
            this.RaisePropertyChanged("Thickness");
        }

        public void UpdatePosition( )
        {
            this.RaisePropertyChanged("X");
            this.RaisePropertyChanged("Y");
            this.RaisePropertyChanged("Start");
            this.RaisePropertyChanged("End");
        }

        public Node Node
        {
            get { return m_node; }
        }

        public Edge Edge
        {
            get { return m_edge; }
        }

        public double X
        {
            get { return m_node.Location.X; }
            set 
            {
                m_node.Location = new Point() { X = value, Y = m_node.Location.Y };
                this.RaisePropertyChanged();
            }
        }

        public double Y
        {
            get { return m_node.Location.Y; }
            set
            {
                m_node.Location = new Point() { X = m_node.Location.X, Y = value };
                this.RaisePropertyChanged();
            }
        }

        public double X2
        {
            get 
            { 
                return m_edge.Node.Location.X; 
            }

            set
            {
                m_edge.Node.Location = new Point() { X = value, Y = m_edge.Node.Location.Y };
                this.RaisePropertyChanged();
            }
        }

        public double Y2
        {
            get
            {
                return m_edge.Node.Location.Y;
            }

            set
            {
                m_edge.Node.Location = new Point() { X = m_edge.Node.Location.X, Y = value };
                this.RaisePropertyChanged();
            }
        }

        public String Name
        {
            get { return "Node"; }
            set { }
        }

        public Avalonia.Point Start
        {
            get { return new Avalonia.Point(0, 0); }
            set { ; }
        }

        public Avalonia.Point End
        {
            get { return new Avalonia.Point(X2-X, Y2-Y); }
            set {; }
        }

        public IBrush Stroke
        {
            get
            {
                if (m_edge != null && State.Instance.Selected(m_edge))
                    return Brushes.Red;
                return Brushes.Black;
            }
        }

        public double Thickness
        {
            get
            {
                if (m_edge != null && State.Instance.Selected(m_edge))
                    return 1.0;
                return 0.5;
            }
        }

    }
}

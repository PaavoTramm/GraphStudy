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
        Node? m_node;
        Edge? m_edge;
        public GraphEdge(Node node, Edge edge)
            : base()
        {
            m_node = node;
            m_edge = edge;
        }

        public override void Update()
        {
            this.RaisePropertyChanged("Stroke");
            this.RaisePropertyChanged("Thickness");
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

        public double X2
        {
            get 
            { 
                return ( m_edge != null && m_edge.Node != null ) ? m_edge.Node.Location.X : 0; 
            }

            set
            {
                if (m_edge != null && m_edge.Node != null)
                {
                    Point p = new Point() { X = value, Y = m_edge.Node.Location.Y };
                    m_edge.Node.Location = p;
                    this.RaisePropertyChanged();
                }
            }
        }

        public double Y2
        {
            get
            {
                return (m_edge != null && m_edge.Node != null) ? m_edge.Node.Location.Y : 0;
            }

            set
            {
                if (m_edge != null && m_edge.Node != null)
                {
                    Point p = new Point() { X = m_edge.Node.Location.X, Y = value };
                    m_edge.Node.Location = p;
                    this.RaisePropertyChanged();
                }
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

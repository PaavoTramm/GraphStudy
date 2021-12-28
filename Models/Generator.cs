using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphStudy.Models
{
    public class Generator
    {
        Random m_random = new Random(Guid.NewGuid().GetHashCode());
        double m_mindistance = 0.1;
        
        int m_cells = 0;
        int m_count = 0;

        double m_cell_x = 0;
        double m_cell_y = 0;

        public List<Node> Generate()
        {
            List<Node> nodes = new List<Node>();

            m_count = Settings.Instance.Nodes;
            if (m_count <= 0)
                return nodes;

            m_cells = (int)(0.5 + Math.Sqrt((double)(2*m_count)));
            m_cell_x = XScale / m_cells;
            m_cell_y = YScale / m_cells;

            m_taken = null;

            // create randomly dispersed nodes

            for (int i = 0; i < m_count; ++i)
            {
                Node node = new Node();
                node.Location = Next(nodes);
                nodes.Add(node);
            }
            
            // make connections between nodes

            foreach (var node in nodes)
                Connect(node, nodes);

            return nodes;
        }

        void Connect(Node node, List<Node> nodes)
        {
            List<Edge> all = new List<Edge>();
            
            foreach (Node n in nodes)
            {
                if (object.ReferenceEquals(node, n))
                    continue;

                double distance = Distance.Between(n, node);
                all.Add(new Edge(n)
                {
                    Length = distance,
                    Weight = GetWeight()
                });
            }

            all = all.OrderBy(x => x.Length).ToList();

            var count = 0;

            foreach (Edge edge in all)
            {
                if (!node.Edges.Any(e => object.ReferenceEquals(e.Node, edge.Node)))
                    node.Edges.Add(edge);
                
                count++;

                // reverse connection

                if (edge.Node != null && !edge.Node.Edges.Any(e => object.ReferenceEquals(e.Node, node)))
                {
                    edge.Node.Edges.Add(new Edge(node)
                    { 
                        Length = edge.Length,
                        Weight = edge.Weight
                    });
                }

                if (count >= Settings.Instance.Edges)
                    return;
            }
        }

        static double GetWeight()
        {
            // NOTE: Node.Cost is Node.Length x Node.Weight
            // if settings.RandomWeight return 0.5 + m_random.NextDouble() ?
            return 1.0;
        }

        double XScale
        {
            get
            {
                return Settings.Instance.Width - Settings.Instance.Diameter - 5;
            }
        }

        double YScale
        {
            get
            {
                return Settings.Instance.Height - Settings.Instance.Diameter - 5;
            }
        }

        BitArray? m_taken = null;

        BitArray Taken
        {
            get 
            { 
                if( null== m_taken )
                    m_taken = new BitArray( m_cells*m_cells);
                return m_taken; 
            }
        }

        Point Next(List<Node> nodes)
        {
            int x = m_random.Next(0, m_cells);
            int y = m_random.Next(0, m_cells);

            while(Taken[m_cells * y + x])
            {
                x = m_random.Next(0, m_cells);
                y = m_random.Next(0, m_cells);
            }

            Taken[m_cells * y + x] = true;

            return new Point()
            {
                X = x * m_cell_x + m_cell_x * m_random.NextDouble(),
                Y = y * m_cell_y + m_cell_y * m_random.NextDouble()
            };
        }

        Point? FindAtDistance(List<Node> nodes, Point p)
        {
            foreach (var n in nodes)
            {
                if (Distance.Between(n.Location, p) < (XScale * m_mindistance))
                    return p;
            }
            return null;
        }
    }
}

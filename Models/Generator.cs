using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphStudy.Models
{
    public class Generator
    {
        Random m_random = new Random(Guid.NewGuid().GetHashCode());
        double m_scale = 200.0;
        double m_mindistance = 0.1;

        public List<Node> Generate()
        {
            List<Node> nodes = new List<Node>();

            // create Settings
            for(int i = 0; i < Settings.Instance.Nodes; ++i)
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
                all.Add(new Edge
                {
                    Node = n,
                    Length = distance,
                    Cost = m_random.NextDouble(),
                });
            }

            all = all.OrderBy(x => x.Length).ToList();

            var count = 0;

            foreach (var edge in all)
            {
                if (!node.Edges.Any(e => e.Node == edge.Node))
                    node.Edges.Add(edge);
                
                count++;

                // reverse connection

                if (edge.Node != null && !edge.Node.Edges.Any(e => e.Node == node))
                {
                    var backConnection = new Edge 
                    { 
                        Node = node, 
                        Length = edge.Length 
                    };

                    edge.Node.Edges.Add(backConnection);
                }

                if (count >= Settings.Instance.Edges)
                    return;
            }
        }

        Point Next(List<Node> nodes)
        {
            while (true)
            {
                Point p = new Point()
                {
                    X = m_scale * m_random.NextDouble(),
                    Y = m_scale * m_random.NextDouble()
                };

                if (null == FindAtDistance(nodes, p))
                    return p;
            }
        }

        Point? FindAtDistance(List<Node> nodes, Point p)
        {
            foreach (var n in nodes)
            {
                if (Distance.Between(n.Location, p) < (m_scale * m_mindistance))
                    return p;
            }
            return null;
        }
    }
}

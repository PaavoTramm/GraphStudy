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
                    Weight = GetWeight()
                });
            }

            all = all.OrderBy(x => x.Length).ToList();

            var count = 0;

            foreach (var edge in all)
            {
                if (!node.Edges.Any(e => object.ReferenceEquals(e.Node, edge.Node) ))
                    node.Edges.Add(edge);
                
                count++;

                // reverse connection

                if (edge.Node != null && !edge.Node.Edges.Any(e => object.ReferenceEquals(e.Node, node)))
                {
                    var backConnection = new Edge 
                    { 
                        Node = node, 
                        Length = edge.Length,
                        Weight = edge.Weight
                    };

                    edge.Node.Edges.Add(backConnection);
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

        Point Next(List<Node> nodes)
        {
            int index = 0;
            int maxval = 0xFFFF;

            while (true)
            {
                Point p = new Point()
                {
                    X = XScale * m_random.NextDouble(),
                    Y = YScale * m_random.NextDouble()
                };

                if (null == FindAtDistance(nodes, p))
                    return p;

                if (++index > maxval)
                    return p;
            }
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

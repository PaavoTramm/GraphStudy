using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphStudy.Models
{
    public class Matrix
    {
        public Matrix(IEnumerable<Node> nodes)
        {
            // build index to speed up lookup

            m_index = new Dictionary<Node, int>();
            int i = 0;
            foreach (Node node in nodes)
                m_index[node] = i++;

            // build NxN matrix of node-to-node costs

            m_N = nodes.Count();
            m_graph = new double[m_N, m_N];

            int n = 0;

            foreach (Node node in nodes)
            {
                m_graph[n, n] = 0;

                foreach (Edge edge in node.Edges)
                {
                    m_graph[n, m_index[edge.Node]] = edge.Cost;
                }
                n++;
            }
        }

        public int N 
        { 
            get => m_N; 
        }

        public int this[Node? n]
        {
            get { if(n == null || m_index == null) return - 1; return m_index[n]; }
            set { if (n != null && m_index != null) m_index[n] = value; }
        }

        public double this[int r, int c]
        {
            get { return m_graph[r, c]; } 
        }

        int m_N = 0;
        double[,] m_graph;
        Dictionary<Node, int> m_index;
    }
}

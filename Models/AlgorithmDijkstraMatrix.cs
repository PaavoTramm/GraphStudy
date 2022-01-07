using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphStudy.Models
{
    public class AlgorithmDijkstraMatrix : Algorithm
    {

        public AlgorithmDijkstraMatrix(State state)
            : base(state)
        {

        }

        Matrix? m_matrix;

        public override bool Prepare(IEnumerable<Node> nodes)
        {
            if (m_state.Start == null)
                m_state.Start = GetRandom(nodes);

            if(m_state.End != null)
            {
                if(object.ReferenceEquals(m_state.End, m_state.Start))
                    m_state.End = null;
            }

            return m_state.Start != null;
        }

        public override bool Execute(IEnumerable<Node> nodes)
        {
            Clear();

            Prepare(nodes);

            if (m_state.Start == null)
                return false;

            m_matrix = new Matrix(nodes);

            int src = m_matrix[m_state.Start];
            int dst = m_matrix[m_state.End]; // -1 when end == null

            double[] dist = new double[m_matrix.N];
            bool[] visited = new bool[m_matrix.N];

            for (int i = 0; i < m_matrix.N; i++)
            {
                dist[i] = Infinity;
                visited[i] = false;
            }

            dist[src] = 0;

            bool done = false;

            for (int count = 0; !done && count < (m_matrix.N - 1); count++)
            {
                int u = minDistance(dist, visited);

                visited[u] = true;

                for (int v = 0; v < m_matrix.N; v++)
                    if (!visited[v] && m_matrix[u, v] != 0 && dist[u] != Infinity && dist[u] + m_matrix[u, v] < dist[v])
                    {
                        dist[v] = dist[u] + m_matrix[u, v];
                        if (dst >= 0 && v == dst)
                        {
                            done = true;
                            break;
                        }

                    }
            }

            int n = 0;
            foreach (Node node in nodes)
            {
                if (dist[n] != Infinity)
                    m_state.Select(node);
                n++;
            }

            return true;
        }

        void Clear()
        {
            m_matrix = null;
        }

        int minDistance(double[] dist, bool[] visited)
        {
            // Initialize min value
            double min = Infinity;
            int min_index = -1;

            if (m_matrix != null)
            {
                for (int v = 0; v < m_matrix.N; v++)
                    if (visited[v] == false && dist[v] <= min)
                    {
                        min = dist[v];
                        min_index = v;
                    }
            }
            return min_index;
        }

        static double Infinity
        {
            get => Double.PositiveInfinity;
        }
    }
}

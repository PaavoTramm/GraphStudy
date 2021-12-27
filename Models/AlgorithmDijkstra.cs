using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphStudy.Models
{
    public class AlgorithmDijkstra : Algorithm
    {
        public AlgorithmDijkstra()
        {

        }

        Dictionary<Node, double> distances = new Dictionary<Node, double>();
        List<Node> path = new List<Node>();

        public override bool Execute(State state, IEnumerable<Node> nodes)
        {
            distances.Clear();
            path.Clear();

            if (null == state.Start)
                state.Start = nodes.First();

            distances[state.Start] = 0;
            path.Add(state.Start);


            return true;
        }

        double Distance(Node node)
        {
            if (distances.ContainsKey(node))
                return distances[node];

            return Infinity;
        }

        static double Infinity
        {             
            get => Double.PositiveInfinity;
        }

    }
}

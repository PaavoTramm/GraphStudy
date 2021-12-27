using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphStudy.Models
{
    public abstract class Algorithm
    {
        public abstract bool Execute(State state, IEnumerable<Node> nodes);

        public static Algorithm? Create(String name)
        {
            if (name == "Random")
                return new AlgorithmRandom();

            if (name == "Dijkstra")
                return new AlgorithmDijkstra();

            return null;
        }
    }
}

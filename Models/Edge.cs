using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphStudy.Models
{
    public class Edge
    {
        public double Length { get; set; }
        public double Weight { get; set; } = 1.0;
        public double Cost { get => Weight * Length; }
        public Node? Node { get; set; }

        public override string ToString()
        {
            return "-> " + (Node == null ? "null" : Node.ToString());
        }
    }
}

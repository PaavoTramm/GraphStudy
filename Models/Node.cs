using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphStudy.Models
{
    public class Node
    {
        public Point Location { get; set; } = new Point();

        public List<Edge> Edges { get; set; } = new List<Edge>();
    }
}

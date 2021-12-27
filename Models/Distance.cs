using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphStudy.Models
{
    public static class Distance
    {
        public static double Between(Node start, Node end)
        {
            return Math.Sqrt(Math.Pow(start.Location.X - end.Location.X, 2) + Math.Pow(start.Location.Y - end.Location.Y, 2));
        }
        public static double Between(Point start, Point end)
        {
            return Math.Sqrt(Math.Pow(start.X - end.X, 2) + Math.Pow(start.Y - end.Y, 2));
        }
    }
}

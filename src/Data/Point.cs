using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticRegeneration.Data
{
    /// <summary>
    /// Defines a point on a 2D Grid
    /// </summary>
    struct Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        int X { get; }
        int Y { get; }
    }
}

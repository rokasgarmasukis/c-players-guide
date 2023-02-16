using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes;
internal class Point
{
    public int X { get; }
    public int Y { get; }
    public Point() : this(0, 0) { }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
}


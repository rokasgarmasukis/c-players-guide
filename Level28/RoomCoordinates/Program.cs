Console.Title = "Room Coordinates";

Coordinate a = new Coordinate(1, 2);
Coordinate b = new Coordinate(1, 1);
Coordinate c = new Coordinate(0, 1);

Console.WriteLine(a.IsAdjacent(b));
Console.WriteLine(a.IsAdjacent(c));

public struct Coordinate
{
    public int X { get;  }
    public int Y { get; }

    public Coordinate(int x, int y)
    {
        X = x; Y = y;
    }

    public bool IsAdjacent(Coordinate other)
    {
        if ((Math.Abs(other.X - X) == 1 && other.Y == Y) || (Math.Abs(other.Y - Y) == 1 && other.X == X))
        {
            return true;
        }
        return false;
    }
}
